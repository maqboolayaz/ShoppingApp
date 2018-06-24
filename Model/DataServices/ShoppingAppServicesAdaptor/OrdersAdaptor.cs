using AppComponentModels;
using AppConstants;
using AppInterfaces;
using HttpClientHandler;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppServicesAdaptor
{
    public class OrdersAdaptor : IOrdersAdaptor
    {
        private readonly IHttpServicesHandler appHttpServicesHandler;

        public OrdersAdaptor(IHttpServicesHandler appHttpServicesHandler)
        {
            this.appHttpServicesHandler = appHttpServicesHandler;
        }

        public async Task<List<OrdersDTO>> GetOrdersListAsync()
        {

            IEnumerable<KeyValuePair<string, string>> data = new[] {
                new KeyValuePair<string,string>("configKey","5ae11d19-b3ff-4254-a5e3-1c1da191ca84"),
                new KeyValuePair<string,string>("userId", "bb217b61-ce89-40fc-93cb-396fa57d82db")
            };
            var content = new FormUrlEncodedContent(data);

            content.Headers.Clear();
            content.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            string url = ShoppingAppAPI.LiveBaseUri + ShoppingAppAPI.GetAllOrders;
            url = "https://p8meq.mocklab.io/orders";
            if (BaseConstants.Environ == BaseConstants.WorkEnvironment.Live)
            {
                List<OrdersDTO> ordersList = await appHttpServicesHandler.PostAsync<List<OrdersDTO>>(new Uri(url), content);
                return ordersList;
            }
            else
            {
                List<OrdersDTO> ordersList = appHttpServicesHandler.PostTestAsync<List<OrdersDTO>>(new Uri(url), content);
                return ordersList;
            }
        }

        public async Task<OrdersDTO> ProcessOrderAsync(string orderId)
        {

            IEnumerable<KeyValuePair<string, string>> data = new[] {
                new KeyValuePair<string,string>("configKey","5ae11d19-b3ff-4254-a5e3-1c1da191ca84"),
                new KeyValuePair<string,string>("userId", "bb217b61-ce89-40fc-93cb-396fa57d82db"),
                new KeyValuePair<string,string>("orderId", orderId),
            };
            var content = new FormUrlEncodedContent(data);
            content.Headers.Clear();
            content.Headers.Add("Content-Type", "application/json");
            string url = string.Format(ShoppingAppAPI.LiveBaseUri + ShoppingAppAPI.ProcessOrder, orderId);

            OrdersDTO currentOrder = await appHttpServicesHandler.PostAsync<OrdersDTO>(new Uri(url), content);
            return currentOrder;
        }
    }
}
