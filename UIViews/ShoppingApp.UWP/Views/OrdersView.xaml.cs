using AppComponentModels;
using MvvmCross.Platforms.Uap.Views;
using MvvmCross.ViewModels;
using ShoppingApp.Core.ViewModels;
using Windows.UI.Xaml.Controls;

namespace ShoppingApp.UWP.Views
{
    [MvxViewFor(typeof(OrdersViewModel))]
    public sealed partial class OrdersView : MvxWindowsPage
    {
        private OrdersViewModel PageViewModel { get { return (OrdersViewModel)ViewModel; } }
        /// <summary>
        /// Constructor of Order View
        /// </summary>
        public OrdersView()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Click Event for Orders View Item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OrdersView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var item = e.ClickedItem as OrdersDTO;
            if (item != null)
            {
                PageViewModel.ProcessOrderCommand.Execute(item);
            }
        }
    }
}
