using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows;
using System.Windows.Media;
using System.Windows.Input;
using WPF.DataForms.Mapping.FieldDescriptions.Base;

namespace WPF.DataForms.Mapping.FieldDescriptions
{
    /// <summary>
    /// TextDefinintion
    /// </summary>
    public class TreeViewDescription : FieldDescription
    {
        public TreeViewDescription(String displayName, String itemsSource, DataTemplate itemTemplate)
            : base(displayName)
        {
            ItemsSource = itemsSource;
            ItemTemplate = itemTemplate;
        }

        public bool AutoSetColor { get; private set; }

        /// <summary>
        /// TextProperty
        /// </summary>
        public String ItemsSource { get; private set; }

        /// <summary>
        /// ItemTamplate
        /// </summary>
        public DataTemplate ItemTemplate { get; private set; }
    }
}
