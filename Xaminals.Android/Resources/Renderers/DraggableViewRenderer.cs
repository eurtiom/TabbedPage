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

[assembly: ExportRenderer(typeof(DraggableView), typeof(DraggableViewRenderer))]
namespace Xaminals.Droid.Resources.Renderers
{
    public class DraggableViewRenderer : VisualElementRenderer<Xamarin.Forms.View>
    {
        float originalX;
        float originalY;
        float dX;
        float dY;
        bool firstTime = true;
        bool touchedDown = false;
        public DraggableViewRenderer(Context context) : base(context)
        { }
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.View> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                LongClick -= HandleLongClick;
            }
            if (e.NewElement != null)
            {
                LongClick += HandleLongClick;
                var dragView = Element as DraggableView;
                dragView.RestorePositionCommand = new Command(() =>
                {
                    if (!firstTime)
                    {
                        SetX(originalX);
                        SetY(originalY);
                    }

                });
            }
        }

        private void HandleLongClick(object sender, LongClickEventArgs e)
        {
            var dragView = Element as DraggableView;
            if (firstTime)
            {
                originalX = GetX();
                originalY = GetY();
                firstTime = false;
            }
            dragView.DragStarted();
            touchedDown = true;
        }

        public override bool OnTouchEvent(MotionEvent e)
        {
            float x = e.RawX;
            float y = e.RawY;
            var dragView = Element as DraggableView;
            switch (e.Action)
            {
                case MotionEventActions.Down:
                    if (dragView.DragMode == DragMode.Touch)
                    {
                        if (!touchedDown)
                        {
                            if (firstTime)
                            {
                                originalX = GetX();
                                originalY = GetY();
                                firstTime = false;
                            }
                            dragView.DragStarted();
                        }

                        touchedDown = true;
                    }
                    dX = x - GetX();
                    dY = y - GetY();
                    break;
                case MotionEventActions.Move:
                    if (touchedDown)
                    {
                        if (dragView.DragDirection == DragDirectionType.All || dragView.DragDirection == DragDirectionType.Horizontal)
                        {
                            SetX(x - dX);
                        }

                        if (dragView.DragDirection == DragDirectionType.All || dragView.DragDirection == DragDirectionType.Vertical)
                        {
                            SetY(y - dY);
                        }

                    }
                    break;
                case MotionEventActions.Up:
                    touchedDown = false;
                    dragView.DragEnded();
                    break;
                case MotionEventActions.Cancel:
                    touchedDown = false;
                    break;
            }
            return base.OnTouchEvent(e);
        }

        public override bool OnInterceptTouchEvent(MotionEvent e)
        {
            BringToFront();
            return true;
        }
    }
}