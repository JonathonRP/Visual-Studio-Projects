using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using CXC = CustomXamarinControls;
using CXCDroid = CustomXamarinControls.Droid;

[assembly: ExportRenderer(typeof(CXC.TableView), typeof(CXCDroid.TableViewRenderer))]
namespace CustomXamarinControls.Droid
{
    class TableViewRenderer : Xamarin.Forms.Platform.Android.TableViewRenderer
    {
        public TableViewRenderer(Context context) : base (context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.TableView> e)
        {
            base.OnElementChanged(e);
            if (Control == null)
                return;

            //var listView = Control as Android.Widget.ListView;
            //var TableView = (TableView)Element;

            //this.GetModelRenderer(listView, TableView).GetView(this.Id, TableView.GetRenderer().View, this).ForceLayout();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == "Color")
            {
                var listView = Control as Android.Widget.ListView;
                var TableView = (TableView)Element;
                
            }
        }

        protected override Xamarin.Forms.Platform.Android.TableViewModelRenderer GetModelRenderer(Android.Widget.ListView listView, Xamarin.Forms.TableView view)
        {
            return new TableViewModelRenderer(Context, listView, view);
        }

        private class TableViewModelRenderer : Xamarin.Forms.Platform.Android.TableViewModelRenderer
        {
            private readonly TableView _TableView;

            public TableViewModelRenderer(Context context, Android.Widget.ListView listView, Xamarin.Forms.TableView view) : base(context, listView, view)
            {
                _TableView = view as TableView;
            }

            public override Android.Views.View GetView(int position, Android.Views.View convertView, ViewGroup parent)
            {
                var view = base.GetView(position, convertView, parent);

                var element = GetCellForPosition(position);

                // section header will be a TextCell
                if (element.GetType() == typeof(TextCell))
                {
                    try
                    {
                        // Get the textView of the actual layout
                        var textView = ((((view as LinearLayout).GetChildAt(0) as LinearLayout).GetChildAt(1) as LinearLayout).GetChildAt(0) as TextView);

                        // get the divider below the header
                        var divider = (view as LinearLayout).GetChildAt(1);

                        // Set the color
                        textView.SetTextColor(_TableView.Color.ToAndroid());
                        //textView.TextAlignment = Android.Views.TextAlignment.Center;
                        //textView.Gravity = GravityFlags.CenterHorizontal;
                        divider.SetBackgroundColor(_TableView.Color.ToAndroid());
                    }
                    catch (Exception) { }
                }

                return view;
            }
        }
    }
}