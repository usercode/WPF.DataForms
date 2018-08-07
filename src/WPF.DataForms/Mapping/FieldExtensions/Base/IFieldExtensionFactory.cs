using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF.DataForms.Mapping.FieldFactories.Base;

namespace WPF.DataForms.Mapping.FieldExtensions.Base
{
    /// <summary>
    /// IFieldFilter
    /// </summary>
    public interface IFieldExtensionFactory
    {
        Type DescriptionType { get; }

        FrameworkElementFactory Apply(IFieldExtensionDescription fieldExtensionDescription,  FrameworkElementFactory frameworkElementFactory);
    }
}
