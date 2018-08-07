using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using WPF.DataForms.Mapping.FieldDescriptions.Base;

namespace WPF.DataForms.Mapping.FieldDescriptions
{
    public class ItemsControlDescription : FieldDescription
    {
        public ItemsControlDescription(String itemsSource, DataTemplate itemTemplate, int? rows = null, int? columns = null, FieldDescription itemDefinition = null)
        {
            ItemsSource = itemsSource;
            ItemTemplate = itemTemplate;
            Rows = rows;
            Columns = columns;
            ItemDefinition = itemDefinition;
            HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
        }

        /// <summary>
        /// ItemsSource
        /// </summary>
        public String ItemsSource { get; private set; }

        /// <summary>
        /// ItemTemplate
        /// </summary>
        public DataTemplate ItemTemplate { get; private set; }

        /// <summary>
        /// Columns
        /// </summary>
        public int? Columns { get; private set; }

        /// <summary>
        /// Rows
        /// </summary>
        public int? Rows { get; private set; }

        public FieldDescription ItemDefinition { get; private set; }
        
    }
}
