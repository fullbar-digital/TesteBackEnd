using Domain.Helpers;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Teste_Prático_Backend.Helpers
{
    public class UnitOfWorkActionFilters : System.Web.Http.Filters.ActionFilterAttribute
    {
        public IUnitOfWork UnitOfWork { get; set; }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            UnitOfWork = actionContext.Request.GetDependencyScope().GetService(typeof(IUnitOfWork)) as IUnitOfWork;
            UnitOfWork.BeginTransaction();
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            UnitOfWork = actionExecutedContext.Request.GetDependencyScope().GetService(typeof(IUnitOfWork)) as IUnitOfWork;
            if(actionExecutedContext.Exception == null)
            {
                //Caso não tenha exeções commit
                UnitOfWork.Commit();
            }
            else
            {
                //Caso tenha exeções Rollback
                UnitOfWork.RollBack();
                
            }
        }

    }
}
