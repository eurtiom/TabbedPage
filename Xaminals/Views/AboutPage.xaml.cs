using Rg.Plugins.Popup.Contracts;
using Rg.Plugins.Popup.Extensions;
using System.Windows.Input;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Xaminals.Views
{
    public partial class AboutPage : ContentPage
    {
        public ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));
        private IPopupNavigation _popup { get; set; }

        public AboutPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            //PopUpPage pup = new PopUpPage() { };
            //Navigation.PushPopupAsync(pup);
            DraggablePopupPage pup = new DraggablePopupPage() { };
            Navigation.PushPopupAsync(pup);
            //Navigation.PushAsync(new Page1());
            //Navigation.ShowPopup(new ToolkitPopup());
        }
    }
}
