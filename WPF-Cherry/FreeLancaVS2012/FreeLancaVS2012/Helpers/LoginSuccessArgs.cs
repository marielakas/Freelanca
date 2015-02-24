using System;

namespace FreeLancaVS2012.Helpers
{
    public class LoginSuccessArgs:EventArgs
    {
        public string Username { get; set; }

        public LoginSuccessArgs(string username)
            : base()
        {
            this.Username = username;
        }
    }
}
