using MvvmCross.Commands;
using MvvmCross.ViewModels;
using PocThomasMVVMCross.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PocThomasMVVMCross.Core.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {
        private string _firstName = "";
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; RaiseAllPropertiesChanged(); }
        }

        private string _lastName ="";

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; RaiseAllPropertiesChanged(); }
        }

        public string FullName => string.Format("{0} {1}", _firstName, _lastName);

        private MvxAsyncCommand _deleteCommand;
        public ICommand DeleteCommand => _deleteCommand;

        private MvxAsyncCommand _showPopUpAccountCommand;
        public ICommand ShowPopUpAccountCommand => _showPopUpAccountCommand;

        private IPopUpService _popUpService;

        public FirstViewModel(IPopUpService popUpService)
        {
            _popUpService = popUpService;

            _deleteCommand = new MvxAsyncCommand(DeleteName);
            _showPopUpAccountCommand = new MvxAsyncCommand(async () => await ShowPopUpAccount());
        }

        private async Task DeleteName()
        {
            FirstName = "";
            LastName = "";
        }

        private async Task ShowPopUpAccount()
        {
            try
            {
                var mail = await _popUpService.ShowPopUp("Warning", string.Format("Hello {0} do you want to create an account with this mail ?", this.FullName), string.Format("{0}.{1}@pageup.fr", this.FirstName.ToLower(), this.LastName.ToLower()));
                Console.WriteLine("Compte créé avec l'adresse " + mail);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

    }
}
