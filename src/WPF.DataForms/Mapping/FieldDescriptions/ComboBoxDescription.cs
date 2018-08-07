using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Data;
using WPF.DataForms.Mapping.FieldDescriptions.Base;

namespace WPF.DataForms.Mapping.FieldDescriptions
{
    public class ComboBoxDescription : FieldDescription
    {
        public ComboBoxDescription(String displayName, String selectedItem, String itemsSource, Binding itemsSourceBinding = null)
            : base(displayName)
        {
            SelectedItem = selectedItem;
            ItemsSource = itemsSource;
            ItemsSourceBinding = itemsSourceBinding;
            HorizontalAlignment = HorizontalAlignment.Stretch;
        }

        /// <summary>
        /// SelectedItem
        /// </summary>
        public String SelectedItem { get; private set; }
        
        /// <summary>
        /// ItemsSource
        /// </summary>
        public String ItemsSource { get; private set; }

        /// <summary>
        /// ItemsSourceBinding
        /// </summary>
        public Binding ItemsSourceBinding { get; set; }

        /// <summary>
        /// GroupTemplate
        /// </summary>
        public DataTemplate GroupTemplate { get; set; }
        
    }
}
