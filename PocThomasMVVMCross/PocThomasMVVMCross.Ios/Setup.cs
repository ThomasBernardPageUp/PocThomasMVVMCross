using System;
using MvvmCross;
using MvvmCross.Platforms.Ios.Core;
using MvvmCross.ViewModels;
using PocThomasMVVMCross.Core;
using PocThomasMVVMCross.Core.Interfaces;
using PocThomasMVVMCross.Ios.Services;

namespace PocThomasMVVMCross.Ios
{
    public class Setup : MvxIosSetup<App>
    {
        protected override void InitializeFirstChance()
        {
            Mvx.IoCProvider.RegisterSingleton<IPopUpService>(new PopUpService());
            base.InitializeFirstChance();
        }
    }
}
