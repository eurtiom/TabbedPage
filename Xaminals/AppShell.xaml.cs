using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xaminals.Data;
using Xaminals.Views;

namespace Xaminals
{
    public partial class AppShell : Shell
    {
        public ObservableCollection<Test> MyFlyoutItems { get; set; }
        public Dictionary<string, Type> Routes { get; private set; } = new Dictionary<string, Type>();
        //public ICommand HelpCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));

        public AppShell()
        {
            MyFlyoutItems = new ObservableCollection<Test>()
            {
                new Test {  Name="MenuTitle1" },
                new Test  {  Name="MenuTitle2" },
                new Test  {  Name="MenuTitle3" },
                new Test  {  Name="MenuTitle4" }
            };
            InitializeComponent();
            BindingContext = this;
            //RegisterRoutes();
            //BindingContext = this;
            //FlyoutItem shellItem = new FlyoutItem() { Title = "Tab1" };
            //Tab tab = new Tab();
            //tab.Items.Add(new ShellContent() { Title = "Test1", Content = new ContentPage() { Content=new Label(){ Text= "coco" } } });
            //tab.Items.Add(new ShellContent() { Title = "Test2", Content = new ContentPage() { Content = new Label() { Text = "toyo" } } });
            //shellItem.Items.Add(tab);
            //this.Items.Add(shellItem);
        }

        void RegisterRoutes()
        {
            //Routes.Add("monkeydetails", typeof(MonkeyDetailPage));
            //Routes.Add("beardetails", typeof(BearDetailPage));
            Routes.Add("catdetails", typeof(CatDetailPage));
            //Routes.Add("dogdetails", typeof(DogDetailPage));
            //Routes.Add("elephantdetails", typeof(ElephantDetailPage));

            //foreach (var item in Routes)
            //{
            //    Routing.RegisterRoute(item.Key, item.Value);
            //}
        }

        //protected override void OnNavigating(ShellNavigatingEventArgs args)
        //{
        //    base.OnNavigating(args);

        //    // Cancel any back navigation
        //    //if (e.Source == ShellNavigationSource.Pop)
        //    //{
        //    //    e.Cancel();
        //    //}
        //}

        //protected override void OnNavigated(ShellNavigatedEventArgs args)
        //{
        //    base.OnNavigated(args);

        //    // Perform required logic
        //}
    }
}
