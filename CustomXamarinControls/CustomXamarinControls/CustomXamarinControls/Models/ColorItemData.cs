using Plugin.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace CustomXamarinControls
{
    public static class ColorItemData
    {
        public static IList<ColorItem> Colors { get; private set; }

        static ColorItemData()
        {
            Colors = new List<ColorItem>
            {
                new ColorItem() { Name = "Default", Color = Color.White, Hex = Color.White.ToHex() }
            };

            foreach (var color in typeof(Color).GetFields())
            {
                if (color != null && !String.IsNullOrEmpty(color.Name) && color.Name != "Transparent")
                {
                    Colors.Add(new ColorItem() {
                        Name = color.Name,
                        Color = (Color)color.GetValue(color),
                        Hex = ((Color)color.GetValue(color)).ToHex()
                    });
                }
            }
        }
    }
}
