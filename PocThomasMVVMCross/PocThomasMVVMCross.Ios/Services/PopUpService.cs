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
        }

        public async Task<string> ShowPopUp(string title, string message, string entryContent)
        {
            TaskCompletionSource<string> taskCompletionSourceMail = new TaskCompletionSource<string>();

            try
            {
                _alertView.Title = title;
                _alertView.Message = message;
                _alertView.GetTextField(0).Text = entryContent;

                _alertView.AddButton("Ok");


                _alertView.Show();
                }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                taskCompletionSourceMail.SetException(ex);
            }

            return await taskCompletionSourceMail.Task;

        }
    }
}
