using ShoppingApp.Core.ViewModels;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using MvvmCross;
using AppInterfaces;
using ShoppingAppServicesAdaptor;
using HttpClientHandler;

namespace ShoppingApp.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            Mvx.RegisterSingleton<IHttpServicesHandler>(() => new AppHttpServicesHandler());
            Mvx.RegisterSingleton<IOrdersAdaptor>(() => new OrdersAdaptor(new AppHttpServicesHandler()));
            RegisterAppStart<OrdersViewModel>();
        }
    }
}