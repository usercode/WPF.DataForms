using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using WPF.DataForms.Mapping.FieldDescriptions;
using WPF.DataForms.Mapping.FieldFactories.Base;

namespace WPF.DataForms.Mapping.FieldFactories
{
    /// <summary>
    /// MultiLineTextDefinition
    /// </summary>
    public class MultiLineTextFactory : FieldFactory<MultiLineTextDescription>
    {
        public override FrameworkElementFactory GenerateField(IFactoryContext context, MultiLineTextDescription fieldDescription)
        {
            if (context.FormState == FormState.View)
            {
                return CreateReadOnlyTextElement(fieldDescription.Text, fieldDescription.StringFormat);
            }
            else
            {
                Binding binding = new Binding(fieldDescription.Text);
                binding.StringFormat = null;
                binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;

                FrameworkElementFactory textbox = new FrameworkElementFactory(typeof(TextBox));
                textbox.SetBinding(TextBox.TextProperty, binding);
                textbox.SetValue(TextBox.MarginProperty, new Thickness(0, 1, 2, 1));
                textbox.SetValue(TextBox.TextWrappingProperty, TextWrapping.Wrap);

                textbox.SetValue(TextBox.AcceptsReturnProperty, true);
                textbox.SetValue(TextBox.VerticalScrollBarVisibilityProperty, ScrollBarVisibility.Auto);

                if (fieldDescription.Height != null)
                {
                    textbox.SetValue(TextBox.HeightProperty, fieldDescription.Height.Value);
                }

                return textbox;
            }
        }
    }
}
