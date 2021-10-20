using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using PocThomasMVVMCross.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocThomasMVVMCross.Android.Services
{

    public class PopUpService : IPopUpService
    {
        public async Task ClosePopUp()
        {
            throw new NotImplementedException();
        }

        public async Task ShowPopUp()
        {
            try
            {
                // LayoutInflater layoutInflater = LayoutInflater.FromContext(Application.Context);
                // var editText = layoutInflater.Inflate(Resource.Layout.CustomDialog, null);
                var ad = new AlertDialog.Builder(Application.Context).Create();
                ad.SetTitle("HA");
                // ad.SetView(editText);
                ad.Show();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
           
        }
    }
}