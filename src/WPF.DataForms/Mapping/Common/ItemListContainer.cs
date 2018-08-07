using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPF.DataForms.Mapping.Common
{
    public class ItemListContainer
    {
        public ItemListContainer(Object item, IList list)
        {
            Item = item;
            List = list;
        }

        public Object Item { get; private set; }

        public IList List { get; private set; }
    }
}
