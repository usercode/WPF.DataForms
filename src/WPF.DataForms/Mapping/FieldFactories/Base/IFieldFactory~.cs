using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF.DataForms.Mapping.FieldDescriptions.Base;

namespace WPF.DataForms.Mapping.FieldFactories.Base
{
    public interface IFieldFactory<in TFieldDescription> : IFieldFactory
        where TFieldDescription : IFieldDescription
    {
        FrameworkElementFactory CreateField(IFactoryContext context, TFieldDescription fieldDescription);
    }
}
