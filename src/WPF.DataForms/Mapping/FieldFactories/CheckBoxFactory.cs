using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using WPF.DataForms.Mapping.FieldDescriptions;
using WPF.DataForms.Mapping.FieldFactories.Base;

namespace WPF.DataForms.Mapping.FieldFactories
{
    public class CheckBoxFactory : FieldFactory<CheckBoxDescription>
    {
        public override FrameworkElementFactory GenerateField(IFactoryContext context, CheckBoxDescription fieldDescription)
        {
            FrameworkElementFactory root = new FrameworkElementFactory(typeof(CheckBox));
            root.SetValue(CheckBox.MarginProperty, new Thickness(2));            
            root.SetValue(CheckBox.IsEnabledProperty, context.GuiState != FormState.View);
            root.SetBinding(CheckBox.IsCheckedProperty, new Binding(fieldDescription.IsChecked) { Mode = BindingMode.TwoWay });

            return root;
        }

    }
}
