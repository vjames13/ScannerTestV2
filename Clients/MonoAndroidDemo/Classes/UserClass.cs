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
using System.Threading.Tasks;


namespace MonoAndroidDemo.Model
{
    public class UserEntity : TableEntity
    {
        public UserEntity(string testkey, string username)
        {
            this.PartitionKey = testkey;
            this.RowKey = username;
        }

        public UserEntity() { }

        public string Name { get; set; }

        public string Password { get; set; }
       

        public CloudStorageAccount storageAccount = new CloudStorageAccount(
               new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials(
                   "usernametest", "18DZ4BYYQK58WPqoVnOrb6qg2t4a1cNQC+tJBEMP558xB3+keXHKFW0eNRBInH+hhA1BhOIuA99b1YcVPlAGbQ=="), true);


    }
}