using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WPF.DataForms;
using WPF.DataForms.Mapping;
using WPF.DataForms.Mapping.Adapters;
using WPF.DataForms.Mapping.FieldDescriptions;

namespace WPF.DataForms
{
    public class DataFormMappingItem<T>
    {
        public DataFormMappingItem()
        {
            GroupCollection = new GroupCollectionDescription();
        }

        public GroupCollectionDescription GroupCollection { get; }
        
        /// <summary>
        /// Group
        /// </summary>
        /// <param name="name"></param>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public IGroupContainer<T> Group(String name, short row = 0, short column = 0, int? rowspan = null, int ? columnspan = null)
        {
            GroupDescription item = new GroupDescription(name, row, column, null, rowspan, columnspan);

            item.ColumnSpan = columnspan;
            item.RowSpan = rowspan;

            GroupCollection.Groups.Add(item);

            return new GroupAdapter<T, GroupDescription>(item, item);
        }
    }
}
