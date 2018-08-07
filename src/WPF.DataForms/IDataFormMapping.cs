using WPF.UI.DataForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using WPF.DataForms.Mapping;

namespace WPF.DataForms
{
    public interface IDataFormMapping
    {
        DataFormContext Context { get; }

        DataTemplate CreateTemplate(GuiState guiState, DataFormMapperRegion region = DataFormMapperRegion.MainContent);
    }
}
