using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using WPF.DataForms.Mapping.FieldFactories.Base;
using WPF.DataForms.Mapping.FieldDescriptions;

namespace WPF.DataForms.Mapping.FieldFactories
{
    public class GroupCollectionFactory : FieldFactory<GroupCollectionDescription>
    {
        public override FrameworkElementFactory GenerateField(IFactoryContext context, GroupCollectionDescription fieldDescription)
        {
            //main control
            FrameworkElementFactory mainGrid = new FrameworkElementFactory(typeof(Grid));
            mainGrid.SetValue(FrameworkElement.MarginProperty, new Thickness(4));

            int maxMainColumnIndex = fieldDescription.Groups.Max(x => x.Column);
            int maxMainRowIndex = fieldDescription.Groups.Max(x => x.Row);

            //create columns
            for (int i = 0; i <= maxMainColumnIndex; i++)
            {
                FrameworkElementFactory column = new FrameworkElementFactory(typeof(ColumnDefinition));

                GroupDescription foundGroup = fieldDescription.Groups.First(x => x.Column == i);

                if (foundGroup.Width != null)
                {
                    column.SetValue(ColumnDefinition.WidthProperty, new GridLength(foundGroup.Width.Value));
                }
                else
                {
                    column.SetValue(ColumnDefinition.WidthProperty, new GridLength(1, GridUnitType.Star));
                }
                
                mainGrid.AppendChild(column);
            }

            //create rows
            for (int i = 0; i <= maxMainRowIndex; i++)
            {
                FrameworkElementFactory row = new FrameworkElementFactory(typeof(RowDefinition));
                if (!fieldDescription.Groups.Any(x => x.Row == i && x.FieldDescriptions.Any(p => p.IsVerticalStretched)))
                {
                    row.SetValue(RowDefinition.HeightProperty, GridLength.Auto);
                }
                else
                {
                }

                mainGrid.AppendChild(row);
            }

            //Groups by column
            foreach (var groupsByColumn in fieldDescription.Groups
                                                    .GroupBy(x => x.Column)
                                                    .OrderBy(x => x.Key))
            {
                //Groups
                foreach (var groups in groupsByColumn
                                                    .GroupBy(x => x.Row)
                                                    .OrderBy(x => x.Key))
                {
                    FrameworkElementFactory stackpanel = null;

                    if (groups.Count() > 1)
                    {
                        stackpanel = new FrameworkElementFactory(typeof(StackPanel));
                        stackpanel.SetValue(Grid.ColumnProperty, groupsByColumn.Key);
                        stackpanel.SetValue(Grid.RowProperty, groups.Key);
                        stackpanel.SetValue(StackPanel.OrientationProperty, Orientation.Vertical);

                        mainGrid.AppendChild(stackpanel);
                    }

                    IFieldFactory groupFactory = context.Mapping.Context.GetFactory<GroupDescription>();

                    foreach (var group in groups)
                    {    
                        FrameworkElementFactory g = groupFactory.CreateField(context, group);
                        g.SetValue(Grid.RowProperty, group.Row);
                        g.SetValue(Grid.ColumnProperty, group.Column);

                        if (group.ColumnSpan.HasValue)
                        {
                            g.SetValue(Grid.ColumnSpanProperty, group.ColumnSpan.Value);
                        }

                        if (groups.Count() > 1)
                        {
                            stackpanel.AppendChild(g);
                        }
                        else
                        {
                            g.SetValue(Grid.ColumnProperty, groupsByColumn.Key);
                            g.SetValue(Grid.RowProperty, groups.Key);
                            mainGrid.AppendChild(g);
                        }
                    }
                }

            }

            return mainGrid;
        }
    }
}
