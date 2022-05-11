using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xaminals;
using Xaminals.Droid;
using Xaminals.Droid.Resources.Renderers;

//[assembly: ExportRenderer(typeof(AppShell), typeof(ShellToolBarRenderer))]
namespace Xaminals.Droid.Resources.Renderers
{
    public class ShellToolBarRenderer : ShellRenderer
    {
        public ShellToolBarRenderer(Context context) : base(context)
        {
        }

        protected override IShellToolbarAppearanceTracker CreateToolbarAppearanceTracker()
        {
            return new ShellToolBarSetAppearance(this);
        }
    }
}