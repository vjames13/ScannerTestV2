using System;
using System.ComponentModel;
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
using MonoAndroidDemo.Classes;
using Xamarin.Forms;

namespace MonoAndroidDemo
{
    [Activity(Label = "Login:", MainLauncher = true)]

    public class LoginActivity : Activity
    {
        EditText textUsername;
        EditText textPassword;
        Android.Widget.Button buttonLogin;
        TextView textLoginInfo;

        public static CurrentUserClass currentUser = new CurrentUserClass();

        public AzureService service = new AzureService();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            this.SetContentView(Resource.Layout.LoginActivityLayout);

            textUsername = this.FindViewById<EditText>(Resource.Id.textUsername);
            textPassword = this.FindViewById<EditText>(Resource.Id.textPassword);
            buttonLogin = this.FindViewById<Android.Widget.Button>(Resource.Id.buttonLogin);
            textLoginInfo = this.FindViewById<TextView>(Resource.Id.textLoginInfo);

            this.Title = "User Login";



            buttonLogin.Click += async (sender, e) =>
            {
                var user = string.Empty;
                var password = string.Empty;

                this.RunOnUiThread(() => { user = this.textUsername.Text; });
                this.RunOnUiThread(() => { password = this.textPassword.Text; });


                //AzureService service = new AzureService();
                await service.Initialize(user, password);

                if (this.textUsername.Text == service.textUsername)
                {
                    if (this.textPassword.Text == service.textPassword)
                    {
                        this.textLoginInfo.Text = "User Found!";

                        currentUser.Name = service.textName;
                        currentUser.Date = DateTime.Now;

                        this.textLoginInfo.Text = "Succesfully Logged in!";
                        StartActivity(typeof(DecoderActivity));
                    }
                    else
                    {
                        this.textLoginInfo.Text = "Invalid Password";
                    }
                }
                else
                {
                    this.textLoginInfo.Text = "Unrecognized Username";
                }
            };

        }
    }

}