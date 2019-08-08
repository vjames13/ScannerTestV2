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

[assembly: Dependency(typeof(UploadService))]
namespace MonoAndroidDemo.Services
{
    public class UploadService
    {


        CloudStorageAccount storageupAccount = new CloudStorageAccount(
              new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials(
                  "usernametest", "18DZ4BYYQK58WPqoVnOrb6qg2t4a1cNQC+tJBEMP558xB3+keXHKFW0eNRBInH+hhA1BhOIuA99b1YcVPlAGbQ=="), true);

        public async Task Upload(UnitEntity entity)
        {
            CloudTableClient tableuploadClient = storageupAccount.CreateCloudTableClient();

            CloudTable unitTable = tableuploadClient.GetTableReference("unitTableTest3");

            //await unitTable.CreateIfNotExistsAsync();

            TableOperation insertOperation = TableOperation.Insert(entity);

            await unitTable.ExecuteAsync(insertOperation);
        }
    }
}