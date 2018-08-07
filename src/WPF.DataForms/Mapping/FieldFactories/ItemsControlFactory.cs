using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using WPF.DataForms.Mapping.FieldDescriptions;
using WPF.DataForms.Mapping.FieldFactories.Base;

namespace WPF.DataForms.Mapping.FieldFactories
{
    /// <summary>
    /// ItemsControlFactory
    /// </summary>
    public class ItemsControlFactory : FieldFactory<ItemsControlDescription>
    {
        public override FrameworkElementFactory GenerateField(IFactoryContext context, ItemsControlDescription fieldDescription)
        {
            FrameworkElementFactory element = new FrameworkElementFactory(typeof(ItemsControl));
            element.SetValue(Grid.IsSharedSizeScopeProperty, true);

            if (fieldDescription.ItemTemplate != null)
            {
                element.SetValue(ItemsControl.ItemTemplateProperty, fieldDescription.ItemTemplate);
            }
            else
            {
                DataTemplate dt = new DataTemplate();

                if (fieldDescription.ItemDefinition != null)
                {
                    IFieldFactory factory = context.Mapping.Context.GetFactory(fieldDescription.ItemDefinition.GetType());

                    dt.VisualTree = factory.CreateField(context, fieldDescription.ItemDefinition);
                }
                else
                {
                    var lbl = new FrameworkElementFactory(typeof(TextBlock));
                    lbl.SetBinding(TextBlock.TextProperty, new Binding());

                    dt.VisualTree = lbl;
                }

                element.SetValue(ItemsControl.ItemTemplateProperty, dt);
            }
            element.SetBinding(ItemsControl.ItemsSourceProperty, new Binding(fieldDescription.ItemsSource));
            
            if (fieldDescription.Rows != null || fieldDescription.Columns != null)
            {
                FrameworkElementFactory uniformPanel = new FrameworkElementFactory(typeof(UniformGrid));

                if (fieldDescription.Rows != null)
                {
                    uniformPanel.SetValue(UniformGrid.RowsProperty, fieldDescription.Rows.Value);
                }

                if (fieldDescription.Columns != null)
                {
                    uniformPanel.SetValue(UniformGrid.ColumnsProperty, fieldDescription.Columns.Value);
                }

                element.SetValue(ItemsControl.ItemsPanelProperty, new ItemsPanelTemplate(uniformPanel));
            }

            FrameworkElementFactory scrollviewer = new FrameworkElementFactory(typeof(ScrollViewer));
            scrollviewer.SetValue(ScrollViewer.HorizontalScrollBarVisibilityProperty, ScrollBarVisibility.Disabled);
            scrollviewer.SetValue(ScrollViewer.VerticalScrollBarVisibilityProperty, ScrollBarVisibility.Auto);
            scrollviewer.AppendChild(element);

            return scrollviewer;
        }
    }
}
