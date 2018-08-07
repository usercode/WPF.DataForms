using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.DataForms.Mapping;
using WPF.DataForms.Mapping.Adapters;
using WPF.DataForms.Mapping.FieldDescriptions.Base;
using WPF.DataForms.Mapping.FieldExtensions.Base;

namespace WPF.DataForms
{
    public static class PropertyDefinitionConfiguration
    {
        public static IGroupContainer<T> WithConfig<T>(this IGroupContainer<T> root, Action<IFieldDescription> config)
        {
            config(root.LastDescription);

            return root;
        }

        public static IGroupContainer<T, TField> AddDescription<T, TField>(this IGroupContainer<T> root, TField fieldDescription)
            where TField : IFieldDescription
        {
            root.GroupDescription.FieldDescriptions.Add(fieldDescription);

            return new GroupAdapter<T, TField>(root.GroupDescription, fieldDescription);
        }

        public static IGroupContainer<T, TField> AddExtension<T, TField>(this IGroupContainer<T, TField> root, IFieldExtensionDescription fieldDescription)
            where TField : IFieldDescription
        {
            root.LastDescription.Extensions.Add(fieldDescription);

            return root;
        }
    }
}
