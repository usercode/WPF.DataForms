using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using WPF.DataForms.Mapping.FieldDescriptions;
using WPF.DataForms.Mapping.FieldFactories.Base;

namespace WPF.DataForms.Mapping.FieldFactories
{
    public class ButtonFactoy : FieldFactory<ButtonDescription>
    {
        public override FrameworkElementFactory GenerateField(IFactoryContext context, ButtonDescription fieldDescription)
        {
            FrameworkElementFactory element = new FrameworkElementFactory(typeof(Button));
            element.SetValue(Button.HorizontalAlignmentProperty, HorizontalAlignment.Left);
            element.SetValue(Button.ContentProperty, fieldDescription.Description);
            element.SetBinding(Button.CommandProperty, new Binding(fieldDescription.Command));
            
            
            return element;
        }
    }
}
