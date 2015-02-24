using System;
using System.Linq;

namespace Freelancer.Services.Utilities
{
    public static class UserValidator
    {
        private const string ValidUsernameChars =
           "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM_1234567890";
        private const string ValidNicknameChars =
            "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM_1234567890 -";
        private const int MinUsernameNicknameChars = 6;
        private const int MaxUsernameNicknameChars = 30;
        private const int Sha1CodeLength = 40;

        public static void ValidateUsername(string username)
        {
            if (username == null || username.Length < MinUsernameNicknameChars || username.Length > MaxUsernameNicknameChars)
            {
                throw new ArgumentException(string.Format(
                    "Username should be between {0} and {1} symbols long",
                    MinUsernameNicknameChars,
                    MaxUsernameNicknameChars), "username");
            }
            else if (username.Any(ch => !ValidUsernameChars.Contains(ch)))
            {
                throw new ArgumentException("Username contains invalid characters", "username");
            }
        }

        public static void ValidateNickname(string nickname)
        {
            if (nickname == null || nickname.Length < MinUsernameNicknameChars || nickname.Length > MaxUsernameNicknameChars)
            {
                throw new ArgumentException(string.Format(
                    "Nickname should be between {0} and {1} symbols long",
                    MinUsernameNicknameChars,
                    MaxUsernameNicknameChars), "nickname");
            }
            else if (nickname.Any(ch => !ValidNicknameChars.Contains(ch)))
            {
                throw new ArgumentException("Nickname contains invalid characters", "nickname");
            }
        }

        public static void ValidateAuthCode(string authCode)
        {
            if (authCode.Length != Sha1CodeLength)
            {
                throw new ArgumentException("Invalid user authentication", "authCode");
            }
        }
    }
}