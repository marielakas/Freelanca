using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ValueProviders;
using Freelancer.Services.Attributes;
using Freelancer.Services.Data;
using Freelancer.Services.Models;

namespace Freelancer.Services.Controllers
{
    public class CategoryController : BaseApiController
    {
        private readonly UnitOfWork unitOfWork = new UnitOfWork();

        [HttpGet]
        [ActionName("all")]
        public IEnumerable<CategoryModel> GetMyJobs(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string accessToken)
        {
            var messageResponse = this.TryExecuteOperation<IEnumerable<CategoryModel>>(() =>
            {
                var user = unitOfWork.userRepository.All().Single(x => x.AccessToken == accessToken);
                if (user == null)
                {
                    throw new InvalidOperationException("User has not logged in!");
                }

                var allCategories = this.unitOfWork.categoryRepository.All().ToList();
                var categoriesModel = allCategories.Select(x => new CategoryModel()
                {
                    Id = x.Id,
                    Name = x.Name
                });

                return categoriesModel;
            });

            return messageResponse;
        }

        [HttpGet]
        [ActionName("detailed")]
        public CategoryModel GetMyJobs(int Id,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string accessToken)
        {
            var messageResponse = this.TryExecuteOperation<CategoryModel>(() =>
            {
                var user = unitOfWork.userRepository.All().Single(x => x.AccessToken == accessToken);
                if (user == null)
                {
                    throw new InvalidOperationException("User has not logged in!");
                }

                var category = this.unitOfWork.categoryRepository.All().ToList().FirstOrDefault(x => x.Id == Id);
                var categoriesModel = new CategoryModel()
                {
                    Id = category.Id,
                    Name = category.Name
                };

                return categoriesModel;
            });

            return messageResponse;
        }
    }
}
