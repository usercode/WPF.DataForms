using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using WPF.DataForms.ValueConverters;
using WPF.DataForms.Mapping.FieldFactories.Base;
using WPF.DataForms.Mapping.FieldDescriptions;
using WPF.DataForms.Mapping.FieldDescriptions.Base;

namespace WPF.DataForms.Mapping.FieldFactories
{
    /// <summary>
    /// GroupDefinition
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GroupFactory : FieldFactory<GroupDescription>
    {
        public override FrameworkElementFactory GenerateField(IFactoryContext context, GroupDescription fieldDescription)
        {
            FrameworkElementFactory root;
            
            root = new FrameworkElementFactory(typeof(DockPanel));

            if (fieldDescription.RowSpan != null)
            {
                root.SetValue(Grid.RowSpanProperty, fieldDescription.RowSpan.Value);
            }

            if (fieldDescription.ColumnSpan != null)
            {
                root.SetValue(Grid.ColumnSpanProperty, fieldDescription.ColumnSpan.Value);
            }

            if (fieldDescription.DataContext != null)
            {
                root.SetBinding(Grid.DataContextProperty, new Binding(fieldDescription.DataContext));
            }

            //group label
            if (!String.IsNullOrEmpty(fieldDescription.DisplayName))
            {
                FrameworkElementFactory labelGroup = new FrameworkElementFactory(typeof(TextBlock));
                labelGroup.SetValue(TextBlock.TextProperty, fieldDescription.DisplayName);
                labelGroup.SetValue(Control.FontWeightProperty, FontWeights.Bold);
                labelGroup.SetValue(FrameworkElement.MarginProperty, new Thickness(2));
                labelGroup.SetValue(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Center);

                FrameworkElementFactory borderForLabelGroup = new FrameworkElementFactory(typeof(Grid));
                borderForLabelGroup.SetValue(Grid.ColumnProperty, 0);
                borderForLabelGroup.SetValue(Grid.ColumnSpanProperty, 2);
                borderForLabelGroup.SetValue(Grid.RowProperty, 0);
                borderForLabelGroup.SetValue(DockPanel.DockProperty, Dock.Top);
                borderForLabelGroup.SetValue(Control.HorizontalAlignmentProperty, HorizontalAlignment.Left);
                borderForLabelGroup.SetValue(Control.VerticalAlignmentProperty, VerticalAlignment.Top);
                
                borderForLabelGroup.AppendChild(labelGroup);
                
                root.AppendChild(borderForLabelGroup);

            }

            int row = 1;

            FrameworkElementFactory grid = new FrameworkElementFactory(typeof(Grid));

            grid.SetValue(FrameworkElement.MarginProperty, new Thickness(4, 0, 4, 4));

            //columns
            FrameworkElementFactory groupColumnLabel = new FrameworkElementFactory(typeof(ColumnDefinition));
            FrameworkElementFactory groupColumnContent = new FrameworkElementFactory(typeof(ColumnDefinition));

            groupColumnLabel.SetValue(ColumnDefinition.WidthProperty, GridLength.Auto);

            grid.AppendChild(groupColumnLabel);
            grid.AppendChild(groupColumnContent);

            //group row
            FrameworkElementFactory rowGroupDefinition = new FrameworkElementFactory(typeof(RowDefinition));
            rowGroupDefinition.SetValue(RowDefinition.HeightProperty, GridLength.Auto);
            grid.AppendChild(rowGroupDefinition);

            //Properties
            foreach (FieldDescription property in fieldDescription.FieldDescriptions)
            {
                FrameworkElementFactory rowDefinition = new FrameworkElementFactory(typeof(RowDefinition));
                if (!property.IsVerticalStretched)
                {
                    rowDefinition.SetValue(RowDefinition.HeightProperty, GridLength.Auto);
                }
                else
                {

                }

                grid.AppendChild(rowDefinition);

                if (property.DisplayName != null)
                {
                    //label
                    FrameworkElementFactory label = new FrameworkElementFactory(typeof(TextBlock));
                    label.SetValue(Grid.ColumnProperty, 0);
                    label.SetValue(Grid.RowProperty, row);
                    label.SetValue(TextBlock.TextProperty, property.DisplayName);
                    label.SetValue(FrameworkElement.MarginProperty, new Thickness(2, 1, 4, 1));
                    label.SetValue(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Top);
                    if (property.Visibiliy != null)
                    {
                        IValueConverter converter = property.VisibilityConverter;

                        if (converter == null)
                        {
                            converter = new NotBoolToVisibilityConverter();
                        }

                        label.SetBinding(FrameworkElement.VisibilityProperty, new Binding(property.Visibiliy) { Converter = converter });
                    }               
                
                    grid.AppendChild(label);
                }

                IFieldFactory factory = context.Mapping.Context.GetFactory(property.GetType());

                //PropertyDefinitions
                FrameworkElementFactory element = factory.CreateField(context, property);
                element.SetValue(Grid.ColumnProperty, 1);
                element.SetValue(Grid.RowProperty, row);
                element.SetValue(FrameworkElement.MarginProperty, new Thickness(0, 0, 0, 1));

                if (property.IsEnabled != null)
                {
                    element.SetValue(FrameworkElement.IsEnabledProperty, property.IsEnabled.Value);
                }

                if (property.Visibiliy != null)
                {
                    IValueConverter converter = property.VisibilityConverter;

                    if (converter == null)
                    {
                        converter = new NotBoolToVisibilityConverter();
                    }

                    element.SetBinding(FrameworkElement.VisibilityProperty, new Binding(property.Visibiliy) { Converter = converter });
                }

                if (property.DisplayName == null)
                {
                    element.SetValue(Grid.ColumnProperty, 0);
                    element.SetValue(Grid.ColumnSpanProperty, 2);
                }

                element.SetValue(FrameworkElement.HorizontalAlignmentProperty, property.HorizontalAlignment);

                if (property.Width != null)
                {
                    element.SetValue(FrameworkElement.WidthProperty, property.Width.Value);
                    element.SetValue(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Left);
                }

                grid.AppendChild(element);

                row++;
            }

            root.AppendChild(grid);


            return root;
        }
    }
}
