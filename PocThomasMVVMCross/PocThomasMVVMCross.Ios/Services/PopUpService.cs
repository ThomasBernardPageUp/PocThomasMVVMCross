using System;
using System.Threading.Tasks;
using PocThomasMVVMCross.Core.Interfaces;
using UIKit;

namespace PocThomasMVVMCross.Ios.Services
{
    public class PopUpService : IPopUpService
    {
        private UIAlertView _alertView = new UIAlertView();

        public PopUpService()
        {
            _alertView.Title = "Alerte";
            _alertView.Message = "Message de l'alerte";
            _alertView.AddButton("Close");
        }

        public async Task ClosePopUp()
        {
        }

        public async Task ShowPopUp()
        {
            try
            {
                _alertView.Show();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
    }
}
