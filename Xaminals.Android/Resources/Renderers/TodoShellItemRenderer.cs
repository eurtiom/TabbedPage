using Android.Graphics;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;
using Google.Android.Material.BottomNavigation;
using System.Drawing;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xaminals.Controls;
using Xaminals.Droid.Extensions;

namespace Xaminals.Droid
{
    public class TodoShellItemRenderer : ShellItemRenderer
    {
        FrameLayout _navArea;
        FrameLayout _shellOverlay;
        FrameLayout _shellOverlayView;
        BottomNavigationView _bottomView;
        public TodoShellItemRenderer(IShellContext shellContext) : base(shellContext)
        {
        }
        public override Android.Views.View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        { 
            
            var outerlayout = base.OnCreateView(inflater, container, savedInstanceState);

            _bottomView = outerlayout.FindViewById<BottomNavigationView>(Resource.Id.bottomtab_tabbar);
            _shellOverlay = outerlayout.FindViewById<FrameLayout>(Resource.Id.bottomtab_tabbar_container);
            _navArea = outerlayout.FindViewById<FrameLayout>(Resource.Id.bottomtab_navarea); /*bottomtab.navarea*/
            _shellOverlayView = outerlayout.FindViewById<FrameLayout>(Resource.Id.bottomtab_view);
            //var lol = outerlayout.FindViewById<TableLayout>(Resource.Id.sliding_tabs);

            if (ShellItem is TodoTabBar todoTabBar && todoTabBar.ViewToDo != null)
            {
                //SetupLargeTab();
                SetupTopView();
                //SetupBottomLayout();
                //SetupTopPageView();
            }
            //if (DisplayedPage is ItemToAdd itemToAdd && itemToAdd.MyView != null)
            //{
            //    //SetupLargeTab();
            //    //SetupTopView();
            //    //SetupBottomLayout();
            //    SetupTopPageView();
            //}

            return outerlayout;
        }
        private void SetupTopView2()
        {
            var customShellItem = (CustomShellItem)ShellItem;

        }
        private void SetupTopView()
        {
            var todoTabBar = (TodoTabBar)ShellItem;
            var height = 200;
            var width = (int)Resources.DisplayMetrics.WidthPixels;
            Xamarin.Forms.Rectangle size = new Xamarin.Forms.Rectangle(0, 0, width, height);
            todoTabBar.ViewToDo.Layout(size);
            var renderer = Platform.CreateRendererWithContext(todoTabBar.ViewToDo, Context);
            renderer.Tracker.UpdateLayout();
            var nativeView = renderer.View;

            var layout = new FrameLayout(Context);
            layout.AddView(nativeView);
            var lp = new FrameLayout.LayoutParams(width, height * (int)Resources.DisplayMetrics.Density);
            _bottomView.Measure((int)MeasureSpecMode.Unspecified, (int)MeasureSpecMode.Unspecified);
            lp.BottomMargin = _bottomView.MeasuredHeight;

            layout.LayoutParameters = lp;
            _shellOverlayView.RemoveAllViews();
            _shellOverlayView.AddView(layout);
        }
        private void SetupTopPageView()
        {
            var itemToAdd = (ItemToAdd)DisplayedPage;
            var height = 200;
            var width = (int)Resources.DisplayMetrics.WidthPixels;
            Xamarin.Forms.Rectangle size = new Xamarin.Forms.Rectangle(0, 0, width, height);
            itemToAdd.MyView.Layout(size);
            var renderer = Platform.CreateRendererWithContext(itemToAdd.MyView, Context);
            renderer.Tracker.UpdateLayout();
            var nativeView = renderer.View;

            var layout = new FrameLayout(Context);
            layout.AddView(nativeView);
            var lp = new FrameLayout.LayoutParams(width, height * (int)Resources.DisplayMetrics.Density);
            _bottomView.Measure((int)MeasureSpecMode.Unspecified, (int)MeasureSpecMode.Unspecified);
            lp.BottomMargin = _bottomView.MeasuredHeight;

            layout.LayoutParameters = lp;
            _shellOverlayView.RemoveAllViews();
            _shellOverlayView.AddView(layout);
        }
        private async void SetupBottomLayout()
        {
            var todoTabBar = (TodoTabBar)ShellItem;
            var layout = new FrameLayout(Context);

            var stacklayout = todoTabBar.BottomLayoutStack;

            var size = new Xamarin.Forms.Rectangle(0, 0, Context.Resources.DisplayMetrics.WidthPixels, stacklayout.HeightRequest);
            var vRenderer = RendererFactory.GetRenderer(stacklayout);
            var viewGroup = vRenderer.ViewGroup;
            vRenderer.Tracker.UpdateLayout();
            var layoutParams = new ViewGroup.LayoutParams((int)size.Width, (int)size.Height);
            viewGroup.LayoutParameters = layoutParams;
            stacklayout.Layout(size);
            viewGroup.Layout(0, 0, (int)stacklayout.WidthRequest, (int)stacklayout.HeightRequest);
            layout.AddView(viewGroup);

            _shellOverlay.RemoveAllViews();
            _shellOverlay.AddView(layout);
        }
        private async void SetupLargeTab()
        {
            var todoTabBar = (TodoTabBar)ShellItem;
            var layout = new FrameLayout(Context);

            var imageHandler = todoTabBar.LargeTab.Icon.GetHandler();
            Android.Graphics.Bitmap bitmap = await imageHandler.LoadImageAsync(todoTabBar.LargeTab.Icon, Context);
            var image = new ImageView(Context);
            image.SetImageBitmap(bitmap);

            layout.AddView(image);

            var lp = new FrameLayout.LayoutParams(300, 300);
            _bottomView.Measure((int)MeasureSpecMode.Unspecified, (int)MeasureSpecMode.Unspecified);
            lp.BottomMargin = _bottomView.MeasuredHeight / 2;

            layout.LayoutParameters = lp;

            _shellOverlay.RemoveAllViews();
            _shellOverlay.AddView(layout);
        }
    }
}