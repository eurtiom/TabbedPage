using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xaminals.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewTestShell : StackLayout
    {
        public event EventHandler ThresholdReached;

        //protected virtual void OnThresholdReached(EventArgs e)
        //{
        //    EventHandler handler = ThresholdReached;
        //    handler?.Invoke(this, e);
        //}
        public ViewTestShell()
        {
            InitializeComponent();
        }

        private void Button_Pressed(object sender, EventArgs e)
        {
            ThresholdReached?.Invoke(this, EventArgs.Empty);
        }
    }
}