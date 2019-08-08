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
using MonoAndroidDemo.Activities;
using MonoAndroidDemo;
using MonoAndroidDemo.Classes;
using Xamarin.Forms;

namespace MonoAndroidDemo
{
    [Activity(Label = "UnitInfoActivity")]
    public class UnitInfoActivity : Activity
    {
        public static string Erp = String.Empty;
        public static UploadService service = new UploadService();
        public static string currentunit { get; set; }
        EditText textBarcode;
        EditText textERP;
        EditText textBrand;
        Android.Widget.Button buttonUpload;
        TextView textInspector;
        TextView textInspectionDate;

        UnitEntity unit = new UnitEntity("unittest", "default");



        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            this.SetContentView(Resource.Layout.UnitInfoLayout);

            textBarcode = this.FindViewById<EditText>(Resource.Id.textBarcode);
            textERP = this.FindViewById<EditText>(Resource.Id.textERP);
            textBrand = this.FindViewById<EditText>(Resource.Id.textBrand);
            buttonUpload = this.FindViewById<Android.Widget.Button>(Resource.Id.buttonUpload);
            textInspector = this.FindViewById<TextView>(Resource.Id.textInspector);
            textInspectionDate = this.FindViewById<TextView>(Resource.Id.textInspectionDate);

            this.textInspector.Text = "Inspected By: " + LoginActivity.currentUser.Name;
            this.textInspectionDate.Text = "Inspected On: " + LoginActivity.currentUser.Date.ToString();

            buttonUpload.Click += async (sender, e) =>
            {

                this.RunOnUiThread(() => { Erp = this.textERP.Text; });
                this.RunOnUiThread(() => { unit.BardcodeScan = this.textBarcode.Text; });
                this.RunOnUiThread(() => { unit.UnitERP = this.textERP.Text; });
                this.RunOnUiThread(() => { unit.UnitBrand = this.textBrand.Text; });

                unit.InspectorName = LoginActivity.currentUser.Name;
                unit.InspectionDate = LoginActivity.currentUser.Date.ToString();

                unit.RowKey = Erp;
                currentunit = unit.RowKey;

                
                await service.Upload(unit);

                StartActivity(typeof(CheckUnitActivity));

            };
        }
    }
}
