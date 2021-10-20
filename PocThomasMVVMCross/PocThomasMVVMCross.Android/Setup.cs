using Android.App;
using Android.Content;
using Android.Runtime;
using MvvmCross;
using MvvmCross.Platforms.Android.Core;
using MvvmCross.Platforms.Android.Views;
using MvvmCross.ViewModels;
using PocThomasMVVMCross.Android.Services;
using PocThomasMVVMCross.Core;
using PocThomasMVVMCross.Core.Interfaces;
using System;

namespace PocThomasMVVMCross.Android
{
    [Application]
    public class Setup : MvxAndroidSetup<App>
    {
        protected override void InitializeFirstChance()
        {
            Mvx.IoCProvider.RegisterSingleton<IPopUpService>(new PopUpService());
            base.InitializeFirstChance();
        }
    }

    
}