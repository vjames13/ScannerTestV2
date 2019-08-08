using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MonoAndroidDemo;
using MonoAndroidDemo.Model;
using MonoAndroidDemo.Services;
using MonoAndroidDemo.Classes;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
//using Microsoft.Azure.Cosmos.Table;
using Xamarin.Forms;

[assembly: Dependency(typeof(SearchService))]
namespace MonoAndroidDemo.Services
{
    public class SearchService
    {

        public string UnitERP { get; set; }
        public string BarcodeScan { get; set; }
        public string UnitBrand { get; set; }
        public string InspectionDate { get; set; }
        public string InspectorName { get; set; }

        CloudStorageAccount storagereAccount = new CloudStorageAccount(
             new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials(
                 "usernametest", "18DZ4BYYQK58WPqoVnOrb6qg2t4a1cNQC+tJBEMP558xB3+keXHKFW0eNRBInH+hhA1BhOIuA99b1YcVPlAGbQ=="), true);
        public async Task Retrieve(string ERP)
        {

            CloudTableClient tableClient = storagereAccount.CreateCloudTableClient();

            CloudTable userTable = tableClient.GetTableReference("unitTestTable3");

            TableOperation retrieveOperation = TableOperation.Retrieve<UnitEntity>("test", ERP);

            TableResult retrievedResult = await userTable.ExecuteAsync(retrieveOperation);

            if (retrievedResult.Result != null)
            {
                UnitERP = ((UnitEntity)retrievedResult.Result).RowKey;
                UnitBrand = ((UnitEntity)retrievedResult.Result).UnitBrand;
                BarcodeScan = ((UnitEntity)retrievedResult.Result).BardcodeScan;
                InspectionDate = ((UnitEntity)retrievedResult.Result).InspectionDate;
                InspectorName = ((UnitEntity)retrievedResult.Result).InspectorName;
            }

            else
            {
                System.Diagnostics.Debug.WriteLine("The password could not be retrieved.");
            }

        }

    }
}