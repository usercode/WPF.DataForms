using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Controls;
using System.Windows.Media;
using WPF.DataForms.Mapping.Common;
using WPF.DataForms.Mapping.FieldExtensions.Base;

namespace WPF.DataForms.Mapping.FieldDescriptions.Base
{
    /// <summary>
    /// PropertyDefinition
    /// </summary>
    public abstract class FieldDescription : IFieldDescription
    {
        protected Brush ReadOnlyBrush;

        protected FieldDescription()
        {
            Extensions = new List<IFieldExtensionDescription>();
            HorizontalAlignment = HorizontalAlignment.Left;
            ReadOnlyBrush = new SolidColorBrush(Colors.SteelBlue);
            ReadOnlyBrush.Freeze();
        }

        protected FieldDescription(String displayName, String visible = null)
            : this()
        {
            DisplayName = displayName;
            Visibiliy = visible;
        }

        /// <summary>
        /// IsVerticalStretched
        /// </summary>
        public bool IsVerticalStretched { get; set; }
        

        /// <summary>
        /// DisplayName
        /// </summary>
        public String DisplayName { get;  set; }        

        /// <summary>
        /// Visibiliy
        /// </summary>
        public String Visibiliy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IValueConverter VisibilityConverter { get; set; }

        /// <summary>
        /// Height
        /// </summary>
        public double? Height { get; set; }

        /// <summary>
        /// Width
        /// </summary>
        public double? Width { get; set; }

        /// <summary>
        /// HorizontalAlignment
        /// </summary>
        public HorizontalAlignment HorizontalAlignment { get; set; }
        
        /// <summary>
        /// IsEnabled
        /// </summary>
        public bool? IsEnabled { get; set; }

        /// <summary>
        /// StringFormat
        /// </summary>
        public String StringFormat { get; set; }

        /// <summary>
        /// Style
        /// </summary>
        public Style Style { get; set; }

        /// <summary>
        /// Extensions
        /// </summary>
        public IList<IFieldExtensionDescription> Extensions { get; }        

        ///// <summary>
        ///// CreateRemoveItemButton
        ///// </summary>
        ///// <returns></returns>
        //protected FrameworkElementFactory CreateRemoveItemButton()
        //{
        //    //close button
        //    RelayCommand<ItemListContainer> command = new RelayCommand<ItemListContainer>((x) =>
        //    {
        //        x.List.Remove(x.Item);
        //    });

        //    FrameworkElementFactory button = new FrameworkElementFactory(typeof(Button));
        //    button.SetValue(Button.ContentProperty, "x");
        //    button.SetValue(Button.ToolTipProperty, "Entfernen");
        //    button.SetValue(Grid.RowProperty, 0);
        //    button.SetValue(Grid.ColumnProperty, 0);
        //    button.SetValue(Control.MarginProperty, new Thickness(2));
        //    //button.SetValue(Button.CommandProperty, new Binding("DataContext.RemoveItemCommand") { RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(ItemsControl), 1) });
        //    button.SetValue(Button.CommandProperty, command);

        //    MultiBinding binding = new MultiBinding();
        //    binding.Bindings.Add(new Binding());
        //    binding.Bindings.Add(new Binding("ItemsSource") { RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(ItemsControl), 1) });
        //    binding.Converter = new ItemMultiConverter();

        //    button.SetBinding(Button.CommandParameterProperty, binding);

        //    return button;
        //}
    }
}
