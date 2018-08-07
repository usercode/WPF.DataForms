using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using WPF.DataForms.Mapping.FieldDescriptions;
using WPF.DataForms.Mapping.FieldFactories.Base;
using WPF.DataForms.ValueConverters;

namespace WPF.DataForms.Mapping.FieldFactories
{
    /// <summary>
    /// LabelDefinition
    /// </summary>
    public class ImageFactory : FieldFactory<ImageDescription>
    {
        public override FrameworkElementFactory GenerateField(IFactoryContext context, ImageDescription fieldDescription)
        {
            FrameworkElementFactory border = new FrameworkElementFactory(typeof(Image));
            border.SetValue(Image.StretchProperty, fieldDescription.Stretch);
            border.SetBinding(Image.SourceProperty, new Binding(fieldDescription.ImageSource) { Converter = new BytesToImageConverter() });

            return border;
        }
    }
}
