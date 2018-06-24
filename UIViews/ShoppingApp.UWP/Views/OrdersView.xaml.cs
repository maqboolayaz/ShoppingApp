using AppComponentModels;
using MvvmCross.Platforms.Uap.Views;
using MvvmCross.ViewModels;
using ShoppingApp.Core.ViewModels;
using System.Collections.Generic;

namespace ShoppingApp.UWP.Views
{
    [MvxViewFor(typeof(OrdersViewModel))]
    public sealed partial class OrdersView : MvxWindowsPage
    {
        public List<OrdersDTO> OrdersList { get; set; }
        public OrdersView()
        {
            InitializeComponent();
            this.DataContext = new OrdersViewModel();
        }
    }
}
