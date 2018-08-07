using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.DataForms
{
    /// <summary>
    /// GuiStates
    /// </summary>
    [Flags]
    public enum GuiState
    {
        View = 1,
        Create = 2,
        Edit = 4
    }
}
