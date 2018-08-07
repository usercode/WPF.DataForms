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
    public class DateRangeFactory : FieldFactory<DateRangeDescription>
    {
        public override FrameworkElementFactory GenerateField(IFactoryContext context, DateRangeDescription fieldDescription)
        {            
            //From
            FrameworkElementFactory elementFrom = new FrameworkElementFactory(typeof(DatePicker));
            elementFrom.SetValue(DatePicker.MarginProperty, new Thickness(0, 0, 0, 0));
            elementFrom.SetValue(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Left);
            elementFrom.SetBinding(DatePicker.SelectedDateProperty, new Binding(fieldDescription.StartDate));

            //To
            FrameworkElementFactory elementTo = new FrameworkElementFactory(typeof(DatePicker));
            elementTo.SetValue(DatePicker.MarginProperty, new Thickness(4, 0, 0, 0));
            elementTo.SetValue(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Left);
            elementTo.SetBinding(DatePicker.SelectedDateProperty, new Binding(fieldDescription.EndDate));

            //Panel
            FrameworkElementFactory stack = new FrameworkElementFactory(typeof(StackPanel));
            stack.SetValue(StackPanel.OrientationProperty, Orientation.Horizontal);
            stack.AppendChild(elementFrom);
            stack.AppendChild(elementTo);

            return stack;
        }
    }
}
