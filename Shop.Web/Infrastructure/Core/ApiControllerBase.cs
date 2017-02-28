using Shop.Model.Models;
using Shop.Service;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Shop.Web.Infrastructure.Core
{
    public class ApiControllerBase : ApiController
    {
        private IErrorService _errorService;
        public ApiControllerBase(IErrorService errorService)
        {
            this._errorService = errorService;
        }

        protected HttpResponseMessage CreateHttpResponse(HttpRequestMessage requestMessage,Func<HttpResponseMessage> funcion )
        {
            HttpResponseMessage response = null;
            try
            {
                response = funcion.Invoke();
            }
            catch (DbEntityValidationException ex)
            {
                foreach(var eve in ex.EntityValidationErrors)
                {
                    Trace.WriteLine($"Entity of type\"{eve.Entry.Entity.GetType().Name}\"in state\" { eve.Entry.State}\"has the following validation errors.");
                    foreach(var ve in eve.ValidationErrors)
                    {
                        Trace.WriteLine($"-Property:\"{ve.PropertyName}\",Error:\"{ve.ErrorMessage}\"");
                    }
                }
            }
            catch (DbUpdateException dbEx)
            {
                LogError(dbEx);
                response = requestMessage.CreateResponse(HttpStatusCode.BadRequest, dbEx.InnerException.Message);
            }
            catch (Exception ex)
            {
                LogError(ex);
                response = requestMessage.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            return response;
        }

        private void LogError(Exception ex)
        {
            try
            {
                Error er = new Error();
                er.CreatedDate = DateTime.Now;
                er.Message = ex.Message;
                er.StackTrace = ex.StackTrace;
                _errorService.Create(er);
                _errorService.Save();
            }
            catch
            {

            }
        }
    }
}
