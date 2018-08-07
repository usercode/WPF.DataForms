using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using WPF.DataForms.Mapping.FieldDescriptions.Base;

namespace WPF.DataForms.Mapping.FieldDescriptions
{
    public class GroupCollectionDescription : FieldDescription
    {
        public GroupCollectionDescription()
        {
            Groups = new List<GroupDescription>();

            HorizontalAlignment = HorizontalAlignment.Stretch;
        }

        /// <summary>
        /// Groups
        /// </summary>
        public IList<GroupDescription> Groups { get; set; }

        public string SharedGroupSize { get; set; }
        
    }
}
