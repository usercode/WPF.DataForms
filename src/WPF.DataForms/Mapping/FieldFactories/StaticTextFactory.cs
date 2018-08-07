using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WPF.DataForms.Mapping;
using WPF.DataForms.Mapping.FieldDescriptions;
using WPF.DataForms.Mapping.FieldFactories.Base;

namespace WPF.DataForms.Mapping.FieldFactories
{
    public class StaticTextFactory : FieldFactory<StaticTextDescription>
    {
        public override FrameworkElementFactory GenerateField(IFactoryContext context, StaticTextDescription fieldDescription)
        {
            FrameworkElementFactory root = new FrameworkElementFactory(typeof(Border));
            
            FrameworkElementFactory element = new FrameworkElementFactory(typeof(TextBlock));
            element.SetValue(TextBlock.TextProperty, fieldDescription.Text);
            element.SetValue(TextBlock.MarginProperty, new Thickness(4));
            
            root.AppendChild(element);

            return root;
        }
    }
}
