using System;
using System.Drawing;
using CoreGraphics;
using MvvmCross.Platforms.Ios.Views;
using PocThomasMVVMCross.Core.ViewModels;
using UIKit;

namespace PocThomasMVVMCross.Ios.Views
{
    public partial class FirstView : MvxViewController<FirstViewModel>
    {
        private UITextField _textFieldFirstName = new UITextField();
        private UITextField _textFieldLastName = new UITextField();
        private UILabel _labelFullName = new UILabel();
        private UIButton _buttonReset = new UIButton(UIButtonType.RoundedRect);
        private UIButton _buttonCreateAccount = new UIButton(UIButtonType.RoundedRect);

        public FirstView() : base("FirstView", null)
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            
            _textFieldFirstName.Frame = new CGRect(10, 140, View.Bounds.Width - 45, 50);
            _textFieldFirstName.BorderStyle = UITextBorderStyle.RoundedRect;
            _textFieldFirstName.Placeholder = "Enter your first name";
            Add(_textFieldFirstName); // Add to the view

            _textFieldLastName.Frame = new CGRect(10, 200, View.Bounds.Width - 45, 50);
            _textFieldLastName.BorderStyle = UITextBorderStyle.RoundedRect;
            _textFieldLastName.Placeholder = "Enter your last name";
            Add(_textFieldLastName); // Add to the view

            _labelFullName.Frame = new CGRect(0, 300, View.Bounds.Width, 50);
            _labelFullName.BackgroundColor = UIColor.SystemBlueColor;
            Add(_labelFullName); // Add to the view

            _buttonReset.SetTitle("Reset", UIControlState.Normal);
            _buttonReset.SetTitleColor(UIColor.White, UIControlState.Normal);
            _buttonReset.Frame = new RectangleF(50, 400, 300, 50);
            _buttonReset.BackgroundColor = UIColor.SystemRedColor;
            Add(_buttonReset);
            


            _buttonCreateAccount.SetTitle("Create your account", UIControlState.Normal);
            _buttonCreateAccount.Frame = new RectangleF(50, 500, 300, 50);
            _buttonCreateAccount.SetTitleColor(UIColor.White, UIControlState.Normal) ;
            _buttonCreateAccount.BackgroundColor = UIColor.SystemBlueColor;
            Add(_buttonCreateAccount);



            var set = this.CreateBindingSet();
            set.Bind(_textFieldFirstName).To(vm => vm.FirstName); // Bind the entry with prop
            set.Bind(_textFieldLastName).To(vm => vm.LastName); // Bind the entry with prop
            set.Bind(_labelFullName).To(vm => vm.FullName); // Bind the label with prop
            set.Bind(_buttonReset).To(vm => vm.DeleteCommand);
            set.Bind(_buttonCreateAccount).To(vm => vm.ShowPopUpAccountCommand);

            set.Apply();
        }

        public override void DidReceiveMemoryWarning()

        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

