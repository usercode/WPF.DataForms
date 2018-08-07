using System;
using System.Collections.Generic;
using WPF.DataForms.Mapping.FieldDescriptions.Base;

namespace WPF.DataForms.Mapping.FieldDescriptions
{
    /// <summary>
    /// GroupDefinition
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GroupDescription : FieldDescription
    {
        public GroupDescription(String displayName, short row, short column, String visible, int? rowspan = null, int? columnspan = null)
            : base(displayName, visible)
        {
            Row = row;
            Column = column;
            FieldDescriptions = new List<IFieldDescription>();

            RowSpan = rowspan;
            ColumnSpan = columnspan;
        }

        /// <summary>
        /// Row
        /// </summary>
        public int Row { get; private set; }

        /// <summary>
        /// Column
        /// </summary>
        public int Column { get; private set; }

        /// <summary>
        /// RowSpan
        /// </summary>
        public int? RowSpan { get; set; }

        /// <summary>
        /// ColumnSpan
        /// </summary>
        public int? ColumnSpan { get; set; }

        public String DataContext { get; set; }

        /// <summary>
        /// FieldDescriptions
        /// </summary>
        public IList<IFieldDescription> FieldDescriptions { get; private set; }
             
    }
}
