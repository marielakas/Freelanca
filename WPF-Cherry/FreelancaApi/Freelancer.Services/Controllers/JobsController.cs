using CodeFirst.Model;
using Freelancer.Services.Attributes;
using Freelancer.Services.Data;
using Freelancer.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ValueProviders;

namespace Freelancer.Services.Controllers
{
    public class JobsController : BaseApiController
    {
        private readonly UnitOfWork unitOfWork = new UnitOfWork();

        [HttpGet]
        [ActionName("all")]
        public IEnumerable<JobDetailedModel> GetAllJobs(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string accessToken)
        {
            var messageResponse = this.TryExecuteOperation<IEnumerable<JobDetailedModel>>(() =>
            {
                var user = unitOfWork.userRepository.All().SingleOrDefault(x => x.AccessToken == accessToken);
                if (user == null)
                {
                    throw new InvalidOperationException("User has not logged in!");
                }

                var allJobs = unitOfWork.jobRepository.All().ToList();
                var jobsModel = allJobs.Select(x => new JobDetailedModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    Category = x.Category.Name,
                    CreatedAt = x.CreatedAt,
                    Completed = x.Completed,
                    Deadline = x.Deadline,
                    Owner = x.Owner.DisplayName,
                    TotalDifficulty = x.TotalDifficulty,
                    Price = x.Price,
                    Tasks = x.Tasks.Select(y => new TaskModel(){
                        Id = y.Id,
                        Name = y.Name,
                        Difficulty = y.Difficulty,
                        Pending = y.Pending
                    }).ToList(),
                    JobTags = x.JobTags.Select(y => y.Name).ToList()
                });

                return jobsModel;
            });

            return messageResponse;
        }

        [HttpGet]
        [ActionName("current-jobs")]
        public IEnumerable<JobDetailedModel> GetMyJobs(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string accessToken)
        {
            var messageResponse = this.TryExecuteOperation<IEnumerable<JobDetailedModel>>(() =>
            {
                var user = unitOfWork.userRepository.All().SingleOrDefault(x => x.AccessToken == accessToken);
                if (user == null)
                {
                    throw new InvalidOperationException("User has not logged in!");
                }

                var myJobs = this.unitOfWork.jobRepository.All().ToList().Where(x => x.Worker.Id == user.Id);
                var jobsModel = myJobs.Select(x => new JobDetailedModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    Category = x.Category.Name,
                    CreatedAt = x.CreatedAt,
                    Completed = x.Completed,
                    Deadline = x.Deadline,
                    Owner = x.Owner.DisplayName,
                    TotalDifficulty = x.TotalDifficulty,
                    Price = x.Price,
                    Tasks = x.Tasks.Select(y => new TaskModel(){
                        Id = y.Id,
                        Name = y.Name,
                        Difficulty = y.Difficulty,
                        Pending = y.Pending
                    }).ToList(),
                    JobTags = x.JobTags.Select(y => y.Name).ToList()
                });

                return jobsModel;
            });

            return messageResponse;
        }

        [HttpGet]
        [ActionName("current-jobs-names")]
        public IEnumerable<JobNames> GetMyJobsNames(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string accessToken)
        {
            var messageResponse = this.TryExecuteOperation<IEnumerable<JobNames>>(() =>
            {
                var user = unitOfWork.userRepository.All().SingleOrDefault(x => x.AccessToken == accessToken);
                if (user == null)
                {
                    throw new InvalidOperationException("User has not logged in!");
                }

                var myJobs = this.unitOfWork.jobRepository.All().Where(x => x.Worker.Id == user.Id);
                var jobsModel = myJobs.Select(x => new JobNames()
                {
                    Id = x.Id,
                    Title = x.Title
                });

                return jobsModel;
            });

            return messageResponse;
        }

        [HttpGet]
        [ActionName("posted-jobs")]
        public IEnumerable<JobDetailedModel> GetPostedJobs(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string accessToken)
        {
            var messageResponse = this.TryExecuteOperation<IEnumerable<JobDetailedModel>>(() =>
            {
                var user = unitOfWork.userRepository.All().SingleOrDefault(x => x.AccessToken == accessToken);
                if (user == null)
                {
                    throw new InvalidOperationException("User has not logged in!");
                }

                var myJobs = this.unitOfWork.jobRepository.All().ToList().Where(x => x.Owner.Id == user.Id);
                var jobsModel = myJobs.Select(x => new JobDetailedModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    Category = x.Category.Name,
                    CreatedAt = x.CreatedAt,
                    Completed = x.Completed,
                    Deadline = x.Deadline,
                    Owner = x.Owner.DisplayName,
                    TotalDifficulty = x.TotalDifficulty,
                    Price = x.Price,
                    Tasks = x.Tasks.Select(y => new TaskModel(){
                        Id = y.Id,
                        Name = y.Name,
                        Difficulty = y.Difficulty,
                        Pending = y.Pending
                    }).ToList(),
                    JobTags = x.JobTags.Select(y => y.Name).ToList()
                });

                return jobsModel;
            });

            return messageResponse;
        }

        [HttpGet]
        [ActionName("posted-jobs-names")]
        public IEnumerable<JobNames> GetPostedJobsNames(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string accessToken)
        {
            var messageResponse = this.TryExecuteOperation<IEnumerable<JobNames>>(() =>
            {
                var user = unitOfWork.userRepository.All().SingleOrDefault(x => x.AccessToken == accessToken);
                if (user == null)
                {
                    throw new InvalidOperationException("User has not logged in!");
                }

                var myJobs = this.unitOfWork.jobRepository.All().Where(x => x.Owner.Id == user.Id);
                var jobsModel = myJobs.Select(x => new JobNames()
                {
                    Id = x.Id,
                    Title = x.Title
                });

                return jobsModel;
            });

            return messageResponse;
        }

        [HttpGet]
        [ActionName("search")]
        public IEnumerable<JobDetailedModel> GetMyJobs(string query,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string accessToken)
        {
            var messageResponse = this.TryExecuteOperation<IEnumerable<JobDetailedModel>>(() =>
            {
                var user = unitOfWork.userRepository.All().ToList().SingleOrDefault(x => x.AccessToken == accessToken);
                if (user == null)
                {
                    throw new InvalidOperationException("User has not logged in!");
                }

                var matchedJobs = this.unitOfWork.jobRepository.All().ToList().Where(x => x.Title.Contains(query));
                var jobsModel = matchedJobs.Select(x => new JobDetailedModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    Category = x.Category.Name,
                    CreatedAt = x.CreatedAt,
                    Completed = x.Completed,
                    Deadline = x.Deadline,
                    Owner = x.Owner.DisplayName,
                    TotalDifficulty = x.TotalDifficulty,
                    Price = x.Price,
                    Tasks = x.Tasks.Select(y => new TaskModel(){
                        Id = y.Id,
                        Name = y.Name,
                        Difficulty = y.Difficulty,
                        Pending = y.Pending
                    }).ToList(),
                    JobTags = x.JobTags.Select(y => y.Name).ToList()
                });

                return jobsModel;
            });

            return messageResponse;
        }

        [HttpPost]
        [ActionName("new")]
        public HttpResponseMessage PostJob(CreateJobModel jobModel,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string accessToken)
        {
            var messageResponse = this.TryExecuteOperation<HttpResponseMessage>(() =>
            {
                var user = unitOfWork.userRepository.All().Single(x => x.AccessToken == accessToken);
                if (user == null)
                {
                    throw new InvalidOperationException("User has not logged in!");
                }

                var jobToAdd = new Job()
                {
                    Title = jobModel.Title,
                    Owner = user,
                    CreatedAt = DateTime.Now,
                    Description = jobModel.Description,
                    Deadline = DateTime.Now,
                    Price = jobModel.Price,
                    TotalDifficulty = jobModel.TotalDifficulty
                };

                if (jobModel.Category == null)
                {
                    jobModel.Category = "Other";
                }
                var category = this.unitOfWork.categoryRepository.All().SingleOrDefault(x => x.Name == jobModel.Category);
                if (category == null)
                {
                    category = new Category()
                    {
                        Name = jobModel.Category
                    };
                }
                jobToAdd.Category = category;

                this.unitOfWork.jobRepository.Add(jobToAdd);
                this.unitOfWork.Save();

                return new HttpResponseMessage(HttpStatusCode.Created);
            });

            return messageResponse;
        }
    }
}
