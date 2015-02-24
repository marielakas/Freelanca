using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using FreeLancaVS2012.Behavior;
using FreeLancaVS2012.Data;
using FreeLancaVS2012.Helpers;
using FreeLancaVS2012.ViewModels;
using System.Security.Cryptography;

namespace FreeLancaVS2012.ViewModels
{
    public class LoginRegisterFormViewModel: ViewModelBase, IPageViewModel
    {
        private string message;
        private ICommand loginCommand;
        private ICommand registerCommand;

        public string Name
        {
            get
            {
                return "Login Form";
            }
        }
        public string LoginUsername { get; set; }
        public string RegUsername { get; set; }

        public string DisplayName { get; set; }
        public string Phone { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }

        public string Message
        {
            get
            {
                return this.message;
            }
            set
            {
                this.message = value;
                this.OnPropertyChanged("Message");
            }
        }

        public ICommand Login
        {
            get
            {
                if (this.loginCommand == null)
                {
                    this.loginCommand = new RelayCommand(this.HandleLoginCommand);
                }
                return this.loginCommand;
            }
        }

        public ICommand Register
        {
            get
            {
                if (this.registerCommand == null)
                {
                    this.registerCommand = new RelayCommand(this.HandleRegisterCommand);
                }
                return this.registerCommand;
            }
        }

        public event EventHandler<LoginSuccessArgs> LoginSuccess;

        public LoginRegisterFormViewModel()
        {
            this.RegUsername = "UUUUUU";
            this.LoginUsername = "UUUUUU";
            this.DisplayName = "DDDDDD";
            this.Email = "EEE@EEE.EEE";
            this.Phone = "PPPPPP";
            this.Location = "LLLLLL";
        }

        private void HandleRegisterCommand(object parameter)
        {
            var passwordBox = parameter as PasswordBox;
            var password = passwordBox.Password;
            //TODO:SHA1
            #region TODO:SHA1 
            //SHA1 sha = new SHA1CryptoServiceProvider();
            //var passwordBytes = Encoding.Default.GetBytes(password);
            //passwordBytes = Encoding.Convert(Encoding.Default,Encoding.UTF8,passwordBytes);
            //var authenticationCodeBytes = sha.ComputeHash(passwordBytes);
            //var authenticationCode = Encoding.UTF8.GetString(authenticationCodeBytes); 
            #endregion

            var authenticationCode = this.GetSHA1HashData(password);

            DataPersister.RegisterUser(this.RegUsername, this.DisplayName, this.Email,this.Phone, this.Location, authenticationCode);
            this.HandleLoginRegisterCommand(parameter);
        }

        private void HandleLoginRegisterCommand(object parameter)
        {
            var passwordBox = parameter as PasswordBox;
            var password = passwordBox.Password;
            var authenticationCode = this.GetSHA1HashData(password);
            //var authenticationCode = CalculateSHA1(password, Encoding.UTF8);

            var username = DataPersister.LoginUser(this.RegUsername, authenticationCode);

            if (!string.IsNullOrEmpty(username))
            {
                this.RaiseLoginSuccess(username);
            }
        }

        private static string CalculateSHA1(string text, Encoding enc)
        {
            // Convert the input string to a byte array
            byte[] buffer = enc.GetBytes(text);

            // In doing your test, you won't want to re-initialize like this every time you test a
            // string.
            SHA1CryptoServiceProvider cryptoTransformSHA1 =
                new SHA1CryptoServiceProvider();

            // The replace won't be necessary for your tests so long as you are consistent in what
            // you compare.    
            string hash = BitConverter.ToString(
                cryptoTransformSHA1.ComputeHash(buffer)).Replace("-", "");

            return hash;
        }

        private void HandleLoginCommand(object parameter)
        {
            var passwordBox = parameter as PasswordBox;
            var password = passwordBox.Password;
            var authenticationCode = this.GetSHA1HashData(password);

            //var authenticationCode = CalculateSHA1(password, Encoding.UTF8);

            var username = DataPersister.LoginUser(this.LoginUsername, authenticationCode);

            if (!string.IsNullOrEmpty(username))
            {
                this.RaiseLoginSuccess(username);
            }
        }

        private string GetSHA1HashData(string data)
        {
            return "0123456789012345678901234567890123456789";
        }


        protected void RaiseLoginSuccess(string username)
        {
            if (this.LoginSuccess!= null)
            {
                this.LoginSuccess(this, new LoginSuccessArgs(username));                
            }
        }

    }
}
   
