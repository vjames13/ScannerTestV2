using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MonoAndroidDemo.Classes
{
    public class RetrievedClass : INotifyPropertyChanged
    {
        private string retrievedERPvalue = String.Empty;
        private string retrievedBrandvalue = String.Empty;
        private string retrievedBarcodevalue = String.Empty;
        private string retrievedInspectorvalue = String.Empty;
        private string retrievedDatevalue = String.Empty;

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private RetrievedClass()
        {
            retrievedERPvalue = "default";
            retrievedBrandvalue = "default";
            retrievedBarcodevalue = "default";
            retrievedInspectorvalue = "default";
            retrievedDatevalue = "default";
        }

        public static RetrievedClass CreateRetrievedClass()
        {
            return new RetrievedClass();
        }
        public string retrievedERP
        {
            get
            {
                return this.retrievedERPvalue;
            }
            set
            {
                if (value != this.retrievedERPvalue)
                {
                    this.retrievedERPvalue = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string retrievedBarcode
        {
            get
            {
                return this.retrievedBarcodevalue;
            }
            set
            {
                if (value != this.retrievedBarcodevalue)
                {
                    this.retrievedBarcodevalue = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string retrievedBrand
        {
            get
            {
                return this.retrievedBrandvalue;
            }
            set
            {
                if (value != this.retrievedBrandvalue)
                {
                    this.retrievedBrandvalue = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string retrievedInspector
        {
            get
            {
                return this.retrievedInspectorvalue;
            }
            set
            {
                if (value != this.retrievedInspectorvalue)
                {
                    this.retrievedInspectorvalue = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string retrievedDate
        {
            get
            {
                return this.retrievedDatevalue;
            }
            set
            {
                if (value != this.retrievedDatevalue)
                {
                    this.retrievedDatevalue = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}