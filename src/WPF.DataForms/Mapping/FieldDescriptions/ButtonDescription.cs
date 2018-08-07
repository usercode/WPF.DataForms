using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using WPF.DataForms.Mapping.FieldDescriptions.Base;

namespace WPF.DataForms.Mapping.FieldDescriptions
{
    public class ButtonDescription : FieldDescription
    {
        public ButtonDescription(String description, String command, Binding binding = null)
        {
            Description = description;
            Command = command;
            HorizontalAlignment = HorizontalAlignment.Left;
            Binding = binding;
        }

        /// <summary>
        /// Description
        /// </summary>
        public String Description { get; private set; }

        /// <summary>
        /// Command
        /// </summary>
        public String Command { get; private set; }

        /// <summary>
        /// Binding
        /// </summary>
        public Binding Binding { get; private set; }
        
    }
}
