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
    public interface IFieldExtensionFactory<TDescription> : IFieldExtensionFactory
        where TDescription : IFieldExtensionDescription
    {
        FrameworkElementFactory Apply(TDescription fieldExtensionDescription,  FrameworkElementFactory frameworkElementFactory);
    }
}
