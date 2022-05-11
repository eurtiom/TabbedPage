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
using Xaminals.Droid.Resources.Renderers;
using Xaminals.Views;

//[assembly: ExportRenderer(typeof(DraggablePopupPage), typeof(DraggablePageRenderer))]
namespace Xaminals.Droid.Resources.Renderers
{
    public class DraggablePageRenderer : PageRenderer
    {
        float originalX;
        float originalY;
        float dX;
        float dY;
        bool firstTime = true;
        bool touchedDown = false;
        DraggablePopupPage view;
        public DraggablePageRenderer(Context context) : base(context)
        { 
    
        }
        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);

            GetChildAt(0).Layout(0, 0, r - l, b - t);
        }

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            base.OnMeasure(widthMeasureSpec, heightMeasureSpec);

            GetChildAt(0).Measure(200, 200);
        }
        //protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        //{
        //    base.OnElementChanged(e);

        //    if (e.OldElement != null)
        //    {
        //        LongClick -= HandleLongClick;
        //    }
        //    if (e.NewElement != null)
        //    {

        //        view = e.NewElement as DraggablePopupPage;
        //        //view.SizeChanged += (sender, eSize) => {
        //        //    ResizeView();
        //        //};
        //        //Rectangle rect1 = view.Bounds;
        //        //Xamarin.Forms.Rectangle size = new Xamarin.Forms.Rectangle(0, 0, 100, 100);
        //        //view.Layout(size);
        //        //Element.BackgroundColor = Color.Red;
        //        //Element.WidthRequest = 200;
        //        //Element.HeightRequest = 200;
        //        //Xamarin.Forms.Rectangle size = new Xamarin.Forms.Rectangle(50, 200, 1000, 800);
        //        //Element.Layout(size);
        //        LongClick += HandleLongClick;
        //        var dragView = Element as DraggablePopupPage;
        //        dragView.RestorePositionCommand = new Command(() =>
        //        {
        //            if (!firstTime)
        //            {
        //                SetX(originalX);
        //                SetY(originalY);
        //            }

        //        });
        //    }
        //}
        //protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ContentPage> e)
        //{
        //    base.OnElementChanged(e);

        //    //if (e.OldElement != null)
        //    //{
        //    //    LongClick -= HandleLongClick;
        //    //}
        //    //if (e.NewElement != null)
        //    //{

        //    //    view = e.NewElement as DraggablePopupPage;
        //    //    //view.SizeChanged += (sender, eSize) => {
        //    //    //    ResizeView();
        //    //    //};
        //    //    //Rectangle rect1 = view.Bounds;
        //    //    //Xamarin.Forms.Rectangle size = new Xamarin.Forms.Rectangle(0, 0, 100, 100);
        //    //    //view.Layout(size);
        //    //    //Element.BackgroundColor = Color.Red;
        //    //    //Element.WidthRequest = 200;
        //    //    //Element.HeightRequest = 200;
        //    //    //Xamarin.Forms.Rectangle size = new Xamarin.Forms.Rectangle(50, 200, 1000, 800);
        //    //    //Element.Layout(size);
        //    //    LongClick += HandleLongClick;
        //    //    var dragView = Element as DraggablePopupPage;
        //    //    dragView.RestorePositionCommand = new Command(() =>
        //    //    {
        //    //        if (!firstTime)
        //    //        {
        //    //            SetX(originalX);
        //    //            SetY(originalY);
        //    //        }

        //    //    });
        //    //}
        //}
        //private void ResizeView()
        //{
        //    Rectangle rect1 = view.Bounds;
        //    Xamarin.Forms.Rectangle size = new Xamarin.Forms.Rectangle(0, 0, 100, 100);
        //}
        //private void HandleLongClick(object sender, LongClickEventArgs e)
        //{
        //    var dragView = Element as DraggablePopupPage;
        //    if (firstTime)
        //    {
        //        originalX = GetX();
        //        originalY = GetY();
        //        firstTime = false;
        //    }
        //    dragView.DragStarted();
        //    touchedDown = true;
        //}

        //public override bool OnTouchEvent(MotionEvent e)
        //{
        //    float x = e.RawX;
        //    float y = e.RawY;
        //    var dragView = Element as DraggablePopupPage;
        //    switch (e.Action)
        //    {
        //        case MotionEventActions.Down:
        //            if (dragView.DragMode == DragPageMode.Touch)
        //            {
        //                if (!touchedDown)
        //                {
        //                    if (firstTime)
        //                    {
        //                        originalX = GetX();
        //                        originalY = GetY();
        //                        firstTime = false;
        //                    }
        //                    dragView.DragStarted();
        //                }

        //                touchedDown = true;
        //            }
        //            dX = x - GetX();
        //            dY = y - GetY();
        //            break;
        //        case MotionEventActions.Move:
        //            if (touchedDown)
        //            {
        //                if (dragView.DragDirection == DragPageDirectionType.All || dragView.DragDirection == DragPageDirectionType.Horizontal)
        //                {
        //                    SetX(x - dX);
        //                }

        //                if (dragView.DragDirection == DragPageDirectionType.All || dragView.DragDirection == DragPageDirectionType.Vertical)
        //                {
        //                    SetY(y - dY);
        //                }

        //            }
        //            break;
        //        case MotionEventActions.Up:
        //            touchedDown = false;
        //            dragView.DragEnded();
        //            break;
        //        case MotionEventActions.Cancel:
        //            touchedDown = false;
        //            break;
        //    }
        //    return base.OnTouchEvent(e);
        //}

        //public override bool OnInterceptTouchEvent(MotionEvent e)
        //{
        //    BringToFront();
        //    return true;
        //}
    }
}