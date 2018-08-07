using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using WPF.DataForms.Mapping.FieldExtensions;
using WPF.DataForms;
using WPF.DataForms.Mapping;
using WPF.DataForms.Mapping.FieldDescriptions;

namespace WPF.DataForms.Mapping.FieldExtensions
{
    public static class BorderFieldExtensions
    {
        /// <summary>
        /// Label
        /// </summary>
        /// <returns></returns>
        public static IGroupContainer<T, TextBoxDescription> WithBorder<T>(this IGroupContainer<T, TextBoxDescription> root, Color color)
        {
            return root.AddExtension(new BorderExtensionDescription(color));
        }
       
    }
}
