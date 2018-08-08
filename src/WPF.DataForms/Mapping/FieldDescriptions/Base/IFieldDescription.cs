using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace WPF.DataForms.Mapping.FieldDescriptions.Base
{
    /// <summary>
    /// IFieldDescription
    /// </summary>
    public interface IFieldDescription
    {
        /// <summary>
        /// IsVerticalStretched
        /// </summary>
        bool IsVerticalStretched { get; set; }

        /// <summary>
        /// DisplayName
        /// </summary>
        String DisplayName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        IValueConverter VisibilityConverter { get; set; }

        /// <summary>
        /// Height
        /// </summary>
        double? Height { get; set; }

        /// <summary>
        /// Width
        /// </summary>
        double? Width { get; set; }

        /// <summary>
        /// HorizontalAlignment
        /// </summary>
        HorizontalAlignment HorizontalAlignment { get; set; }

        /// <summary>
        /// IsEnabled
        /// </summary>
        bool? IsEnabled { get; set; }

        /// <summary>
        /// StringFormat
        /// </summary>
        String StringFormat { get; set; }

        /// <summary>
        /// Style
        /// </summary>
        Style Style { get; set; }
    }
}
