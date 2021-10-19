using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

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

    }
}
