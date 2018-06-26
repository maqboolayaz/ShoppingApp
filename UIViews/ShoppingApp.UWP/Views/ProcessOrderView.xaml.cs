using MvvmCross.Platforms.Uap.Views;
using MvvmCross.ViewModels;
using ShoppingApp.Core.ViewModels;

namespace ShoppingApp.UWP.Views
{
    [MvxViewFor(typeof(ProcessOrderViewModel))]
    public sealed partial class ProcessOrderView : MvxWindowsPage
    {
        /// <summary>
        /// Constructor of ProcessOrder View
        /// </summary>
        public ProcessOrderView()
        {
            InitializeComponent();
        }
    }
}
