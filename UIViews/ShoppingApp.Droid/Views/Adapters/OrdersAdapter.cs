using Android.App;
using Android.Content.Res;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using AppComponentModels;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Binding.Views;
using ShoppingApp.Droid.Utilities.Interfaces;
using System;
using System.Collections.Generic;

namespace ShoppingApp.Droid.Views.Adapters
{
    public class OrdersAdapter : MvxAdapter
    {
        private List<OrdersDTO> ordersList;
        private readonly Activity context;
        private readonly IListItemClickListener<OrdersDTO> listItemClickListener;

        /// <summary>
        /// Constructor of Orders Adaptor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="ordersList"></param>
        public OrdersAdapter(Activity context, IMvxAndroidBindingContext bindingContext, List<OrdersDTO> ordersList, IListItemClickListener<OrdersDTO> listItemClickListener) : base(context, bindingContext)
        {
            this.context = context;
            this.ordersList = ordersList;
            this.listItemClickListener = listItemClickListener;
        }

        /// <summary>
        /// Gives the count of Orders List
        /// </summary>
        public override int Count => ordersList.Count;

        /// <summary>
        /// Called on Creation of Each Cell View of Orders List
        /// </summary>
        /// <param name="position"></param>
        /// <param name="convertView"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView ?? context.LayoutInflater.Inflate(Resource.Layout.OrderedItem, null);
            view.FindViewById<TextView>(Resource.Id.OrderNumber).Text =  "#" + ordersList[position].OrderNumber + " - ";
            view.FindViewById<TextView>(Resource.Id.TargetQtyBuom).Text = ordersList[position].TargetQtyBuom + " x ";
            view.FindViewById<TextView>(Resource.Id.ProductName).Text = ordersList[position].ProductName + " - ";
            view.FindViewById<TextView>(Resource.Id.TargetSize).Text = ordersList[position].TargetSize;
            view.FindViewById<TextView>(Resource.Id.TargetDeliveryAt).Text = "Anlieferung: " + ordersList[position].TargetDeliveryDate + " - ";
            view.FindViewById<TextView>(Resource.Id.TargetPsa).Text = ordersList[position].TargetPsa + " - ";
            view.FindViewById<TextView>(Resource.Id.TargetPsaBin).Text = ordersList[position].TargetPsaBin;

            var targetTime = ordersList[position].TargetDeliveryAt;
            System.Globalization.CultureInfo.CurrentCulture.ClearCachedData();
            var currentTime = DateTime.Now;
            var targetTimeDiff = currentTime.Subtract(targetTime).TotalMinutes;
            if (targetTimeDiff > 0 && targetTimeDiff < 15)
            {
                view.FindViewById<TextView>(Resource.Id.TargetDeliveryAt).SetTextColor(Color.Red);
                view.FindViewById<ImageView>(Resource.Id.OrderImage).SetBackgroundColor(Color.Red);
            }

            view.Click += (object sender, EventArgs e) =>
            {
                listItemClickListener.ItemSelected(ordersList[position]);
            };
            return view;
        }
    }
}