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
        public FirstView() : base("FirstView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.


            var textEditFirst = new UITextField { BackgroundColor = UIColor.Gray, Frame = new CGRect(10, 100, View.Bounds.Width - 30, 50) };
            Add(textEditFirst); // Add to the view

            var textEditSecond = new UITextField { BackgroundColor = UIColor.Gray, Frame = new CGRect(50, 170, View.Bounds.Width - 30, 50) };
            Add(textEditSecond); // Add to the view

            var labelFull = new UILabel { Frame = new CGRect(50, 300, 200, 50), BackgroundColor = UIColor.Red };
            Add(labelFull); // Add to the view

            var resetButton = new UIButton(UIButtonType.RoundedRect);
            resetButton.SetTitle("Reset", UIControlState.Normal);
            resetButton.Frame = new RectangleF(50, 400, 300, 50);
            resetButton.BackgroundColor = UIColor.Red;
            Add(resetButton);

            var createAccount = new UIButton(UIButtonType.RoundedRect);
            createAccount.SetTitle("Create your account", UIControlState.Normal);
            createAccount.Frame = new RectangleF(50, 500, 300, 50);
            createAccount.BackgroundColor = UIColor.Blue;
            Add(createAccount);



            var set = this.CreateBindingSet();
            set.Bind(textEditFirst).To(vm => vm.FirstName); // Bind the entry with prop
            set.Bind(textEditSecond).To(vm => vm.LastName); // Bind the entry with prop
            set.Bind(labelFull).To(vm => vm.FullName); // Bind the label with prop
            set.Bind(resetButton).To(vm => vm.DeleteCommand);
            set.Bind(createAccount).To(vm => vm.CreateAccountCommand);

            set.Apply();
        }

        public override void DidReceiveMemoryWarning()

        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

