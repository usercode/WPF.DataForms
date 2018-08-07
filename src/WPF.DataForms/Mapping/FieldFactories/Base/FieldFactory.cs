using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using WPF.DataForms.Mapping.FieldDescriptions.Base;
using WPF.DataForms.Mapping.FieldExtensions.Base;

namespace WPF.DataForms.Mapping.FieldFactories.Base
{
    public abstract class FieldFactory<TFieldDescription> : IFieldFactory<TFieldDescription>
        where TFieldDescription : FieldDescription
    {
        public abstract FrameworkElementFactory GenerateField(IFactoryContext context, TFieldDescription fieldDescription);

        FrameworkElementFactory IFieldFactory.CreateField(IFactoryContext context, IFieldDescription fieldDescription)
        {
            return CreateField(context, (TFieldDescription)fieldDescription);
        }

        public FrameworkElementFactory CreateField(IFactoryContext context, TFieldDescription fieldDescription)
        {
            FrameworkElementFactory result = GenerateField(context, fieldDescription);

            foreach (IFieldExtensionFactory extension in context.Mapping.Context.GetExtensionFactories())
            {
                IFieldExtensionDescription foundDescription = fieldDescription.Extensions.FirstOrDefault(x => x.GetType() == extension.DescriptionType);

                if (foundDescription != null)
                {
                    result = extension.Apply(foundDescription, result);
                }
            }

            return result;
        }

        /// <summary>
        /// CreateReadOnlyTextElement
        /// </summary>
        /// <returns></returns>
        protected FrameworkElementFactory CreateReadOnlyTextElement(String text, String stringFormat)
        {
            Binding binding = new Binding(text);
            binding.StringFormat = stringFormat;
            binding.Mode = BindingMode.OneWay;

            FrameworkElementFactory textbox = new FrameworkElementFactory(typeof(TextBox));
            textbox.SetBinding(TextBox.TextProperty, binding);
            textbox.SetValue(TextBox.TextWrappingProperty, TextWrapping.Wrap);
            textbox.SetValue(TextBox.MarginProperty, new Thickness(0));
            textbox.SetValue(TextBox.BackgroundProperty, null);
            textbox.SetValue(TextBox.BorderThicknessProperty, new Thickness(0));
            textbox.SetValue(TextBox.MinWidthProperty, 50d);
            textbox.SetValue(TextBox.HorizontalAlignmentProperty, HorizontalAlignment.Stretch);
            textbox.SetValue(TextBox.IsReadOnlyProperty, true);

            return textbox;
        }

      
    }
}
