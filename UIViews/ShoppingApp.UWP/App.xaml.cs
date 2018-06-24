using MvvmCross.Platforms.Uap.Core;
using MvvmCross.Platforms.Uap.Views;

namespace ShoppingApp.UWP
{
    public sealed partial class App
    {
        public App()
        {
            InitializeComponent();
        }
    }

    public abstract class ShoppingApp : MvxApplication<MvxWindowsSetup<global::ShoppingApp.Core.App>, global::ShoppingApp.Core.App>
    {
    }
}