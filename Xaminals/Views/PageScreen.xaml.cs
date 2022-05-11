using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xaminals.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageScreen : ContentPage, INotifyPropertyChanged
    {
        string myText;
        public string MyText {
            get
            {
                return myText;
            }
            set 
            { 
                myText = value; 
                OnPropertyChanged("MyText"); 
            } 
        }
        public string Name { get; set; } = "PageScreen";
        public PageScreen()
        {
            InitializeComponent();
            BindingContext = this;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}