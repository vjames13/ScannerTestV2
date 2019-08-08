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

[assembly: Dependency(typeof(AzureService))]
namespace MonoAndroidDemo.Services
{
    public class AzureService
    {

        public string textUsername { get; set; }
        public string textPassword { get; set; }
        public string textName { get; set; }

        CloudStorageAccount storageAccount = new CloudStorageAccount(
              new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials(
                  "usernametest", "18DZ4BYYQK58WPqoVnOrb6qg2t4a1cNQC+tJBEMP558xB3+keXHKFW0eNRBInH+hhA1BhOIuA99b1YcVPlAGbQ=="), true);


        public async Task Initialize(string username, string password)
        {

            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            CloudTable userTable = tableClient.GetTableReference("userTable");

            TableOperation retrieveOperation = TableOperation.Retrieve<UserEntity>("test", username);

            TableResult retrievedResult = await userTable.ExecuteAsync(retrieveOperation);

            if (retrievedResult.Result != null)
            {
                textUsername = ((UserEntity)retrievedResult.Result).RowKey;
                textPassword = ((UserEntity)retrievedResult.Result).Password;
                textName = ((UserEntity)retrievedResult.Result).Name;

                

            }

            else
            {
                System.Diagnostics.Debug.WriteLine("The password could not be retrieved.");
            }

        }
    }
}