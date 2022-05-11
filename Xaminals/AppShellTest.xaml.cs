using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xaminals
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShellTest : Shell
    {
        public AppShellTest()
        {
            InitializeComponent();
        }
    }
}