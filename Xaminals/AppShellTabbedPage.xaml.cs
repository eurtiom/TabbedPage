using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xaminals.Views;

namespace Xaminals
{
    public class Screen
    {
        public string screenName { get; set; }
        public List<PageScreen> contentPages { get; set; }
    }
    public class UserProperties
    {
        public List<Screen> screens { get; set; } = new List<Screen> {
            new Screen { 
                screenName = "screen1" , 
                contentPages = new List<PageScreen>{
                    new PageScreen() { MyText = "screen1 applet1", Name = "S1applet1"},
                    new PageScreen() { MyText = "screen1 applet2", Name = "S1applet2"}
                },
            },
            new Screen { 
                screenName = "screen2" , 
                contentPages = new List<PageScreen>{
                    new PageScreen() { MyText = "screen2 applet1", Name = "S2applet1"},
                    new PageScreen() { MyText = "screen2 applet2", Name = "S2applet2"}
                },
            },
            new Screen { 
                screenName = "screen3" , 
                contentPages = new List<PageScreen>{
                    new PageScreen() { MyText = "screen3 applet1", Name = "S3applet1"},
                    new PageScreen() { MyText = "screen3 applet2", Name = "S3applet2"},
                    new PageScreen() { MyText = "screen3 applet3", Name = "S3applet3"},
                },
            },
        };

    }
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShellTabbedPage : Shell
    {
        UserProperties UserProperties = new UserProperties();
        TabBar ScreensTabBar = new TabBar() { Route = "tabbar"};

        public AppShellTabbedPage()
        {
            InitializeComponent();

            foreach(Screen screen2 in UserProperties.screens)
            {
                ListView AppletListView = new ListView()
                {
                    ItemsSource = screen2.contentPages,
                    ItemTemplate = new DataTemplate(() =>
                    {
                        var grid = new Grid();
                        var lab = new Label();
                        lab.SetBinding(Label.TextProperty, "Name");

                        grid.Children.Add(lab);

                        return new ViewCell { View = grid };
                    })
                };
                AppletListView.ItemTapped += AppletListViewItemTapped;

                ContentPage AppletMenuContentPage = new ContentPage() { Content = AppletListView };
                ShellContent scontent = new ShellContent() { Title = screen2.screenName, Route = screen2.screenName, Content = AppletMenuContentPage, Style = (Style)this.Resources["BaseStyle"] };

                ScreensTabBar.Items.Add(scontent);
            }
            this.Items.Add(ScreensTabBar);
        }
        private async void AppletListViewItemTapped(object sender, EventArgs e)
        {
            ListView listView = sender as ListView;
            await Navigation.PushAsync((Page)listView.SelectedItem);
        }
    }
}