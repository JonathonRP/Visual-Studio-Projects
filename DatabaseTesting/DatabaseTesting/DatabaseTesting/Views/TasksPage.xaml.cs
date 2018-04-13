using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using DatabaseTesting.Models;
using DatabaseTesting.Views;
using DatabaseTesting.ViewModels;

using CustomXamarinControls;
using Prism.Navigation;

namespace DatabaseTesting.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Tasks : ContentPage
	{
        public Tasks()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //Animation ZoomOut = new Animation { { 0, 1, new Animation(a => Opacity = a, .7, 1) },
            //    { 0, 1, new Animation(a => Scale = a, 2, 1) },
            //    { 0, 1, new Animation(a => HeightRequest = 1) },
            //    { 0, 1, new Animation(a => AnchorX = a, 2, 1) },
            //    { 0, 1, new Animation(a => AnchorY = 1) }
            //};

            //this.Animate("ZoomOut", ZoomOut, 16, 260, Easing.SinOut, null, null);
        }

        //protected override void OnDisappearing()
        //{
        //    Animation ZoomIn = new Animation { { 0, 1, new Animation(a => Opacity = a, 1, 0) },
        //        { 0, 1, new Animation(a => Scale = a, 1, 2) },
        //        { 0, 1, new Animation(a => HeightRequest = 1) },
        //        { 0, 1, new Animation(a => AnchorX = a, 1, 2) },
        //        { 0, 1, new Animation(a => AnchorY = 1) }
        //    };

        //    this.Animate("ZoomIn", ZoomIn, 16, 600, Easing.SinIn, null, null);
        //    base.OnDisappearing();
        //}
    }
}