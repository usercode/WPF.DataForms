using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace WPF.DataForms.Mapping.FieldDescriptions
{
    /// <summary>
    /// MultiLineTextDefinition
    /// </summary>
    public class MultiLineTextDescription : TextBoxDescription
    {
        public MultiLineTextDescription(String displayName, String text)
            : base(displayName, text, null)
        {
        }
    }
}
