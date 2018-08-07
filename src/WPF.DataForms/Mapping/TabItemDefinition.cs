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
    /// <summary>
    /// TabItemDefinition
    /// </summary>
    public class TabItemDefinition<T> : FieldDescription
    {
        public TabItemDefinition(String name)
        {
            Name = name;
            Groups = new List<GroupDefinition<T>>();
            ShowVerticalScrollBar = false;
        }

        /// <summary>
        /// Name
        /// </summary>
        public String Name { get; private set; }

        public bool ShowVerticalScrollBar { get; set; }

        /// <summary>
        /// Groups
        /// </summary>
        private IList<GroupDefinition<T>> Groups { get; set; }

        public GroupDefinition<T> Group(String displayName, short row, short column, String visible, int? rowspan = null, int? columnspan = null)
        {
            GroupDefinition<T> group = new GroupDefinition<T>(displayName, row, column, visible, rowspan, columnspan);
            
            Groups.Add(group);

            return group;
        }

        public override FrameworkElementFactory CreateFactoryElement(bool isReadOnly, string stringFormat)
        {
            FrameworkElementFactory element = new FrameworkElementFactory(typeof(TabItem));
            element.SetValue(TabItem.HeaderProperty, Name);
            element.SetValue(IgnoreMouseWheelHelper.IgnoreMouseWheelProperty, true);

            FrameworkElementFactory scroll = new FrameworkElementFactory(typeof(ScrollViewer));
            scroll.SetValue(ScrollViewer.HorizontalScrollBarVisibilityProperty, ScrollBarVisibility.Disabled);

            if(ShowVerticalScrollBar)
                scroll.SetValue(ScrollViewer.VerticalScrollBarVisibilityProperty, ScrollBarVisibility.Auto);
            else
                scroll.SetValue(ScrollViewer.VerticalScrollBarVisibilityProperty, ScrollBarVisibility.Disabled);

            GroupCollectionDefinition<T> collection = new GroupCollectionDefinition<T>();
            collection.Groups = Groups;

            DataTemplate dt = new DataTemplate();
            
            dt.VisualTree = scroll;
             
            if (Groups.Count > 0)
            {
                scroll.SetBinding(ScrollViewer.ContentProperty, new Binding());
                scroll.SetValue(ScrollViewer.ContentTemplateProperty, new DataTemplate() { VisualTree = collection.CreateFactoryElement(isReadOnly, stringFormat) });

                element.SetBinding(TabItem.ContentProperty, new Binding());
                element.SetValue(TabItem.ContentTemplateProperty, dt);
            }

            return element;
        }
    }
}
