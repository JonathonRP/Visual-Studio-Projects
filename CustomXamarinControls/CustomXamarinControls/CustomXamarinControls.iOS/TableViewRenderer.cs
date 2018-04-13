using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using CXC = CustomXamarinControls;
using CXCiOS = CustomXamarinControls.iOS;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CXC.TableView), typeof(CXCiOS.TableViewRenderer))]
namespace CustomXamarinControls.iOS
{
    class TableViewRenderer : Xamarin.Forms.Platform.iOS.TableViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.TableView> e)
        {
            base.OnElementChanged(e);
            if (Control == null)
                return;
            
            var tableView = Control as UITableView;
            var TableView = Element as TableView;
            //tableView.SeparatorColor = TableView.Color.ToUIColor();
            tableView.WeakDelegate = new TableModelRenderer(TableView);
        }

        //protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        //{
        //    base.OnElementPropertyChanged(sender, e);
        //    if (e.PropertyName == "Color")
        //    {
        //        var tableView = Control as UITableView;
        //        var TableView = Element as TableView;

        //        tableView.SeparatorColor = TableView.Color.ToUIColor();
        //    }
        //}

        private class TableModelRenderer : UnEvenTableViewModelRenderer
        {
            private readonly TableView _TableView;
            public TableModelRenderer(TableView model) : base(model)
            {
                _TableView = model as TableView;
            }
            public override UIView GetViewForHeader(UITableView tableView, nint section)
            {
                return new UILabel()
                {
                    Text = TitleForHeader(tableView, section),
                    TextColor = _TableView.Color.ToUIColor(),
                    //TextAlignment = UITextAlignment.Center
                };
            }
        }
    }
}