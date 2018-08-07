using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.DataForms.Mapping.FieldDescriptions.Base;
using WPF.DataForms.Mapping.FieldDescriptions;

namespace WPF.DataForms.Mapping.Adapters
{
    /// <summary>
    /// GroupAdapter
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GroupAdapter<T, TFieldDescription> : IGroupContainer<T, TFieldDescription>
        where TFieldDescription : IFieldDescription
    {
        public GroupAdapter(GroupDescription groupDescription, IFieldDescription lastField)
        {
            GroupDescription = groupDescription;
            LastDescription = (FieldDescription)lastField;
        }

        public GroupDescription GroupDescription { get; }

        public FieldDescription LastDescription { get; }
        
    }
}
