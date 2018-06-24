using AppComponentModels;
using AppInterfaces;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace ShoppingApp.Core.ViewModels
{
    public class OrdersViewModel : MvxViewModel
    {
        private readonly IOrdersAdaptor ordersAdaptor;
        private readonly IMvxNavigationService NavigationService;
        public List<OrdersDTO> OrdersList { get; set; }

        public ICommand ProcessOrderCommand => new MvxCommand<OrdersDTO>(ProcessOrderExecution);

        /// <summary>
        /// Constructor of Orders View Model
        /// </summary>
        /// <param name="ordersAdaptor"></param>
        public OrdersViewModel(IOrdersAdaptor ordersAdaptor)
        {
            NavigationService = Mvx.Resolve<IMvxNavigationService>();
            this.ordersAdaptor = ordersAdaptor;
            GetOrdersData();
        }
        public OrdersViewModel()
        {

        }
        /// <summary>
        /// Retrieves the Orders Data
        /// </summary>
        private async void GetOrdersData()
        {
            try
            {
                var response =
                    await ordersAdaptor.GetOrdersListAsync();
                if (response == null) return;
                OrdersList = response.OrderBy(x => x.TargetDeliveryAt).ToList();
                RaisePropertyChanged(() => OrdersList);
            }
            catch (Exception ex)
            {
                throw new Exception("Data Not Found");
            }
        }

        /// <summary>
        /// Process the Execution of Single Order
        /// </summary>
        private void ProcessOrderExecution(OrdersDTO selectedOrder)
        {
            NavigationService.Navigate(typeof(ProcessOrderViewModel), selectedOrder);
        }
    }
}
