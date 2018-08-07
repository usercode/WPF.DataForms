using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using WPF.DataForms.Mapping.FieldDescriptions;
using WPF.DataForms.Mapping.FieldFactories.Base;

namespace WPF.DataForms.Mapping.FieldFactories
{
    /// <summary>
    /// CustomPropertyDefinition
    /// </summary>
    public class CustomFactory : FieldFactory<CustomDescription>
    {
        public override FrameworkElementFactory GenerateField(IFactoryContext context, CustomDescription fieldDescription)
        {
            FrameworkElementFactory element;
            if (fieldDescription.CustomControlType.IsSubclassOf(typeof(UIElement)))
            {
                element = new FrameworkElementFactory(fieldDescription.CustomControlType);
            }
            else
            {
                element = new FrameworkElementFactory(typeof(ContentControl));
                element.SetValue(ContentControl.ContentProperty, Activator.CreateInstance(fieldDescription.CustomControlType));
            }

            return element;
        }
    }
}
