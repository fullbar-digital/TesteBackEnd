using FluentValidation;
using FluentValidation.Results;
using TesteBackEnd.Domain.Entities;
using TesteBackEnd.Domain.Interfaces;
using TesteBackEnd.Domain.Notifications;

namespace TesteBackEnd.Service.Services
{
    public class BaseService
    {
        private readonly INotifier _notifier;
        protected BaseService(INotifier notifier)
        {
            _notifier = notifier;
        }
        protected bool ValidationExecute<TValidation, TEntity>(TValidation validation, TEntity entity) where TValidation : AbstractValidator<TEntity> where TEntity : BaseEntity
        {
            var validator = validation.Validate(entity);
            if (validator.IsValid) { return true; };
            this.Notify(validator.ToString());
            return false;
        }
        protected void Notify(string message)
        {
            _notifier.Handle(new Notification(message));
        }
        protected void Notify(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                this.Notify(error.ErrorMessage);
            }
        }

    }
}