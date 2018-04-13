using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CustomXamarinControls;
using CustomXamarinControls.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(PageViewContainer), typeof(PageViewContainerRenderer))]
namespace CustomXamarinControls.Droid
{
    public class PageViewContainerRenderer : ViewRenderer<PageViewContainer, Android.Views.View>
    {
        public PageViewContainerRenderer(Context context) : base(context)
        {
            
        }

        Page _currentPage;

        protected override void OnElementChanged(ElementChangedEventArgs<PageViewContainer> e)
        {
            base.OnElementChanged(e);
            var pageViewContainer = e.NewElement as PageViewContainer;
            if (e.NewElement != null)
            {
                ChangePage(e.NewElement.Content);
            }
            else
            {
                ChangePage(null);
            }

        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == "Content")
            {
                ChangePage(Element.Content);
            }
        }

        bool _contentNeedsLayout;

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);
            if ((changed || _contentNeedsLayout) && this.Control != null)
            {
                if (_currentPage != null)
                {
                    _currentPage.Layout(new Rectangle(0, 0, Element.Width, Element.Height));
                }
                var msw = MeasureSpec.MakeMeasureSpec(r - l, MeasureSpecMode.Exactly);
                var msh = MeasureSpec.MakeMeasureSpec(b - t, MeasureSpecMode.Exactly);
                this.Control.Measure(msw, msh);
                this.Control.Layout(0, 0, r, b);
                _contentNeedsLayout = false;
            }
        }

        private int ConvertPixelsToDp(float pixelValue)
        {
            var dp = (int)((pixelValue) / Resources.DisplayMetrics.Density);
            return dp;
        }


        void ChangePage(Page page)
        {

            //TODO handle current page
            if (page != null)
            {
                var parentPage = Element.GetParentPage();
                page.Parent = parentPage;

                var existingRenderer = page.GetRenderer();
                if (existingRenderer == null)
                {
                    var renderer = RendererFactory.GetRenderer(page);
                    page.SetRenderer(renderer);
                    existingRenderer = page.GetRenderer();
                }
                _contentNeedsLayout = true;
                SetNativeControl(existingRenderer.View);
                Invalidate();
                //TODO update the page
                _currentPage = page;
            }
            else
            {
                //TODO - update the page
                _currentPage = null;
            }

            if (_currentPage == null)
            {
                //have to set somethign for android not to get pissy
                var view = new Android.Views.View(this.Context);
                view.SetBackgroundColor(Element.BackgroundColor.ToAndroid());
                SetNativeControl(view);
            }
        }
    }

    public static class ViewExtensions
    {
        private static readonly Type _platformType = Type.GetType("Xamarin.Forms.Platform.Android.Platform, Xamarin.Forms.Platform.Android", true);
        private static BindableProperty _rendererProperty;

        public static BindableProperty RendererProperty
        {
            get
            {
                _rendererProperty = (BindableProperty)_platformType.GetField("RendererProperty", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static)
                    .GetValue(null);

                return _rendererProperty;
            }
        }

        public static IVisualElementRenderer GetRenderer(this BindableObject bindableObject)
        {
            var value = bindableObject.GetValue(RendererProperty);
            return (IVisualElementRenderer)bindableObject.GetValue(RendererProperty);
        }

        public static Android.Views.View GetNativeView(this BindableObject bindableObject)
        {
            var renderer = bindableObject.GetRenderer();
            var viewGroup = renderer.View;
            return viewGroup;
        }

        public static void SetRenderer(this BindableObject bindableObject, IVisualElementRenderer renderer)
        {
            //			var value = bindableObject.GetValue (RendererProperty);
            bindableObject.SetValue(RendererProperty, renderer);
        }

        public static Point GetNativeScreenPosition(this BindableObject bindableObject)
        {
            var view = bindableObject.GetNativeView();
            var point = Point.Zero;
            if (view != null)
            {
                int[] location = new int[2];
                view.GetLocationOnScreen(location);
                point = new Xamarin.Forms.Point(location[0], location[1]);
            }
            return point;
        }

        /// <summary>
        /// Gets the or create renderer.
        /// </summary>
        /// <returns>The or create renderer.</returns>
        /// <param name="source">Source.</param>
        public static IVisualElementRenderer GetOrCreateRenderer(this VisualElement source)
        {
            var renderer = source.GetRenderer();
            if (renderer == null)
            {
                renderer = RendererFactory.GetRenderer(source);
                source.SetRenderer(renderer);
                renderer = source.GetRenderer();
            }
            return renderer;
        }
    }
}