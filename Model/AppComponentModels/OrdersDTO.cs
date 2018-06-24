using AppComponentModels.Helper;
using System;

namespace AppComponentModels
{
    public class OrdersDTO
    {
        public string OrderId { get; set; }
        public int OrderNumber { get; set; }
        public string ProductName { get; set; }
        public int TargetQtyBuom { get; set; }
        public string TargetSize { get; set; }
        public DateTime TargetDeliveryAt { get; set; }
        public string TargetPsa { get; set; }
        public string TargetPsaBin { get; set; }

        public string TargetDeliveryDate
        {
            get
            {
                return $"{DateTimeParser.GetDateString(TargetDeliveryAt)}";
            }
        }
    }
}
