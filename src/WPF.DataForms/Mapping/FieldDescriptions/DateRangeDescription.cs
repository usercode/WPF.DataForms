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
    public class DateRangeDescription : FieldDescription
    {
        public DateRangeDescription(String displayName, String startDate, String endDate)
            : base(displayName)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        /// <summary>
        /// Date
        /// </summary>
        public String StartDate { get; private set; }

        /// <summary>
        /// EndDate
        /// </summary>
        public String EndDate { get; private set; }
        
    }
}
