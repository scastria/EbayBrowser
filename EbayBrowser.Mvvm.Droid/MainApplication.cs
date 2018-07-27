using System;
using Android.App;
using Android.Runtime;
using EbayBrowser.Mvvm.Shared;
using MvvmCross.Platforms.Android.Core;
using MvvmCross.Platforms.Android.Views;

namespace EbayBrowser.Mvvm.Droid
{
    [Application(AllowBackup = true, Label = "Mvvm Ebay", Theme = "@android:style/Theme.Material.Light", Icon = "@mipmap/icon")]
    public class MainApplication : MvxAndroidApplication<MvxAndroidSetup<App>, App>
    {
        public MainApplication(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }
    }
}
