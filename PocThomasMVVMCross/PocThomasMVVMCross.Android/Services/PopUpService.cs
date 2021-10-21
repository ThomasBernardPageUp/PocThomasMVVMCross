using Android.App;
using Android.Views;
using Android.Widget;
using Plugin.CurrentActivity;
using PocThomasMVVMCross.Core.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PocThomasMVVMCross.Android.Services
{

    public class PopUpService : IPopUpService
    {
        public TaskCompletionSource<string> TaskCompletionSourceMail { get; set; }

        public async Task ClosePopUp()
        {
            throw new NotImplementedException();
        }

        public async Task<string> ShowPopUp(string title, string message, string entryContent)
        {
            TaskCompletionSourceMail = new TaskCompletionSource<string>();
            try
            {
                LayoutInflater layoutInflater = LayoutInflater.FromContext(CrossCurrentActivity.Current.Activity);
                View alertView = layoutInflater.Inflate(Resource.Layout.CustomDialog, null);
                AlertDialog alertDialog = new AlertDialog.Builder(CrossCurrentActivity.Current.Activity).Create();


                TextView textViewMessage = (TextView)alertView.FindViewWithTag("textViewMessage");
                textViewMessage.Text = message;

                TextView textViewTitle = (TextView)alertView.FindViewWithTag("textViewTitle");
                textViewTitle.Text = title;

                EditText editTextContent = (EditText)alertView.FindViewWithTag("editTextContent");
                editTextContent.Text = entryContent;

                Button buttonOk = (Button)alertView.FindViewWithTag("buttonOk");
                buttonOk.Click += delegate  {
                    TaskCompletionSourceMail.SetResult(editTextContent.Text);
                    alertDialog.Dismiss();
                };
                 



                alertDialog.SetView(alertView);
                alertDialog.Show();

                //new Thread(() =>
                //{
                //    while (alertDialog.IsShowing)
                //    {

                //    }
                //    TaskCompletionSourceMail.SetResult(textViewTitle.Text);

                //}).Start();
                

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                TaskCompletionSourceMail.SetException(ex);
            }
            return await TaskCompletionSourceMail.Task;

        }
    }
}