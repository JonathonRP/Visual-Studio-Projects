using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using DatabaseTesting.Models;
using DatabaseTesting.ViewModels;

using CustomXamarinControls;

namespace DatabaseTesting.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Subtasks : ContentPage
	{
        public Subtasks()
        {
            InitializeComponent();
        }
        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    Animation ZoomIn = new Animation { { 0, 1, new Animation(a => Opacity = a, .7, 1) },
        //        { 0, 1, new Animation(a => Scale = a, .996, 1) },
        //        { 0, 1, new Animation(a => HeightRequest = 1) },
        //        { 0, 1, new Animation(a => AnchorX = a, .993, 1) },
        //        { 0, 1, new Animation(a => AnchorY = 1) }
        //    };

        //    this.Animate("ZoomIn", ZoomIn, 16, 250, Easing.CubicIn, null, null);
        //}
        //protected override void OnDisappearing()
        //{
        //    Animation ZoomOut = new Animation { { 0, 1, new Animation(a => Opacity = a, 1, 0) },
        //        { 0, 1, new Animation(a => Scale = a, 1, .996) },
        //        { 0, 1, new Animation(a => HeightRequest = 1) },
        //        { 0, 1, new Animation(a => AnchorX = a, 1, .993) },
        //        { 0, 1, new Animation(a => AnchorY = 1) }
        //    };

        //    this.Animate("ZoomOut", ZoomOut, 16, 250, Easing.CubicIn, null, null);
        //    base.OnDisappearing();
        //}
    }
}