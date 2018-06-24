using Android.App;
using Android.OS;
using Android.Widget;
using AppComponentModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Binding.Views;
using MvvmCross.Platforms.Android.Views;
using ShoppingApp.Core.ViewModels;
using ShoppingApp.Droid.Utilities.Interfaces;
using ShoppingApp.Droid.Views.Adapters;
using static Android.Widget.AdapterView;

namespace ShoppingApp.Droid.Views.Activities
{
    [Activity (Label = "Orders")]
    public class OrdersView : MvxActivity, IListItemClickListener<OrdersDTO>
    {
        private MvxListView ordersList;
        private OrdersAdapter ordersAdapter;
        private OrdersViewModel OrdersViewModel => (OrdersViewModel)ViewModel;

        /// <summary>
        /// Called on Creation of View
        /// </summary>
        /// <param name="savedInstanceState"></param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.OrdersView);

            ordersList = FindViewById<MvxListView>(Resource.Id.orders_listview);

            BindOrdersList();

            ordersAdapter = new OrdersAdapter(this , (IMvxAndroidBindingContext)BindingContext, OrdersViewModel.OrdersList, this);
            ordersList.Adapter = ordersAdapter;
        }

        /// <summary>
        /// Binds the Orders List
        /// </summary>
        private void BindOrdersList()
        {
            var set = this.CreateBindingSet<OrdersView, OrdersViewModel>();
            set.Bind(ordersList).For(p => p.ItemsSource).To(vm => vm.OrdersList);
            set.Apply();
        }
        /// <summary>
        /// Called when the orders list's item is selected
        /// </summary>
        /// <param name="item"></param>
        public void ItemSelected(OrdersDTO item)
        {
            OrdersViewModel.ProcessOrderCommand.Execute(item);
        }
    }
}