using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Freelancer.Services.Controllers
{
    public class BaseApiController : ApiController
    {
        protected T TryExecuteOperation<T>(Func<T> operation)
        {
            try
            {
                return operation();
            }
            catch (Exception ex)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
                throw new HttpResponseException(errResponse);
            }
        }
    }
}
