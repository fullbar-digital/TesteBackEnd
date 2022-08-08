using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using TesteBackEnd.Domain.Interfaces;
using TesteBackEnd.Domain.Notifications;

namespace TesteBackEnd.Application.Controllers
{
    public class MainController : ControllerBase
    {
        private readonly INotifier _notifier;

        protected MainController(INotifier notifier)
        {
            _notifier = notifier;
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (this.IsValid())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }
            else
            {
                return BadRequest(new
                {
                    success = false,
                    errors = _notifier.GetNotifications().Select(n => n.Message)
                });
            }
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotifierErrorInvalidModel(modelState);
            return CustomResponse();
        }

        protected void NotifierErrorInvalidModel(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(e => e.Errors);
            foreach (var error in errors)
            {
                var errorMessage = error.Exception == null ? error.ErrorMessage : error.Exception.Message;
                ErrorNotifier(errorMessage);
            }
        }

        protected void ErrorNotifier(string message)
        {
            _notifier.Handle(new Notification(message));
        }

        protected bool IsValid()
        {
            return !_notifier.HasNotification();
        }
    }
}
