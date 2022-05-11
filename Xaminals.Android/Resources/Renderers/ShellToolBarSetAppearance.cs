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

namespace Xaminals.Droid.Resources.Renderers
{
    public class ShellToolBarSetAppearance : ShellToolbarAppearanceTracker
    {
        public ShellToolBarSetAppearance(IShellContext context) : base(context)
        {
        }
        public override void SetAppearance(AndroidX.AppCompat.Widget.Toolbar toolbar, IShellToolbarTracker toolbarTracker, ShellAppearance appearance)
        {
            base.SetAppearance(toolbar, toolbarTracker, appearance);
            toolbar.SetBackgroundResource(Resource.Drawable.monkey);
        }
    }
}