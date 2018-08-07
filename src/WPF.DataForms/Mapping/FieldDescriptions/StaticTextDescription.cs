using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WPF.DataForms.Mapping.FieldDescriptions.Base;

namespace WPF.DataForms.Mapping.FieldDescriptions
{
    public class StaticTextDescription : FieldDescription
    {
        public StaticTextDescription(String text)
        {
            Text = text;
            
        }

        public String Text { get; set; }
        
    }
}
