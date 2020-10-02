using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross.ViewModels;
using TinyCollege.Core.ViewModels;

namespace TinyCollege.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            RegisterAppStart<GuestBookViewModel>();
        }
    }
}