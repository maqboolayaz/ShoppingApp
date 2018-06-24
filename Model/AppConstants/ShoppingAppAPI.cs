using System;
using System.Collections.Generic;
using System.Text;

namespace AppConstants
{
    public class ShoppingAppAPI : BaseConstants
    {

        public const string GetAllOrders = "api/Orders/GetAllOrders";
        public const string ProcessOrder = "api/Orders/ProcessOrder?orderId={0}";

        public static string LiveBaseUri
        {
            get
            {
                switch (BuildTenant)
                {
                    case ServerTenant.STAGING:
                        return "http://ma000xsi:8090/ShoppingAppStageAPIs/";
                    case ServerTenant.DEV:
                        return "http://me000xsi:9090/ShoppingAppDevAPIs/";
                    case ServerTenant.QA:
                        return "http://me000xsi:9090/ShoppingAppUATAPIs/";
                    case ServerTenant.PROD:
                        return "http://ma000xsi:8090/ShoppingAppProdAPIs/";
                    default:
                        return "http://me000xsi:9090/ShoppingAppDevAPIs/";
                }
            }
        }
    }
}
