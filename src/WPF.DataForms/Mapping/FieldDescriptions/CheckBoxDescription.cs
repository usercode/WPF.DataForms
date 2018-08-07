using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using WPF.DataForms.Mapping;
using WPF.DataForms.Mapping.FieldDescriptions.Base;

namespace WPF.DataForms.Mapping.FieldDescriptions
{
    public class CheckBoxDescription : FieldDescription
    {
        public CheckBoxDescription(String displayName, String isChecked)
            : base(displayName)
        {
            IsChecked = isChecked;
        }

        /// <summary>
        /// IsChecked
        /// </summary>
        public String IsChecked { get; private set; }

    }
}
