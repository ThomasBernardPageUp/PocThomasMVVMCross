using Android.App;
using Android.Views;
using Android.Widget;
using Plugin.CurrentActivity;
using PocThomasMVVMCross.Core.Interfaces;
using System;
using System.Threading.Tasks;

namespace PocThomasMVVMCross.Android.Services
{

    public class PopUpService : IPopUpService
    {
        public async Task ClosePopUp()
        {
            throw new NotImplementedException();
        }

        public async Task ShowPopUp(string title, string message, string entryContent)
        {
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

                alertDialog.SetView(alertView);
                alertDialog.Show();

                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}