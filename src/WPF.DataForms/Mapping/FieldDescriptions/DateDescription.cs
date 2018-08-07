using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using WPF.DataForms.Mapping.FieldDescriptions.Base;

namespace WPF.DataForms.Mapping.FieldDescriptions
{
    /// <summary>
    /// DateDefinition
    /// </summary>
    public class DateDescription : FieldDescription
    {
        public DateDescription(String displayName, String selectedDate)
            : base(displayName)
        {
            SelectedDate = selectedDate;
        }

        /// <summary>
        /// Date
        /// </summary>
        public String SelectedDate { get; private set; }

    }
}
