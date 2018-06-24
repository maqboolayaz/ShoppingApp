using System;
using System.Collections.Generic;
using System.Text;

namespace AppConstants
{
    public class BaseConstants
    {

        public static ServerTenant BuildTenant = ServerTenant.DEV;
        public static WorkEnvironment Environ = WorkEnvironment.Testing;

        public enum ServerTenant
        {
            DEV,
            QA,
            STAGING,
            PROD
        }

        public enum WorkEnvironment
        {
            Testing,
            Live
        }
    }
}
