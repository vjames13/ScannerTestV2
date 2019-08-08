using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

using ZXing;
using ZXing.Common;
using MonoAndroidDemo.Services;

namespace MonoAndroidDemo
{
    [Activity(Label = "TypeSelectionActivity")]
    public class TypeSelectionActivity : Activity
    {
        Button buttonUnit;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            this.SetContentView(Resource.Layout.TypeSelectionLayout);

            this.Title = "User Login";

            buttonUnit = this.FindViewById<Android.Widget.Button>(Resource.Id.buttonUnit);

            this.buttonUnit.Click += (sender, e) =>
            {
                StartActivity(typeof(UnitInfoActivity));
            };
        }
    }
}