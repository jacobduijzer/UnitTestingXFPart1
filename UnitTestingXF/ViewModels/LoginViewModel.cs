using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmHelpers;
using Xamarin.Forms;

namespace UnitTestingXF.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await DoLoginAsync(), () => IsFormValid);
        }

        public ICommand LoginCommand { get; private set; }

        private string _username;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); OnPropertyChanged("IsFormValid"); }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); OnPropertyChanged("IsFormValid"); }
        }

        public bool IsFormValid
        {
            get => !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);            
        }

		private async Task DoLoginAsync()
		{
            if(!IsBusy)
            {
                IsBusy = true;

                // TODO: Implement login logic

                IsBusy = false;
            }
		}
    }
}
