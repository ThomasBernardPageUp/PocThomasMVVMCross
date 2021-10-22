using System;
using System.Threading.Tasks;
using PocThomasMVVMCross.Core.Interfaces;
using UIKit;

namespace PocThomasMVVMCross.Ios.Services
{
    public class PopUpService : IPopUpService
    {
        private UIAlertView _alertView = new UIAlertView();
        public TaskCompletionSource<string> TaskCompletionSourceMail { get; set; }


        public PopUpService()
        {
            _alertView.AlertViewStyle = UIAlertViewStyle.PlainTextInput;
            
        }

        public async Task ClosePopUp()
        {
            TaskCompletionSourceMail.SetResult(_alertView.GetTextField(0).Text);
        }

        public async Task<string> ShowPopUp(string title, string message, string entryContent)
        {
            TaskCompletionSourceMail = new TaskCompletionSource<string>();

            try
            {
                _alertView.Title = title;
                _alertView.Message = message;
                _alertView.GetTextField(0).Text = entryContent;

                _alertView.AddButton("Ok");
                _alertView.Dismissed += (sender, args) => ClosePopUp();
                _alertView.Show();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                TaskCompletionSourceMail.SetException(ex);
            }

            return await TaskCompletionSourceMail.Task;

        }

    }
}
