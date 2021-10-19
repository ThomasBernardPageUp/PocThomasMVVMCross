using MvvmCross.IoC;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PocThomasMVVMCross.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes().EndingWith("Service").AsInterfaces().RegisterAsLazySingleton();

            RegisterAppStart<ViewModels.FirstViewModel>();
            // RegisterNavigationServiceAppStart<ViewModels.FirstViewModel>();
        }
    }
}
