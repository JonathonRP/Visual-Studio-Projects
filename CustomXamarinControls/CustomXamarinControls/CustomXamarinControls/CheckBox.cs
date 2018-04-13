using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CustomXamarinControls
{
    public class CheckBox : View
    {
        /// <summary>
        /// The checked state property.
        /// </summary>
        public static readonly BindableProperty CheckedProperty =
            BindableProperty.Create(nameof(Checked), typeof(bool), typeof(CheckBox), false, BindingMode.TwoWay, propertyChanged: OnCheckedPropertyChanged);

        /// <summary>
        /// The checked text property.
        /// </summary>
        public static readonly BindableProperty CheckedTextProperty =
            BindableProperty.Create(nameof(CheckedText), typeof(string), typeof(CheckBox), string.Empty, BindingMode.TwoWay);

        /// <summary>
        /// The unchecked text property.
        /// </summary>
        public static readonly BindableProperty UncheckedTextProperty =
            BindableProperty.Create(nameof(UncheckedText), typeof(string), typeof(CheckBox), string.Empty);

        /// <summary>
        /// The default text property.
        /// </summary>
        public static readonly BindableProperty DefaultTextProperty =
            BindableProperty.Create(nameof(DefaultText), typeof(string), typeof(CheckBox), string.Empty);

        /// <summary>
        /// Identifies the TextColor bindable property.
        /// </summary>
        /// 
        /// <remarks/>
        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(CheckBox), Color.Default);

        public static readonly BindableProperty ColorProperty =
            BindableProperty.Create(nameof(Color), typeof(Color), typeof(CheckBox), Color.Accent);

        /// <summary>
        /// The font size property
        /// </summary>
        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create(nameof(FontSize), typeof(double), typeof(CheckBox), -1.0);

        /// <summary>
        /// The font name property.
        /// </summary>
        public static readonly BindableProperty FontNameProperty =
            BindableProperty.Create(nameof(FontName), typeof(string), typeof(CheckBox), string.Empty);


        /// <summary>
        /// The checked changed event.
        /// </summary>
        public event EventHandler<EventArgs<bool>> CheckedChanged;

        /// <summary>
        /// Gets or sets a value indicating whether the control is checked.
        /// </summary>
        /// <value>The checked state.</value>
        public bool Checked
        {
            get
            {
                return this.GetValue<bool>(CheckedProperty);
            }

            set
            {
                if (this.Checked != value)
                {
                    this.SetValue(CheckedProperty, value);
                    CheckedChanged?.Invoke(this, new EventArgs<bool>(value));
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating the checked text.
        /// </summary>
        /// <value>The checked state.</value>
        /// <remarks>
        /// Overwrites the default text property if set when checkbox is checked.
        /// </remarks>
        public string CheckedText
        {
            get
            {
                return this.GetValue<string>(CheckedTextProperty);
            }

            set
            {
                this.SetValue(CheckedTextProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the control is checked.
        /// </summary>
        /// <value>The checked state.</value>
        /// <remarks>
        /// Overwrites the default text property if set when checkbox is checked.
        /// </remarks>
        public string UncheckedText
        {
            get
            {
                return this.GetValue<string>(UncheckedTextProperty);
            }

            set
            {
                this.SetValue(UncheckedTextProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        public string DefaultText
        {
            get
            {
                return this.GetValue<string>(DefaultTextProperty);
            }

            set
            {
                this.SetValue(DefaultTextProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the text.
        /// </summary>
        /// <value>The color of the text.</value>
        public Color TextColor
        {
            get
            {
                return this.GetValue<Color>(TextColorProperty);
            }

            set
            {
                this.SetValue(TextColorProperty, value);
            }
        }

        public Color Color
        {
            get { return this.GetValue<Color>(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        /// <summary>
        /// Gets or sets the size of the font.
        /// </summary>
        /// <value>The size of the font.</value>
        public double FontSize
        {
            get
            {
                return (double)GetValue(FontSizeProperty);
            }
            set
            {
                SetValue(FontSizeProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the name of the font.
        /// </summary>
        /// <value>The name of the font.</value>
        public string FontName
        {
            get
            {
                return (string)GetValue(FontNameProperty);
            }
            set
            {
                SetValue(FontNameProperty, value);
            }
        }
        /// <summary>
        /// Gets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text
        {
            get
            {
                return this.Checked
                    ? (string.IsNullOrEmpty(this.CheckedText) ? this.DefaultText : this.CheckedText)
                        : (string.IsNullOrEmpty(this.UncheckedText) ? this.DefaultText : this.UncheckedText);
            }
        }

        /// <summary>
        /// Called when [checked property changed].
        /// </summary>
        /// <param name="bindable">The bindable.</param>
        /// <param name="oldvalue">if set to <c>true</c> [oldvalue].</param>
        /// <param name="newvalue">if set to <c>true</c> [newvalue].</param>
        private static void OnCheckedPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var checkBox = (CheckBox)bindable;
            checkBox.Checked = (bool)newValue;
        }
    }

    /// <summary>
	/// Class BindableObjectExtensions.
	/// </summary>
	public static class BindableObjectExtensions
    {
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="bindableObject">The bindable object.</param>
        /// <param name="property">The property.</param>
        /// <returns>T.</returns>
        public static T GetValue<T>(this BindableObject bindableObject, BindableProperty property)
        {
            return (T)bindableObject.GetValue(property);
        }
    }

    /// <summary>
    /// Generic event argument class
    /// </summary>
    /// <typeparam name="T">Type of the argument</typeparam>
    public class EventArgs<T> : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventArgs"/> class.
        /// </summary>
        /// <param name="value">Value of the argument</param>
        public EventArgs(T value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the value of the event argument
        /// </summary>
        public T Value { get; private set; }
    }
}
