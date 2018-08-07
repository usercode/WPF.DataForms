using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.DataForms.Mapping.FieldDescriptions;
using WPF.DataForms.Mapping.FieldDescriptions.Base;

namespace WPF.DataForms
{
    public interface IGroupContainer<T>
    {
        GroupDescription GroupDescription { get; }

        FieldDescription LastDescription { get; }
    }

    public interface IGroupContainer<T, out TFieldDescription> : IGroupContainer<T>
        where TFieldDescription : IFieldDescription
    {

    }
}
