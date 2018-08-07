using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using WPF.DataForms.Mapping.FieldDescriptions.Base;

namespace WPF.DataForms.Mapping.FieldDescriptions
{
    /// <summary>
    /// LabelDefinition
    /// </summary>
    public class ImageDescription : FieldDescription
    {
        public ImageDescription(String displayName, String imageSource, Stretch stretch, String stringFormat = null)
            : base(displayName)
        {
            ImageSource = imageSource;
            Stretch = stretch;
        }

        /// <summary>
        /// Text
        /// </summary>
        public String ImageSource { get; private set; }

        /// <summary>
        /// Stretch
        /// </summary>
        public Stretch Stretch { get; }

    }
}
