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
    /// CustomPropertyDefinition
    /// </summary>
    public class CustomDescription : FieldDescription
    {
        public CustomDescription(String displayName, Type controlType, Action<FrameworkElementFactory> action)
            : base(displayName)
        {
            CustomControlType = controlType;
            Action = action;
        }

        /// <summary>
        /// 
        /// </summary>
        public Action<FrameworkElementFactory> Action { get; private set; }

        /// <summary>
        /// ControlType
        /// </summary>
        public Type CustomControlType { get; private set; }
        
    }
}
