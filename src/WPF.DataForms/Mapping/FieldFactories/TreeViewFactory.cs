using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows;
using System.Windows.Media;
using System.Windows.Input;
using WPF.DataForms.Mapping.FieldFactories.Base;
using WPF.DataForms.Mapping.FieldDescriptions;

namespace WPF.DataForms.Mapping.FieldFactories
{
    /// <summary>
    /// TextDefinintion
    /// </summary>
    public class TreeViewFactory : FieldFactory<TreeViewDescription>
    {
        public override FrameworkElementFactory GenerateField(IFactoryContext context, TreeViewDescription fieldDescription)
        {
            FrameworkElementFactory treeView = new FrameworkElementFactory(typeof(TreeView));
            treeView.SetValue(TreeView.BorderThicknessProperty, new Thickness(0));
            treeView.SetValue(ScrollViewer.HorizontalScrollBarVisibilityProperty, ScrollBarVisibility.Disabled);
            
            if (fieldDescription.ItemTemplate != null)
            {
                treeView.SetValue(TreeView.ItemTemplateProperty, fieldDescription.ItemTemplate);
            }

            treeView.SetBinding(TreeView.ItemsSourceProperty, new Binding(fieldDescription.ItemsSource));

            return treeView;
        }
    }
}
