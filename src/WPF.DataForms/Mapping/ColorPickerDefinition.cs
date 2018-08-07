using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Xceed.Wpf.Toolkit;
using System.Windows.Data;
using System.Windows.Controls;
using WPF.Util.ValueConverters;

namespace WPF.DataForms.Mapping
{
    public class ColorPickerDefinition : FieldDescription
    {
        public ColorPickerDefinition(String displayName, String color)
            : base(displayName)
        {
            Color = color;
        }

        /// <summary>
        /// Color
        /// </summary>
        public String Color { get; private set; }

        public override FrameworkElementFactory CreateFactoryElement(bool isReadOnly, string stringFormat)
        {
            FrameworkElementFactory element;

            if (isReadOnly)
            {
                element = new FrameworkElementFactory(typeof(Border));
                
                //element.SetValue(ColorPicker.ShowAvailableColorsProperty, true);
                element.SetValue(Border.WidthProperty, 80d);
                element.SetBinding(Border.BackgroundProperty, new Binding(Color) { Mode = BindingMode.OneWay, Converter = new IntToBrushConverter() });

                return element;
            }
            else
            {
                element = new FrameworkElementFactory(typeof(ColorPicker));
                //element.SetValue(ColorPicker.ShowAvailableColorsProperty, true);

                element.SetBinding(ColorPicker.SelectedColorProperty, new Binding(Color) { Mode = BindingMode.TwoWay, Converter = new IntToColorConverter() });
            }

            element.SetValue(ColorPicker.HorizontalAlignmentProperty, HorizontalAlignment.Left);
            element.SetValue(ColorPicker.WidthProperty, 80d);

            return element;
        }

    }
}
