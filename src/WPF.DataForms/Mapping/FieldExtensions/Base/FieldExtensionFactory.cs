using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WPF.DataForms.Mapping.FieldExtensions.Base
{
    class FieldExtensionFactory<TFieldExtensionDescription> : IFieldExtensionFactory<TFieldExtensionDescription>
        where TFieldExtensionDescription : IFieldExtensionDescription
    {
        public Type DescriptionType => typeof(TFieldExtensionDescription);

        FrameworkElementFactory IFieldExtensionFactory.Apply(IFieldExtensionDescription fieldExtensionDescription, FrameworkElementFactory frameworkElementFactory)
        {
            return Apply((TFieldExtensionDescription)fieldExtensionDescription, frameworkElementFactory);
        }

        public virtual FrameworkElementFactory Apply(TFieldExtensionDescription fieldExtensionDescription, FrameworkElementFactory frameworkElementFactory)
        {
            return frameworkElementFactory;
        }
    }
}
