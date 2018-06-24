using AppComponentModels;
using MvvmCross.ViewModels;

namespace ShoppingApp.Core.ViewModels
{
    public class ProcessOrderViewModel : MvxViewModel<OrdersDTO>
    {
        public OrdersDTO ProcessOrder { get; set; }
        public override void Prepare(OrdersDTO processedOrder)
        {
            ProcessOrder = processedOrder;
        }
    }
}
