using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using FreeLancaVS2012.Models;
using FreeLancaVS2012.ViewModels;

namespace FreeLancaVS2012.Data
{
    public class DataPersister
    {
        private const int TokenLength = 50;
        private const string TokenChars = "qwertyuiopasdfghjklmnbvcxzQWERTYUIOPLKJHGFDSAZXCVBNM";
        private const int MinUsernameLength = 6;
        private const int MaxUsernameLength = 30;
        private const int AuthenticationCodeLength = 40;
        private const string ValidUsernameChars = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNM1234567890_.@";

        protected static string AccessToken { get; set; }
        //TODO change BaseServiceUrl
        private const string BaseServicesUrl = "http://localhost:55806/api/";

        internal static void RegisterUser(string username, string displayName, string email,
            string phone, string location, string authenticationCode)
        {
            ValidateUsername(username);
            ValidateEmail(email);
            ValidateAuthCode(authenticationCode);

            var userModel = new UserModel()
            {
                Username = username,
                DisplayName = displayName,
                Email = email,
                Phone = phone,
                Location = location,
                AuthCode = authenticationCode
            };

            HttpRequester.Post(BaseServicesUrl + "users/register",
                userModel);
        }

        internal static string LoginUser(string username, string authenticationCode)
        {
            ValidateUsername(username);
            ValidateAuthCode(authenticationCode);

            var userModel = new UserLoginModel()
            {
                Username = username,
                AuthCode = authenticationCode
            };
            var loginResponse = HttpRequester.Post<LoginResponseModel>(BaseServicesUrl + "auth/token",
                userModel);
            AccessToken = loginResponse.AccessToken;
            return loginResponse.DisplayName;
        }

        internal static bool LogoutUser()
        {
            var headers = new Dictionary<string, string>();
            headers["X-accessToken"] = AccessToken;
            var isLogoutSuccessful = HttpRequester.Put(BaseServicesUrl + "users/logout", headers);
            return isLogoutSuccessful;
        }

        internal static void ChangeState(int taskId)
        {
            var headers = new Dictionary<string, string>();
            headers["X-accessToken"] = AccessToken;

            HttpRequester.Put(BaseServicesUrl + "tasks/" + taskId, headers);
        }

        private static void ValidateEmail(string email)
        {
            try
            {
                new MailAddress(email);
            }
            catch (FormatException ex)
            {
                throw new FormatException("Email is invalid", ex);
            }
        }

        private static void ValidateUser(UserModel userModel)
        {
            if (userModel == null)
            {
                throw new FormatException("Username and/or password are invalid");
            }
            ValidateUsername(userModel.Username);
            ValidateAuthCode(userModel.AuthCode);
        }

        private static void ValidateAuthCode(string authCode)
        {
            if (string.IsNullOrEmpty(authCode) || authCode.Length != AuthenticationCodeLength)
            {
                throw new FormatException("Password is invalid");
            }
        }

        public static void ValidateUsername(string username)
        {
            if (username.Length < MinUsernameLength || MaxUsernameLength < username.Length)
            {
                throw new FormatException(
                    string.Format("Username must be between {0} and {1} characters",
                        MinUsernameLength,
                        MaxUsernameLength));
            }
            if (username.Any(ch => !ValidUsernameChars.Contains(ch)))
            {
                throw new FormatException("Username contains invalid characters");
            }
        }

        internal static IEnumerable<JobDetailedViewModel> GetPostedJobsList()
        {
            var headers = new Dictionary<string, string>();
            headers["X-accessToken"] = AccessToken;

            var jobsList =
                HttpRequester.Get<IEnumerable<JobDetailedModel>>(BaseServicesUrl + "jobs/posted-jobs-names", headers);
            return jobsList.
                AsQueryable().
                 Select(model => new JobDetailedViewModel()
                 {
                     Id = model.Id,
                     Title = model.Title
                 });
        }

        internal static IEnumerable<JobDetailedViewModel> GetDetailedPostedJobsList()
        {
            var headers = new Dictionary<string, string>();
            headers["X-accessToken"] = AccessToken;

            var jobsList =
                HttpRequester.Get<IEnumerable<JobDetailedModel>>(BaseServicesUrl + "jobs/posted-jobs", headers);
            return jobsList.
                AsQueryable().
                 Select(model => new JobDetailedViewModel()
                 {
                     Id = model.Id,
                     Title = model.Title,
                     Description = model.Description,
                     Deadline = model.Deadline,
                     CreatedAt = model.CreatedAt,
                     Completed = model.Completed,
                     Price = model.Price,
                     //Tasks = model.Tasks.AsQueryable().Select(todo => new TaskViewModel()
                     // {
                     //     Id = todo.Id,
                     //     Name = todo.Name,
                     //     Pending = todo.Pending
                     // }).ToList(),
                     Owner = model.Owner,
                     // Tasks = model.Tasks,
                     TotalDifficulty = model.TotalDifficulty,
                     Category = model.Category,
                    // JobTags = model.JobTags.AsQueryable().Select(tag => tag.Name).ToList()
                     // JobTags = model.JobTags
                 });
        }

        internal static IEnumerable<JobDetailedViewModel> GetMyJobsList()
        {
            var headers = new Dictionary<string, string>();
            headers["X-accessToken"] = AccessToken;

            var jobsList =
                HttpRequester.Get<IEnumerable<JobDetailedViewModel>>(BaseServicesUrl + "jobs/current-jobs-names", headers);
            return jobsList.
                AsQueryable().
                 Select(model => new JobDetailedViewModel()
                 {
                     Id = model.Id,
                     Title = model.Title,
                 });
        }

        internal static IEnumerable<JobDetailedViewModel> GetDetailedMyJobsList()
        {
            var headers = new Dictionary<string, string>();
            headers["X-accessToken"] = AccessToken;

            var jobsList =
                HttpRequester.Get<IEnumerable<JobDetailedModel>>(BaseServicesUrl + "jobs/current-jobs", headers);
            return jobsList.
                AsQueryable().
                 Select(model => new JobDetailedViewModel()
                 {
                     Id = model.Id,
                     Title = model.Title,
                     Description = model.Description,
                     Deadline = model.Deadline,
                     CreatedAt = model.CreatedAt,
                     Completed = model.Completed,
                     Price = model.Price,
                     //Tasks = model.Tasks.AsQueryable().Select(todo => new TaskViewModel()
                     //{
                     //    Id = todo.Id,
                     //    Name = todo.Name,
                     //    Pending = todo.Pending
                     //}).ToList(),
                     //Tasks = model.Tasks,
                     Owner = model.Owner,
                     TotalDifficulty = model.TotalDifficulty,
                     Category = model.Category,
                     //JobTags = model.JobTags.AsQueryable().Select(tag => tag.Name).ToList()
                     // JobTags = model.JobTags
                 });
        }

        internal static void CreateNewJob(string title, IEnumerable<TaskViewModel> tasks)
        {
            //var listModel = new TodolistModel()
            //{
            //    Title = title,
            //    Todos = tasks.Select(t => new TodoModel()
            //    {
            //        Text = t.Text
            //    })
            //};

            //var headers = new Dictionary<string, string>();
            //headers["X-accessToken"] = AccessToken;

            //var response =
            //    HttpRequester.Post<ListCreatedModel>(BaseServicesUrl + "lists", listModel, headers);
        }



        internal static IEnumerable<JobDetailedViewModel> SearchJob(string queryString)
        {
            var headers = new Dictionary<string, string>();
            headers["X-accessToken"] = AccessToken;

            var matchedJobs =
                HttpRequester.Get<IEnumerable<JobDetailedModel>>(BaseServicesUrl + "jobs/search?query=" + queryString, headers);
            return matchedJobs.
                AsQueryable().
                 Select(model => new JobDetailedViewModel()
                 {
                     Id = model.Id,
                     Title = model.Title,
                     Description = model.Description,
                     //Deadline = model.Deadline,
                     //CreatedAt = model.CreatedAt,
                     //Completed = model.Completed,
                     //Price = model.Price,
                     //Tasks = model.Tasks.AsQueryable().Select(todo => new TaskViewModel()
                     //{
                     //    Id = todo.Id,
                     //    Name = todo.Name,
                     //    Pending = todo.Pending
                     //}).ToList(),
                     ////Tasks = model.Tasks,
                     //TotalDifficulty = model.TotalDifficulty,
                     //Category = model.Category,
                     //JobTags = model.JobTags.AsQueryable().Select(tag => tag.Name).ToList()
                 });
        }

        internal static void CreateNewTodosList(string title,string description,DateTime deadline,double price,
            string category ,string totalDifficulty, IEnumerable<TaskViewModel> tasks)
        {
            var listModel = new JobDetailedModel()
            {
                Title = title,
                Description=description,
                Deadline=deadline,
                Price=price,
                Category=category,
                TotalDifficulty= totalDifficulty.ToString(),
                Tasks = tasks.Select(t => new TaskModel()
                {
                    Name = t.Name,
                    Difficulty = t.Difficulty
                }).ToList()
            };

            var headers = new Dictionary<string, string>();
            headers["X-accessToken"] = AccessToken;

                HttpRequester.Post<JobViewModel>(BaseServicesUrl + "jobs/new", listModel, headers);
        }
    }
}