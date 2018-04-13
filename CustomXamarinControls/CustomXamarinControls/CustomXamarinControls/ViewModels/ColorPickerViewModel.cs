using Plugin.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace CustomXamarinControls
{
    public class ColorPickerViewModel : ViewModelBase
    {
        string storageKey;
        public string StorageKey
        {
            get
            {
                return storageKey;
            }

            set
            {
                storageKey = value;
                OnPropertyChanging();
                OnPropertyChanging("StorageKey");

                Color currentColor = Color.FromHex(CrossSettings.Current.GetValueOrDefault(StorageKey, Color.White.ToHex()));
                Colors.Remove(Colors.Where(x => x.Color == currentColor) as ColorItem);
            }
        }

        ColorItem selectedColor;

        public ColorItem SelectedColor
        {
            get { return selectedColor; }

            set
            {
                if (selectedColor != value)
                {
                    selectedColor = value;
                    OnPropertyChanged();
                    OnPropertyChanged("SelectedColor");
                }
            }
        }

        public IList<ColorItem> Colors
        {
            get
            {
                return ColorItemData.Colors;
            }
        }
    }

    public static class ColorsExtensionMethods
    {
        public static string GetNameByHexColor(this IList<ColorItem> list, string Hex)
        {
            return list.FirstOrDefault(x => x.Hex == Hex).Name;
        }
        public static string GetNameByColor(this IList<ColorItem> list, Color color)
        {
            return list.FirstOrDefault(x => x.Color == color).Name;
        }
        public static string GetHexColorByName(this IList<ColorItem> list, string name)
        {
            return list.FirstOrDefault(x => x.Name == name).Hex;
        }
        public static string GetHexColorByColor(this IList<ColorItem> list, Color color)
        {
            return list.FirstOrDefault(x => x.Color == color).Hex;
        }
        public static Color GetColorByName(this IList<ColorItem> list, string name)
        {
            return list.FirstOrDefault(x => x.Name == name).Color;
        }
        public static Color GetColorByHex(this IList<ColorItem> list, string Hex)
        {
            return list.FirstOrDefault(x => x.Hex == Hex).Color;
        }
    }
}
