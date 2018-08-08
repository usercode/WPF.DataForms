using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.DataForms;
using WPF.DataForms.Mapping;

namespace WPF.DataForms.Mapping.FieldFactories.Base
{
    /// <summary>
    /// FactoryContext
    /// </summary>
    /// <typeparam name="TFieldDescription"></typeparam>
    public interface IFactoryContext
    {
        IDataFormMapping Mapping { get; }

        /// <summary>
        /// GuiStates
        /// </summary>
        FormState FormState { get; }
    }
}
