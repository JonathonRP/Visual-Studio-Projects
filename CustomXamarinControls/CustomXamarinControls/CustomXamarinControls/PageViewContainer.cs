using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CustomXamarinControls
{
    public class PageViewContainer : View
    {
        public PageViewContainer()
        {
        }

        public static readonly BindableProperty ContentProperty = BindableProperty.Create(nameof(Content), typeof(Page), typeof(PageViewContainer), null);

        public Page Content
        {
            get { return (Page)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }
    }

    public static class ViewExtensions
    {
        /// <summary>
        /// Gets the page to which an element belongs
        /// </summary>
        /// <returns>The page.</returns>
        /// <param name="element">Element.</param>
        public static Page GetParentPage(this VisualElement element)
        {
            if (element != null)
            {
                var parent = element.Parent;
                while (parent != null)
                {
                    if (parent is Page)
                    {
                        return parent as Page;
                    }
                    parent = parent.Parent;
                }
            }
            return null;
        }
    }
}
