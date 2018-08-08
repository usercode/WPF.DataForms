using System.Linq;
using System.Windows;
using WPF.DataForms.Mapping;
using WPF.DataForms.Mapping.FieldDescriptions;
using WPF.DataForms.Mapping.FieldFactories.Base;
using WPF.UI.DataForms;

namespace WPF.DataForms
{
    /// <summary>
    /// DataFormMapping
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class DataFormMapping<T> : IDataFormMapping
    {
        protected DataFormMapping()
        {
            Context = DataFormContext.Instance;

            MainContent = new DataFormMappingItem<T>();
            TopContent = new DataFormMappingItem<T>();
            BottomContent = new DataFormMappingItem<T>();

            CreateContent();
        }

        /// <summary>
        /// DefineMapping
        /// </summary>
        public abstract void CreateContent();

        /// <summary>
        /// Context
        /// </summary>
        public DataFormContext Context { get; }

        public DataFormMappingItem<T> MainContent { get; set; }
        public DataFormMappingItem<T> TopContent { get; set; }
        public DataFormMappingItem<T> BottomContent { get; set; }

        public DataTemplate CreateTemplate(FormState guiState, DataFormMapperRegion region = DataFormMapperRegion.MainContent)
        {
            DataTemplate template = new DataTemplate();

            DataFormMappingItem<T> form = new DataFormMappingItem<T>();

            switch (region)
            {
                case DataFormMapperRegion.MainContent:
                    form = MainContent;
                    break;

                case DataFormMapperRegion.Header:
                    form = TopContent;
                    break;

                case DataFormMapperRegion.Footer:
                    form = BottomContent;
                    break;
            }

            if (form.GroupCollection.Groups.Any() == false)
            {
                return template;
            }

            IFieldFactory collectionFactory = Context.GetFactory<GroupCollectionDescription>();

            FactoryContext factoryContext = new FactoryContext(this, guiState);

            FrameworkElementFactory mainGrid = collectionFactory.CreateField(factoryContext, form.GroupCollection);

            template.VisualTree = mainGrid;

            return template;
        }
    }
}
