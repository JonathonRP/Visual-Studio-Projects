using CustomXamarinControls;
using CustomXamarinControls.iOS;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(PageViewContainer), typeof(PageViewContainerRenderer))]
namespace CustomXamarinControls.iOS
{
    public class PageViewContainerRenderer : ViewRenderer<PageViewContainer, UIView>
    {
        public PageViewContainerRenderer()
        {

        }

        ViewControllerContainer _viewControllerContainer;

        protected override void OnElementChanged(ElementChangedEventArgs<PageViewContainer> e)
        {
            base.OnElementChanged(e);
            var pageViewContainer = e.NewElement as PageViewContainer;

            if (_viewControllerContainer != null)
            {
                _viewControllerContainer.ViewController = null;
                _viewControllerContainer = null;
            }

            if (e.NewElement != null)
            {
                _viewControllerContainer = new ViewControllerContainer(Bounds);
                SetNativeControl(_viewControllerContainer);
            }


        }

        Page _currentPage;

        void ChangePage(Page page)
        {
            if (_currentPage == page)
            {
                return;
            }
            //TODO call page dissapaering/appearing methods
            if (page != null)
            {
                var pageRenderer = page.GetRenderer();
                UIViewController viewController = null;
                if (pageRenderer?.ViewController != null)
                {
                    viewController = pageRenderer.ViewController;
                }
                else
                {
                    viewController = page.CreateViewController();
                }
                var parentPage = Element.GetParentPage();
                var renderer = parentPage.GetRenderer();

                if (_viewControllerContainer == null)
                {
                    _viewControllerContainer = new ViewControllerContainer(Bounds);
                    SetNativeControl(_viewControllerContainer);
                }
                _viewControllerContainer.ParentViewController = renderer.ViewController;
                _viewControllerContainer.ViewController = viewController;
                _currentPage = page;
                FixPageLayouts();
                SetNeedsLayout();

            }
            else
            {
                _viewControllerContainer = null;
            }
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            var page = Element?.Content;
            if (page != null)
            {
                page.Layout(new Rectangle(0, 0, Bounds.Width, Bounds.Height));
            }
            _viewControllerContainer.Frame = Bounds;
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == "Content" || e.PropertyName == "Renderer")
            {
                Device.BeginInvokeOnMainThread(() => ChangePage(Element?.Content));
            }
        }

        void FixPageLayouts()
        {
            var contentPage = _currentPage as ContentPage;
            if (contentPage != null)
            {
                contentPage.Layout(new Rectangle(0, 0, Bounds.Width, Bounds.Height));
                contentPage.ForceLayout();
                var layout = contentPage.Content as Layout<View>;
                if (layout != null)
                {
                    layout.Layout(new Rectangle(0, 0, Bounds.Width, Bounds.Height));
                    layout.ForceLayout();
                }
            }

        }
    }

    public static class UIViewControllerExtensions
    {
        public static UIViewController GetViewController(this UIView view)
        {
            var responder = (UIResponder)view;
            while (responder != null && !(responder is UIViewController))
            {
                responder = responder.NextResponder;
            }

            return (UIViewController)responder;
        }
    }

    public static class ViewExtensions
    {

        /***
		 * Thanks to Adam Kemp for generously making this code available.
		 * If you are reading this, please petition Xamarin to give us public access to the GetRenderer method:
		 * https://bugzilla.xamarin.com/show_bug.cgi?id=30467
		 */

        #region GetRenderer Hack

        private delegate IVisualElementRenderer GetRendererDelegate(BindableObject bindable);

        private static GetRendererDelegate _getRendererDelegate;

        public static IVisualElementRenderer GetRenderer(this BindableObject bindable)
        {
            if (bindable == null)
            {
                return null;
            }

            if (_getRendererDelegate == null)
            {
                var assembly = typeof(EntryRenderer).Assembly;
                var platformType = assembly.GetType("Xamarin.Forms.Platform.iOS.Platform");
                var method = platformType.GetMethod("GetRenderer");
                _getRendererDelegate = (GetRendererDelegate)method.CreateDelegate(typeof(GetRendererDelegate));
            }

            var value = _getRendererDelegate(bindable);

            return value;
        }

        #endregion
    }
}
