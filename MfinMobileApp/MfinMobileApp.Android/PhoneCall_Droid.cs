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
using MfinMobileApp.Interfaces;
using MfinMobileApp.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(PhoneCall_Droid))]
namespace MfinMobileApp.Droid
{
    class PhoneCall_Droid : IPhoneCall
    {
        public void MakeQuickCall(string phoneNumber)
        {
            try
            {
                var uri = Android.Net.Uri.Parse(string.Format("tel:{0}", phoneNumber));
                var intent = new Intent(Intent.ActionCall,uri);
                Xamarin.Forms.Forms.Context.StartActivity(intent);
            }
            catch (Exception ex)
            {
                new AlertDialog.Builder(Android.App.Application.Context).SetPositiveButton("OK", (sender, args) =>
                 {
                 })
                .SetMessage(ex.ToString())
                .SetTitle("Android Exception")
                .Show();
            }
        }
    }
}