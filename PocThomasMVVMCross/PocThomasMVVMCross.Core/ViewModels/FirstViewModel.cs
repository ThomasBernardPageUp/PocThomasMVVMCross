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

        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; RaiseAllPropertiesChanged(); }
        }

        public string FullName
        {
            get { return string.Format("{0} {1}", _firstName, _lastName); }
        }

    }
}
