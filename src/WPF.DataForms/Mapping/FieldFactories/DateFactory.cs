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
    /// DateDefinition
    /// </summary>
    public class DateFactory : FieldFactory<DateDescription>
    {
        public override FrameworkElementFactory GenerateField(IFactoryContext context, DateDescription fieldDescription)
        {
            FrameworkElementFactory element;

            if (context.GuiState == FormState.View)
            {
                element = CreateReadOnlyTextElement(fieldDescription.SelectedDate, fieldDescription.StringFormat);
            }
            else
            {
                element = new FrameworkElementFactory(typeof(DatePicker));
                element.SetValue(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Left);
                element.SetBinding(DatePicker.SelectedDateProperty, new Binding(fieldDescription.SelectedDate));
            }

            return element;
        }
    }
}
