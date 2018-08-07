using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using WPF.DataForms.Mapping.FieldExtensions.Base;

namespace WPF.DataForms.Mapping.FieldExtensions
{
    class BorderExtensionDescription : FieldExtensionDescription
    {
        public BorderExtensionDescription(Color color)
        {
            Color = color;
        }

        public Color Color { get; set; }
    }
}
