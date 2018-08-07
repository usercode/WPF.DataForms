using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Data;
using WPF.DataForms.Mapping.FieldFactories.Base;
using WPF.DataForms.Mapping.FieldDescriptions;

namespace WPF.DataForms.Mapping.FieldFactories
{
    public class ComboBoxFactory : FieldFactory<ComboBoxDescription>
    {
        public override FrameworkElementFactory GenerateField(IFactoryContext context, ComboBoxDescription fieldDescription)
        {
            FrameworkElementFactory element = new FrameworkElementFactory(typeof(ComboBox));

            if (context.GuiState == GuiState.View)
            {
                element = CreateReadOnlyTextElement(fieldDescription.SelectedItem, fieldDescription.StringFormat);
            }
            else
            {
                element = new FrameworkElementFactory(typeof(ComboBox));
                element.SetValue(ComboBox.MinWidthProperty, 120d);
                element.SetValue(ScrollViewer.CanContentScrollProperty, false);
                element.SetValue(ComboBox.IsReadOnlyProperty, true);
                //element.SetValue(ComboBox.HorizontalAlignmentProperty, HorizontalAlignment.Stretch);
                element.SetBinding(TextBlock.ToolTipProperty, new Binding(fieldDescription.SelectedItem));

                if (fieldDescription.GroupTemplate != null)
                {
                    GroupStyle groupStyle = new GroupStyle();
                    groupStyle.HeaderTemplate = fieldDescription.GroupTemplate;
                }

                if (fieldDescription.SelectedItem != null)
                {
                    element.SetValue(ComboBox.SelectedItemProperty, new Binding(fieldDescription.SelectedItem) { Mode = BindingMode.TwoWay });
                }

                element.SetValue(ComboBox.ItemTemplateProperty, CreateItemTemplate());

                if (fieldDescription.ItemsSource != null)
                {
                    element.SetValue(ComboBox.ItemsSourceProperty, new Binding(fieldDescription.ItemsSource));
                }
            }

            return element;
        }

        protected virtual DataTemplate CreateItemTemplate()
        {
            DataTemplate itemTemplate = new DataTemplate();

            FrameworkElementFactory lblComboxBoxItem = new FrameworkElementFactory(typeof(TextBlock));
            lblComboxBoxItem.SetBinding(TextBlock.TextProperty, new Binding());
            lblComboxBoxItem.SetValue(TextBlock.TextWrappingProperty, TextWrapping.NoWrap);
            lblComboxBoxItem.SetValue(TextBlock.TextTrimmingProperty, TextTrimming.CharacterEllipsis);
            lblComboxBoxItem.SetValue(TextBlock.VerticalAlignmentProperty, VerticalAlignment.Top);

            itemTemplate.VisualTree = lblComboxBoxItem;

            return itemTemplate;
        }
    }
}
