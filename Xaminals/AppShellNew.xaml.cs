using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xaminals.Controls;

namespace Xaminals
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShellNew : CustomShell
    {
        public AppShellNew()
        {
            InitializeComponent();

        }
    }
}