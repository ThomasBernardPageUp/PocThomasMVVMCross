using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PocThomasMVVMCross.Core.Interfaces
{
    public interface IPopUpService
    {
        TaskCompletionSource<string> TaskCompletionSourceMail { get; set; }

        Task<string> ShowPopUp(string title, string message, string entryContent);
        Task ClosePopUp();
    }
}
