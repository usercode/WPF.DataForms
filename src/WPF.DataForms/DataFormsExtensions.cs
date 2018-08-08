using System;
using System.Collections;
using System.Linq.Expressions;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using WPF.DataForms.Mapping;
using WPF.DataForms.Mapping.FieldDescriptions;
using WPF.DataForms.Mapping.FieldDescriptions.Base;

namespace WPF.DataForms
{
    /// <summary>
    /// DataFormsExtensions
    /// </summary>
    public static class DataFormsExtensions
    {
        /// <summary>
        /// Image
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="root"></param>
        /// <param name="displayName"></param>
        /// <param name="image"></param>
        /// <param name="stretch"></param>
        /// <returns></returns>
        public static IGroupContainer<T, ImageDescription> Image<T>(this IGroupContainer<T> root, String displayName, Expression<PropertyGetter<T>> image, Stretch stretch = Stretch.None)
        {
            var item = new ImageDescription(displayName, PropertyPath.GetPropertyPath(image), stretch);

            return root.AddDescription(item);
        }

        /// <summary>
        /// CheckBox
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="root"></param>
        /// <param name="displayName"></param>
        /// <param name="selectedItem"></param>
        /// <returns></returns>
        public static IGroupContainer<T, CheckBoxDescription> CheckBox<T>(this IGroupContainer<T> root, String displayName, Expression<PropertyGetter<T>> selectedItem)
        {
            var item = new CheckBoxDescription(displayName, PropertyPath.GetPropertyPath(selectedItem));

            return root.AddDescription(item);
        }

        /// <summary>
        /// ComboBox
        /// </summary>
        public static IGroupContainer<T, ComboBoxDescription> ComboBox<T>(this IGroupContainer<T> root, String displayName, Expression<PropertyGetter<T>> selectedItem, Expression<PropertyGetter<T, IEnumerable>> itemsSource)
        {
            var item = new ComboBoxDescription(
                                            displayName,
                                            PropertyPath.GetPropertyPath(selectedItem),
                                            PropertyPath.GetPropertyPath(itemsSource));

            return root.AddDescription(item);
        }

        /// <summary>
        /// ComboBox
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="root"></param>
        /// <param name="displayName"></param>
        /// <param name="selectedItem"></param>
        /// <param name="itemsSource"></param>
        /// <returns></returns>
        public static IGroupContainer<T, ComboBoxDescription> ComboBox<T>(this IGroupContainer<T> root, String displayName, Expression<PropertyGetter<T>> selectedItem, Binding itemsSource)
        {
            var item = new ComboBoxDescription(
                                            displayName,
                                            PropertyPath.GetPropertyPath(selectedItem),
                                            null, 
                                            itemsSource);

            return root.AddDescription(item);
        }

        /// <summary>
        /// Button
        /// </summary>
        /// <param name="displayName"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        public static IGroupContainer<T, ButtonDescription> Button<T>(this IGroupContainer<T> root, String displayName, Expression<PropertyGetter<T, ICommand>> command)
        {
            var item = new ButtonDescription(
                                            displayName, 
                                            PropertyPath.GetPropertyPath(command));

            return root.AddDescription(item);
        }

        public static IGroupContainer<T, CustomDescription> Custom<T>(this IGroupContainer<T> root, String displayName, Type controlType, Action<FrameworkElementFactory> action)
        {
            var item = new CustomDescription(
                                            displayName,
                                            controlType,
                                            action);

            return root.AddDescription(item);
        }

        /// <summary>
        /// Date
        /// </summary>
        /// <param name="displayName"></param>
        /// <param name="selectedDate"></param>
        /// <returns></returns>
        public static IGroupContainer<T, DateDescription> Date<T>(this IGroupContainer<T> root, String displayName, Expression<PropertyGetter<T, DateTime?>> selectedDate)
        {
            var item = new DateDescription(
                                    displayName,
                                    PropertyPath.GetPropertyPath(selectedDate));

            return root.AddDescription(item);
        }

        public static IGroupContainer<T, TreeViewDescription> TreeView<T>(this IGroupContainer<T> root, String displayName, Expression<PropertyGetter<T>> itemsSource, DataTemplate itemTemplate = null)
        {
            var item = new TreeViewDescription(
                                        displayName,
                                        PropertyPath.GetPropertyPath(itemsSource), 
                                        itemTemplate);

            return root.AddDescription(item);
        }

        public static IGroupContainer<T, DateRangeDescription> DateRange<T>(this IGroupContainer<T> root, String displayName, Expression<PropertyGetter<T, DateTime?>> startDate, Expression<PropertyGetter<T, DateTime?>> endDate)
        {
            return root.AddDescription(new DateRangeDescription(
                                                            displayName,
                                                            PropertyPath.GetPropertyPath(startDate),
                                                            PropertyPath.GetPropertyPath(endDate)));
        }

        /// <summary>
        /// ItemsControl
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="root"></param>
        /// <param name="itemsSource"></param>
        /// <param name="itemTemplate"></param>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        /// <param name="itemDefinition"></param>
        /// <returns></returns>
        public static IGroupContainer<T, ItemsControlDescription> ItemsControl<T>(this IGroupContainer<T> root, Expression<PropertyGetter<T>> itemsSource, DataTemplate itemTemplate = null, int? rows = null, int? columns = null, FieldDescription itemDefinition = null)
        {
            var item = new ItemsControlDescription(
                                                PropertyPath.GetPropertyPath(itemsSource),
                                                itemTemplate,
                                                rows,
                                                columns,
                                                itemDefinition
                                                );

            return root.AddDescription(item);
        }

        /// <summary>
        /// Id
        /// </summary>
        /// <returns></returns>
        public static IGroupContainer<T, IdDescription> Id<T>(this IGroupContainer<T> root, String displayName, Expression<PropertyGetter<T>> text, String stringFormat = null)
        {
            var item = new IdDescription(
                        displayName,
                        PropertyPath.GetPropertyPath(text),
                        stringFormat);
            
            return root.AddDescription(item);
        }

        /// <summary>
        /// Label
        /// </summary>
        /// <returns></returns>
        public static IGroupContainer<T, LabelDescription> Label<T>(this IGroupContainer<T> root, String displayName, Expression<PropertyGetter<T>> text, String stringFormat = null)
        {
            var item = new LabelDescription(
                        displayName,
                        PropertyPath.GetPropertyPath(text),
                        stringFormat);


            return root.AddDescription(item);
        }

        /// <summary>
        /// Text
        /// </summary>
        /// <param name="displayName"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static IGroupContainer<T, TextBoxDescription> Text<T>(this IGroupContainer<T> root, String displayName, Expression<PropertyGetter<T>> text, String stringFormat = null, Expression<PropertyGetter<T>> command = null)
        {
            var item = new TextBoxDescription(
                displayName,
                PropertyPath.GetPropertyPath(text),
                stringFormat,
                true,
                PropertyPath.GetPropertyPath(command));

            return root.AddDescription(item);
        }

        /// <summary>
        /// MultiLineText
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="root"></param>
        /// <param name="displayName"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static IGroupContainer<T, MultiLineTextDescription> MultiLineText<T>(this IGroupContainer<T> root, String displayName, Expression<PropertyGetter<T, String>> text)
        {
            var item = new MultiLineTextDescription(
                displayName,
                PropertyPath.GetPropertyPath(text));

            return root.AddDescription(item);            
        }

        /// <summary>
        /// StaticText
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="root"></param>
        /// <param name="text"></param>
        /// <param name="background"></param>
        /// <returns></returns>
        public static IGroupContainer<T, StaticTextDescription> StaticText<T>(this IGroupContainer<T> root, String text)
        {
            return root.AddDescription(new StaticTextDescription(text));            
        }
    }
}
