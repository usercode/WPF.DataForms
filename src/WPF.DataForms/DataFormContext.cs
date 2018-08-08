using System;
using System.Collections.Generic;
using WPF.DataForms.Mapping;
using WPF.DataForms.Mapping.FieldDescriptions;
using WPF.DataForms.Mapping.FieldDescriptions.Base;
using WPF.DataForms.Mapping.FieldExtensions;
using WPF.DataForms.Mapping.FieldExtensions.Base;
using WPF.DataForms.Mapping.FieldFactories;
using WPF.DataForms.Mapping.FieldFactories.Base;

namespace WPF.UI.DataForms
{
    /// <summary>
    /// DataFormContext
    /// </summary>
    public class DataFormContext
    {
        private static DataFormContext _instance;

        /// <summary>
        /// Instance
        /// </summary>
        public static DataFormContext Instance { get => _instance; private set => _instance = value; }

        static DataFormContext()
        {
            Instance = new DataFormContext();

            Instance.Register<GroupCollectionDescription, GroupCollectionFactory>();
            Instance.Register<GroupDescription, GroupFactory>();

            Instance.Register<IdDescription, IdFactory>();
            Instance.Register<ButtonDescription, ButtonFactoy>();
            Instance.Register<LabelDescription, LabelFactory>();
            Instance.Register<StaticTextDescription, StaticTextFactory>();
            Instance.Register<TextBoxDescription, TextBoxFactoy>();
            Instance.Register<CheckBoxDescription, CheckBoxFactory>();
            Instance.Register<MultiLineTextDescription, MultiLineTextFactory>();
            Instance.Register<ImageDescription, ImageFactory>();
            Instance.Register<ItemsControlDescription, ItemsControlFactory>();

            //extesnions
            Instance.RegisterExtension<BorderExtensionDescription, BorderExtensionFactory>();
        }

        public DataFormContext()
        {
            _factoriesByFieldDescription = new Dictionary<Type, IFieldFactory>();
            _extensions = new Dictionary<Type, IFieldExtensionFactory>();
        }

        private IDictionary<Type, IFieldExtensionFactory> _extensions;

        public IEnumerable<IFieldExtensionFactory> GetExtensionFactories()
        {
            return _extensions.Values;
        }

        /// <summary>
        /// Register
        /// </summary>
        /// <typeparam name="TDescription"></typeparam>
        /// <typeparam name="TFactory"></typeparam>
        public void RegisterExtension<TDescription, TFactory>()
            where TDescription : IFieldExtensionDescription
            where TFactory : IFieldExtensionFactory<TDescription>, new()
        {
            if (_extensions.TryGetValue(typeof(TDescription), out IFieldExtensionFactory factoryType) == false)
            {
                _extensions.Add(typeof(TDescription), new TFactory());
            }
            else
            {
                _extensions[typeof(TDescription)] = new TFactory();
            }
        }

        private IDictionary<Type, IFieldFactory> _factoriesByFieldDescription;

        /// <summary>
        /// Register
        /// </summary>
        /// <typeparam name="TDescription"></typeparam>
        /// <typeparam name="TFactory"></typeparam>
        public void Register<TDescription, TFactory>()
            where TDescription : IFieldDescription
            where TFactory : IFieldFactory<TDescription>, new()
        {
            if (_factoriesByFieldDescription.TryGetValue(typeof(TDescription), out IFieldFactory factoryType) == false)
            {
                _factoriesByFieldDescription.Add(typeof(TDescription), new TFactory());
            }
            else
            {
                _factoriesByFieldDescription[typeof(TDescription)] = new TFactory();
            }
        }

        public IFieldExtensionFactory GetExtensionFactory<TFileExtensionFactory>(Type descriptionType)
            where TFileExtensionFactory : IFieldExtensionFactory
        {
            return GetExtensionFactory(typeof(TFileExtensionFactory));
        }

        public IFieldExtensionFactory GetExtensionFactory(Type descriptionType)
        {
            if (_extensions.TryGetValue(descriptionType, out IFieldExtensionFactory factory) == true)
            {
                return factory;
            }

            throw new Exception($"Extension {descriptionType} not found.");
        }

        public IFieldFactory GetFactory<TFileDescription>()
            where TFileDescription : IFieldDescription
        {
            return GetFactory(typeof(TFileDescription));
        }

        public IFieldFactory GetFactory(Type descriptionType)
        {
            if (_factoriesByFieldDescription.TryGetValue(descriptionType, out IFieldFactory factory) == true)
            {
                return factory;
            }

            throw new Exception($"Factory {descriptionType} not found.");
        }
    }
}
