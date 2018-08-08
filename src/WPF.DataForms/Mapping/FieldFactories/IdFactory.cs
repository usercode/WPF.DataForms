using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using WPF.DataForms.Mapping.FieldDescriptions;
using WPF.DataForms.Mapping.FieldFactories.Base;

namespace WPF.DataForms.Mapping.FieldFactories
{
    /// <summary>
    /// IdFactory
    /// </summary>
    public class IdFactory : FieldFactory<IdDescription>
    {
        public override FrameworkElementFactory GenerateField(IFactoryContext context, IdDescription fieldDescription)
        {   
            return CreateReadOnlyTextElement(fieldDescription.Text, fieldDescription.StringFormat, TextAlignment.Right);
        }
    }
}
