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
    public class TextBoxDescription : FieldDescription
    {
        public TextBoxDescription(String displayName, String text, String stringFormat, bool autoSetColor = true, String command = null)
            : base(displayName)
        {
            Text = text;
            StringFormat = stringFormat;
            AutoSetColor = autoSetColor;
            Command = command;
            HorizontalAlignment = HorizontalAlignment.Stretch;
        }

        public bool AutoSetColor { get; private set; }

        /// <summary>
        /// TextProperty
        /// </summary>
        public String Text { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public String Command { get; private set; }
        
    }
}
