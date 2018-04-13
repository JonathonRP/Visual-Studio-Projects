using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CustomXamarinControls
{
    public class FocusEntry : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry entry)
        {
            entry.Focus();
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.Unfocus();
            base.OnDetachingFrom(entry);
        }
    }
}
