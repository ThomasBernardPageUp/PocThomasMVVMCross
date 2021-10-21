using MvvmCross.Commands;
using MvvmCross.ViewModels;
using PocThomasMVVMCross.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace PocThomasMVVMCross.Core.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {
        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; RaiseAllPropertiesChanged(); }
        }

        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; RaiseAllPropertiesChanged(); }
        }

        public string FullName => string.Format("{0} {1}", _firstName, _lastName);

        private MvxCommand _deleteCommand;
        public ICommand DeleteCommand => _deleteCommand;

        private MvxCommand _createAccountCommand;
        public ICommand CreateAccountCommand => _createAccountCommand;

        private IPopUpService _popUpService;

        public FirstViewModel(IPopUpService popUpService)
        {
            _deleteCommand = new MvxCommand(DeleteName);
            _createAccountCommand = new MvxCommand(CreateAccount);
            _popUpService = popUpService;
        }

        private void DeleteName()
        {
            FirstName = "";
            LastName = "";
        }

        private async void CreateAccount()
        {
            await _popUpService.ShowPopUp();
            Console.WriteLine("OK, la pop up a été validée");
        }

    }
}
