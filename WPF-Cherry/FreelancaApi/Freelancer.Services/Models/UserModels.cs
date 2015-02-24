using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using CodeFirst.Model;
using Freelancer.Services.Models;

namespace Freelancer.Services.Models
{
    public class UserRegisterRequestModel
    {
        public static Func<UserRegisterRequestModel, User> ToEntity { get; set; }

        public string Username { get; set; }

        public string DisplayName { get; set; }

        public string AuthCode { get; set; }

        public string Mail { get; set; }

        public string Phone { get; set; }

        public string Location { get; set; }

        //public UserType UserType { get; set; }

        static UserRegisterRequestModel()
        {
            ToEntity = x => new User
            {
                Username = x.Username,
                DisplayName = x.DisplayName,
                AuthCode = x.AuthCode,
                //UserType = x.UserType,
                Email = x.Mail,
                Phone = x.Phone,
                Location = x.Location
            };
        }
    }

    [DataContract]
    public class UserRegisterResponseModel
    {
        public static Func<User, UserRegisterResponseModel> FromEntity { get; set; }

        [DataMember(Name = "displayName")]
        public string DisplayName { get; set; }

        [DataMember(Name = "accessToken")]
        public string AccessToken { get; set; }

        static UserRegisterResponseModel()
        {
            FromEntity = x => new UserRegisterResponseModel { 
                DisplayName = x.DisplayName, 
                AccessToken = x.AccessToken, 
            };
        }
    }

    public class UserLoginRequestModel
    {
        public static Func<UserLoginRequestModel, User> ToEntity { get; set; }

        public string Username { get; set; }

        public string AuthCode { get; set; }

        //public UserType UserType { get; set; }

        static UserLoginRequestModel()
        {
            ToEntity = x => new User { 
                Username = x.Username, 
                AuthCode = x.AuthCode, 
                //UserType = x.UserType 
            };
        }
    }

    //[DataContract]
    public class UserLoginResponseModel
    {
        public static Func<User, UserLoginResponseModel> FromEntity { get; set; }

        //[DataMember(Name = "displayName")]
        public int Id { get; set; }

        //[DataMember(Name = "displayName")]
        public string DisplayName { get; set; }

        //[DataMember(Name = "accessToken")]
        public string AccessToken { get; set; }

        //[DataMember(Name = "userType")]
        //public UserType UserType { get; set; }

        static UserLoginResponseModel()
        {
            FromEntity = x => new UserLoginResponseModel
            {
                Id = x.Id,
                DisplayName = x.DisplayName,
                AccessToken = x.AccessToken,
                //UserType = x.UserType
            };
        }
    }

    public class UserLogoutRequestModel
    {
        public string AccessToken { get; set; }
    }

    public class UserModel
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string DisplayName { get; set; }

        //public UserType UserType { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Location { get; set; }
    }

    public class UserDetailedModel : UserModel
    {
        public virtual ICollection<JobModel> MyPostedJobs { get; set; }
        public virtual ICollection<JobModel> CurrentJobs { get; set; }
    }
}