using AppComponentModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppInterfaces
{
    public interface IOrdersAdaptor
    {
        Task<List<OrdersDTO>> GetOrdersListAsync();
    }
}
