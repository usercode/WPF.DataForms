using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using WPF.DataForms.Mapping.FieldDescriptions.Base;

namespace WPF.DataForms.Mapping.FieldDescriptions
{
    /// <summary>
    /// IdDescription
    /// </summary>
    public class IdDescription : FieldDescription
    {
        public IdDescription(String displayName, String text, String stringFormat = null)
            : base(displayName)
        {
            Text = text;
            StringFormat = stringFormat;
        }

        /// <summary>
        /// Text
        /// </summary>
        public String Text { get; private set; }
        
    }
}
