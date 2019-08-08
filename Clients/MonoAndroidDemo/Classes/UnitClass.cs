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
//using Microsoft.Azure.Cosmos.Table;
using Xamarin.Forms;

namespace MonoAndroidDemo
{
    public class UnitEntity : TableEntity
    {
        public UnitEntity(string unittest, string UnitERP)
        {
            this.PartitionKey = unittest;
            this.RowKey = UnitERP;
        }

        public UnitEntity() { }

        public string BardcodeScan { get; set; }
        public string UnitERP { get; set; }
        public string UnitBrand { get; set; }
        public string InspectionDate { get; set; }
        public string InspectorName { get; set; }

        public CloudStorageAccount storageAccount = new CloudStorageAccount(
            new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials(
           "usernametest", "18DZ4BYYQK58WPqoVnOrb6qg2t4a1cNQC+tJBEMP558xB3+keXHKFW0eNRBInH+hhA1BhOIuA99b1YcVPlAGbQ=="), true);
    }
}