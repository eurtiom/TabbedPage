using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Xaminals.Controls
{
    public class TodoTabBar : TabBar
    {
        public Tab LargeTab { get; set; }
        public StackLayout BottomLayoutStack { get; set; }
        public View ViewToDo { get; set; }
    }
}
