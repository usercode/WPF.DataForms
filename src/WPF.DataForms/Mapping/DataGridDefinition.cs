using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using BaseLib.Client.Controls.Data;
using System.Collections;
using System.Windows.Data;
using System.Windows.Controls;
using BaseLib.Client.Controls.ListingControl;

namespace WPF.DataForms.Mapping
{
    public class DataGridDefinition : PropertyDefinition
    {
        public DataGridDefinition(String itemsSource, IEnumerable<SpecialDataGridColumn> columns, Style rowStyle = null)
        {
            ItemsSource = itemsSource;
            Columns = columns;

            ShowControlBar = true;
            IgnoreMouseWheel = false;

            RowStyle = rowStyle;
        }

        /// <summary>
        /// ItemsSource
        /// </summary>
        public String ItemsSource { get; private set; }

        /// <summary>
        /// ShowControlBar
        /// </summary>
        public bool ShowControlBar { get; private set; }

        /// <summary>
        /// RowStyle
        /// </summary>
        public Style RowStyle { get; private set; }

        /// <summary>
        /// Columns
        /// </summary>
        public IEnumerable<SpecialDataGridColumn> Columns { get; private set; } 

        public override FrameworkElementFactory CreateFactoryElement(bool isReadOnly, string stringFormat)
        {
            FrameworkElementFactory root = new FrameworkElementFactory(typeof(Grid));

            FrameworkElementFactory row1 = new FrameworkElementFactory(typeof(RowDefinition));
            row1.SetValue(RowDefinition.HeightProperty, GridLength.Auto);

            FrameworkElementFactory row2 = new FrameworkElementFactory(typeof(RowDefinition));
            //row2.SetValue(RowDefinition.HeightProperty, GridLength.Auto);

            root.AppendChild(row1);
            root.AppendChild(row2);

            //DataGridBar
            FrameworkElementFactory controlBar = new FrameworkElementFactory(typeof(AddRemoveBar));
            controlBar.SetBinding(AddRemoveBar.EntitiesSourceProperty, new Binding(ItemsSource));
            controlBar.SetValue(FrameworkElement.MarginProperty, new Thickness(2));
            controlBar.SetValue(Grid.RowProperty, 0);

            if (ReadOnlyMode != ReadOnlyMode.AlwaysReadOnly && !isReadOnly)
            {
                root.AppendChild(controlBar);
            }

            //DataGrid
            FrameworkElementFactory dataGrid = new FrameworkElementFactory(typeof(SpecialDataGrid));
            dataGrid.SetValue(SpecialDataGrid.ColumnsSourceProperty, Columns);
            dataGrid.SetBinding(SpecialDataGrid.ItemsSourceProperty, new Binding(ItemsSource));
            dataGrid.SetBinding(SpecialDataGrid.SelectedItemProperty, new Binding(ItemsSource + ".SelectedEntity"));
            dataGrid.SetValue(SpecialDataGrid.RowStyleProperty, RowStyle);
            dataGrid.SetValue(FrameworkElement.MarginProperty, new Thickness(2));
            dataGrid.SetValue(Grid.RowProperty, 1);

            if (ReadOnlyMode == ReadOnlyMode.AlwaysReadOnly || isReadOnly)
            {
                dataGrid.SetValue(SpecialDataGrid.IsReadOnlyProperty, true);
            }

            PrepareFactoryElement(dataGrid);

            root.AppendChild(dataGrid);

            return root;
        }
    }
}
