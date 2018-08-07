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
    /// LabelDefinition
    /// </summary>
    public class LabelFactory : FieldFactory<LabelDescription>
    {
        public override FrameworkElementFactory GenerateField(IFactoryContext context, LabelDescription fieldDescription)
        {   
            return CreateReadOnlyTextElement(fieldDescription.Text, fieldDescription.StringFormat);
            
        }
    }
}
