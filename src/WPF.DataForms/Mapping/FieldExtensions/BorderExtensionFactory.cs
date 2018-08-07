using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WPF.DataForms.Mapping.FieldExtensions.Base;

namespace WPF.DataForms.Mapping.FieldExtensions
{
    class BorderExtensionFactory : FieldExtensionFactory<BorderExtensionDescription>
    {
        public override FrameworkElementFactory Apply(BorderExtensionDescription fieldExtensionDescription, FrameworkElementFactory frameworkElementFactory)
        {
            FrameworkElementFactory border = new FrameworkElementFactory(typeof(Border));

            border.SetValue(Border.BorderBrushProperty, new SolidColorBrush(fieldExtensionDescription.Color));
            border.SetValue(Border.BorderThicknessProperty, new Thickness(2));

            border.AppendChild(frameworkElementFactory);

            return border;
        }
    }
}
