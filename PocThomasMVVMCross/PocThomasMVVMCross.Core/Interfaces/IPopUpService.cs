using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PocThomasMVVMCross.Core.Interfaces
{
    public interface IPopUpService
    {
        Task ShowPopUp();
        Task ClosePopUp();
    }
}
