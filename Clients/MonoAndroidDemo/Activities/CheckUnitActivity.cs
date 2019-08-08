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
using MonoAndroidDemo.Services;
using MonoAndroidDemo.Classes;


namespace MonoAndroidDemo.Activities
{
    [Activity(Label = "CheckUnitActivity")]
    public class CheckUnitActivity : Activity
    {
        EditText searchERP;
        Android.Widget.Button buttonCheck;
        Android.Widget.Button buttonShow;
        TextView textBarcode;
        TextView textERP;
        TextView textBrand;
        TextView textInspector;
        TextView textInspectionDate;
        public string searchedERP { get; set; }

        RetrievedClass retrieved = RetrievedClass.CreateRetrievedClass();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            this.SetContentView(Resource.Layout.SearchLayout);

            SearchService rservice = new SearchService();

            searchERP = this.FindViewById<EditText>(Resource.Id.textsearchERP);
            buttonCheck = this.FindViewById<Button>(Resource.Id.buttonCheck);
            buttonShow = this.FindViewById<Button>(Resource.Id.buttonShow);
            textBarcode = this.FindViewById<TextView>(Resource.Id.textBarcode);
            textERP = this.FindViewById<TextView>(Resource.Id.textERP);
            textBrand = this.FindViewById<TextView>(Resource.Id.textBrand);
            textInspector = this.FindViewById<TextView>(Resource.Id.textInspector);
            textInspectionDate = this.FindViewById<TextView>(Resource.Id.textInspectionDate);

            buttonCheck.Click += async (sender, e) =>
            {
                this.RunOnUiThread(() => { searchedERP = this.searchERP.Text; });

                await rservice.Retrieve(searchedERP);

            };
            buttonShow.Click += (sender, e) =>
            {
                this.textBarcode.Text = "Unit Barcode: " + rservice.BarcodeScan;
                this.textERP.Text = "Unit ERP: " + rservice.UnitERP;
                this.textBrand.Text = "Unit Brand: " + rservice.UnitBrand;
                this.textInspector.Text = "Inspected by: " + rservice.InspectorName;
                this.textInspectionDate.Text = "Inspected on: " + rservice.InspectionDate;

            };
        }
    }
}
