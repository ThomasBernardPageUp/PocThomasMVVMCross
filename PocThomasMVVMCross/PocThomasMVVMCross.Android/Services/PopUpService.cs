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

        private AlertDialog _alertDialog;
        private TextView _textViewMessage;
        private TextView _textViewTitle;
        private EditText _editTextContent;
        private Button _buttonClose;


        public async Task ClosePopUp()
        {
            TaskCompletionSourceMail.SetResult(_editTextContent.Text ?? "");
            _alertDialog.Dismiss();
        }

        public async Task<string> ShowPopUp(string title, string message, string entryContent)
        {
            TaskCompletionSourceMail = new TaskCompletionSource<string>();

            try
            {
                LayoutInflater layoutInflater = LayoutInflater.FromContext(CrossCurrentActivity.Current.Activity);
                View alertView = layoutInflater.Inflate(Resource.Layout.CustomDialog, null);
                _alertDialog = new AlertDialog.Builder(CrossCurrentActivity.Current.Activity).Create();
                _alertDialog.DismissEvent += delegate { 
                    if(TaskCompletionSourceMail.Task.Status == TaskStatus.WaitingForActivation)
                        TaskCompletionSourceMail.SetException(new Exception("AlertDialog closed")); 
                };


                _textViewMessage = (TextView)alertView.FindViewWithTag("textViewMessage");
                _textViewMessage.Text = message;

                _textViewTitle = (TextView)alertView.FindViewWithTag("textViewTitle");
                _textViewTitle.Text = title;

                _editTextContent = (EditText)alertView.FindViewWithTag("editTextContent");
                _editTextContent.Text = entryContent;

                _buttonClose = (Button)alertView.FindViewWithTag("buttonOk");
                _buttonClose.Click += delegate  { ClosePopUp(); };

                _alertDialog.SetView(alertView);
                _alertDialog.Show();

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