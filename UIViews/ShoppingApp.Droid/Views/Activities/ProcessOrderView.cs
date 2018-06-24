using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using MvvmCross.Platforms.Android.Views;
using ShoppingApp.Core.ViewModels;

namespace ShoppingApp.Droid.Views.Activities
{
    [Activity(Label = "Processing Order")]
    public class ProcessOrderView : MvxActivity
    {
        private ProcessOrderViewModel ProcessOrderViewModel => (ProcessOrderViewModel)ViewModel;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ProcessOrderView);

            FindViewById<TextView>(Resource.Id.OrderId).Text = "OrderId : " + ProcessOrderViewModel.ProcessOrder.OrderId;
            FindViewById<TextView>(Resource.Id.OrderNumber).Text = "OrderNumber : " + ProcessOrderViewModel.ProcessOrder.OrderNumber.ToString();
            FindViewById<TextView>(Resource.Id.ProductName).Text = "ProductName : " + ProcessOrderViewModel.ProcessOrder.ProductName;
            FindViewById<TextView>(Resource.Id.TargetQtyBuom).Text = "TargetQtyBuom: " + ProcessOrderViewModel.ProcessOrder.TargetQtyBuom.ToString();
            FindViewById<TextView>(Resource.Id.TargetSize).Text = "TargetSize : " + ProcessOrderViewModel.ProcessOrder.TargetSize;
            FindViewById<TextView>(Resource.Id.TargetDeliveryAt).Text = "TargetDeliveryAt : " + ProcessOrderViewModel.ProcessOrder.TargetDeliveryAt.ToString();
            FindViewById<TextView>(Resource.Id.TargetPsa).Text = "TargetPsa : " + ProcessOrderViewModel.ProcessOrder.TargetPsa;
            FindViewById<TextView>(Resource.Id.TargetPsaBin).Text = "TargetPsaBin : " + ProcessOrderViewModel.ProcessOrder.TargetPsaBin;
        }
    }
}