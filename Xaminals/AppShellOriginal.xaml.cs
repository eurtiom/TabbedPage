using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xaminals.Data;
using Xaminals.Views;

namespace Xaminals
{
    public class Screena
    {
        public string screenName { get; set; }
        public List<PageScreen> contentPages { get; set; }
    }
    public class UserPropertiesa
    {
        public List<Screena> screens { get; set; } = new List<Screena> {
            new Screena { screenName = "screen1" , contentPages = new List<PageScreen>{ 
                    new PageScreen() { MyText = "screen1 applet1", Name = "S1applet1"},
                    new PageScreen() { MyText = "screen1 applet2", Name = "S1applet2"}
                },
            },
            new Screena { screenName = "screen2" , contentPages = new List<PageScreen>{
                    new PageScreen() { MyText = "screen2 applet1", Name = "S2applet1"},
                    new PageScreen() { MyText = "screen2 applet2", Name = "S2applet2"}
                },
            },
            new Screena { screenName = "screen3" , contentPages = new List<PageScreen>{
                    new PageScreen() { MyText = "screen3 applet1", Name = "S3applet1"},
                    new PageScreen() { MyText = "screen3 applet2", Name = "S3applet2"},
                    new PageScreen() { MyText = "screen3 applet3", Name = "S3applet3"},
                },
            },
        };

    }
    public class ScreenMain
    {
        public string Title { get; set; }
        public FlyoutItem FlyoutItemMain { get; set; }
        public ShellContent ShellContentMain { get; set; }
        public FlyoutItem FlyoutItemApplets { get; set; }
        public List<MenuItem> MenuItems { get; set; }
        public PageScreen SelectedPage { get; set; }
    }
    
    public partial class AppShellOriginal : Shell
    {
        public List<ScreenMain> ScreenMains { get; set; }
        public UserPropertiesa UserProperties { get; set; } = new UserPropertiesa() { };
        public AppShellOriginal()
        {
            InitializeComponent();
            //List<string> coucou = new List<string> { "kk", "lolo" };
            //var lolo = coucou.First();

            ScreenMains = new List<ScreenMain>();

            
            FlyoutItem fitemScreen = new FlyoutItem { Route = "Screens" };

            foreach (Screena item in UserProperties.screens)
            {
                ScreenMain screenmain = new ScreenMain();
                

                if (item.contentPages.Count != 0)
                {
                    FlyoutItem fitemScreenApplet = new FlyoutItem { Route = "Applets" + item.screenName, Style = (Style)this.Resources["BaseStyle"], FlyoutDisplayOptions = FlyoutDisplayOptions.AsMultipleItems };
                    screenmain.MenuItems = new List<MenuItem>();

                    screenmain.Title = item.screenName;
                    screenmain.SelectedPage = item.contentPages.First();
                    screenmain.ShellContentMain = new ShellContent() { Title = item.screenName, Route = item.screenName, Content = screenmain.SelectedPage, Style = (Style)this.Resources["BaseStyle"],FlyoutItemIsVisible=false };
                    screenmain.ShellContentMain.Appearing += ShellContent_Appearing;
                    screenmain.ShellContentMain.Disappearing += ShellContent_Disappearing;
                    //screenmain.FlyoutItemApplets = fitemScreenApplet;

                    foreach (PageScreen applet in item.contentPages)
                    {
                        MenuItem mitem = new MenuItem() { Text = applet.Name , Command = MenuItemPressed, CommandParameter = applet.Name };
                        screenmain.MenuItems.Add(mitem);

                        /*ShellContent sc = new ShellContent
                        {
                            Title = applet.Name,
                            Route = applet.Name,
                            Content = applet,
                            Style = (Style)this.Resources["BaseStyle"]
                        };
                        screenmain.FlyoutItemApplets.Items.Add(sc);*/
                    }
                }
                else
                {

                }
                ScreenMains.Add(screenmain);

                //fitemScreen.Items.Add()
                //FlyoutItem fitem = new FlyoutItem { 
                //    Title = item.screenName,
                //    Route = item.screenName,
                //    cont
                //}
            }
            

            if (ScreenMains.Count() != 0)
            {
                FlyoutItem flyoutItemMain = new FlyoutItem{ Style = (Style)this.Resources["BaseStyle"], FlyoutDisplayOptions = FlyoutDisplayOptions.AsMultipleItems };
                bool firstAdd = true;
                foreach (ScreenMain item in ScreenMains)
                {
                    flyoutItemMain.Items.Add(item.ShellContentMain);
                    /*if (firstAdd)
                    {
                        foreach (MenuItem menuitem in item.MenuItems)
                        {
                            this.Items.Add(menuitem);
                        }
                        firstAdd = false;
                    }*/
                    /*foreach (MenuItem menuitem in item.MenuItems)
                    {
                        this.Items.Add(menuitem);
                    }*/

                    //this.Items.Add(item.FlyoutItemApplets);
                }
                this.Items.Add(flyoutItemMain);
            }
            //this.BindingContext = this;
            //UserLayoutCreation ul = new UserLayoutCreation(this); 
        }


        protected override void OnNavigating(ShellNavigatingEventArgs args)
        {
            base.OnNavigating(args);
            // Cancel any back navigation
            //if (e.Source == ShellNavigationSource.Pop)
            //{
            //    e.Cancel();
            //}
        }

        protected override void OnNavigated(ShellNavigatedEventArgs args)
        {
            base.OnNavigated(args);

            // Perform required logic
        }
        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            //await Shell.Current.GoToAsync("//LoginPage");
        }
        public ICommand MenuItemPressed => new Command<string>((string item) =>
        {
            
        });

        private void ShellContent_Appearing(object sender, EventArgs e)
        {
            ShellContent sh = sender as ShellContent;

            ScreenMain sc = ScreenMains.Where(s => s.Title == sh.Title).First();
            foreach (MenuItem item in sc.MenuItems)
            {
                MenuItem mi = item;
                this.Items.Add(mi);
                
                //this.Items.Add(item);
            }
            /*foreach (var m in ScreenMains.Where(s => s.Title == sh.Title).Select(x => x.MenuItems).ToList())
            {
                var copy = new List<MenuItem>(m);
                foreach (MenuItem item in copy)
                {
                    this.Items.Add(item);
                }

                //FlyoutItem.IsVisibleProperty 
            }*/
        }

        private void ShellContent_Disappearing(object sender, EventArgs e)
        {
            ShellContent sh = sender as ShellContent;
            
            foreach(var m in ScreenMains.Where(s => s.Title == sh.Title).Select(x => x.MenuItems).ToList())
            {

                foreach (MenuItem item in m)
                {
                    //RemoveMenuItem(item);
                    this.Items.Remove(item);
                }
                
                //FlyoutItem.IsVisibleProperty 
            }
            /*foreach (MenuItem item in ScreenMains.Where(s => s.Title == sh.Title).Select(x => x.MenuItems))
            {

            } */
        }
        private void RemoveMenuItem(MenuItem menu)
        {
            foreach (ShellItem item in this.Items)
            {
                if (item.Title == menu.Text)
                {
                    this.Items.Remove(menu);
                    break;
                }
            }
        }
        private void AddMenuItem(MenuItem menu)
        {
            this.Items.Add(menu);
        }
    }
}