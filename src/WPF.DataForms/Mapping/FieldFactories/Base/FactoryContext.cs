using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.DataForms.Mapping.FieldFactories.Base
{
    /// <summary>
    /// FactoryContext
    /// </summary>
    /// <typeparam name="TFieldDescription"></typeparam>
    public class FactoryContext : IFactoryContext
    {
        public FactoryContext(IDataFormMapping mapping, GuiState guiState)
        {
            Mapping = mapping;
            GuiState = guiState;
        }

        public IDataFormMapping Mapping { get; }

        /// <summary>
        /// GuiStates
        /// </summary>
        public GuiState GuiState { get; }
    }
}
