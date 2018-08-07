using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using WPF.Util.Helpers;

namespace WPF.DataForms.Mapping
{
    public class TabControlDefinition<T> : FieldDescription
    {
        public TabControlDefinition()
        {
            TabItems = new List<TabItemDefinition<T>>();
        }

        /// <summary>
        /// Properties
        /// </summary>
        public IList<TabItemDefinition<T>> TabItems { get; private set; }

        public override FrameworkElementFactory CreateFactoryElement(bool isReadOnly, string stringFormat)
        {
            FrameworkElementFactory element = new FrameworkElementFactory(typeof(TabControl));
            element.SetValue(TabControl.MarginProperty, new Thickness(2));
            //element.SetValue(TabControl.VerticalAlignmentProperty, VerticalAlignment.Top);
            element.SetBinding(TabControl.SelectedIndexProperty, new Binding("SelectedTabIndex") { Mode = BindingMode.TwoWay });
            element.SetValue(IgnoreMouseWheelHelper.IgnoreMouseWheelProperty, true);

            foreach (var t in TabItems)
            {
                FrameworkElementFactory tabItemFactory = t.CreateFactoryElement(isReadOnly, stringFormat);

                element.AppendChild(tabItemFactory);
            }

            return element;
        }

        public TabControlDefinition<T> AddTabItem(String name, Action<TabItemDefinition<T>> d)
        {
            TabItemDefinition<T> item = new TabItemDefinition<T>(name);

            if(d != null)
                d(item);

            TabItems.Add(item);

            return this;
        }
    }
}
