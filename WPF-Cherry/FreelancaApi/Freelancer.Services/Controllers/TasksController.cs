using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ValueProviders;
using Freelancer.Services.Attributes;
using Freelancer.Services.Data;

namespace Freelancer.Services.Controllers
{
    public class TasksController : BaseApiController
    {
        private readonly UnitOfWork unitOfWork = new UnitOfWork();

        [HttpPut]
        [ActionName("change-status")]
        public HttpResponseMessage ChangeTodoStatus(int todoId,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]
            string accessToken)
        {
            return this.TryExecuteOperation(() =>
            {
                var user = unitOfWork.userRepository.All().Single(x => x.AccessToken == accessToken);
                if (user == null)
                {
                    throw new InvalidOperationException("User has not logged in!");
                }

                return new HttpResponseMessage(HttpStatusCode.OK);
            });
        }
    }
}
