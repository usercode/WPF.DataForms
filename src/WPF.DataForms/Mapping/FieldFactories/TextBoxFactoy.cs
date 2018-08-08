using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using WPF.DataForms.Mapping.FieldDescriptions;
using WPF.DataForms.Mapping.FieldFactories.Base;

namespace WPF.DataForms.Mapping.FieldFactories
{
    public class TextBoxFactoy : FieldFactory<TextBoxDescription>
    {
        public override FrameworkElementFactory GenerateField(IFactoryContext context, TextBoxDescription fieldDescription)
        {            
            if (context.FormState == FormState.View)
            {
                return CreateReadOnlyTextElement(fieldDescription.Text, fieldDescription.StringFormat);
            }
            else
            {
                Binding binding = new Binding(fieldDescription.Text);
                binding.StringFormat = fieldDescription.StringFormat;
                binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;

                FrameworkElementFactory textbox = new FrameworkElementFactory(typeof(TextBox));
                textbox.SetBinding(TextBox.TextProperty, binding);
                textbox.SetValue(TextBox.MarginProperty, new Thickness(0, 1, 2, 1));
                textbox.SetValue(TextBox.TextWrappingProperty, TextWrapping.Wrap);                
                
                return textbox;
            }
        }
    }
}
