using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Catel.Data;
using Catel.IoC;
using UUM.Api.Interfaces;

namespace UUM.Api.Models
{
    /// <summary>
    ///     Parameters model which fully supports serialization, property changed notifications,
    ///     backwards compatibility and error checking.
    /// </summary>
    [Serializable]
    [KnownType("GetPluginParameterTypes")]
    public abstract class ParametersBase : SavableModelBase<ParametersBase>
    {
        #region Constructors

        /// <summary>
        ///     Initializes a new object from scratch.
        /// </summary>
        protected ParametersBase(Guid pluginId) 
        {
        	Id = Guid.NewGuid();
            PluginId = pluginId;
        }

        /// <summary>
        ///     Initializes a new object based on <see cref="SerializationInfo" />.
        /// </summary>
        /// <param name="info">
        ///     <see cref="SerializationInfo" /> that contains the information.
        /// </param>
        /// <param name="context">
        ///     <see cref="StreamingContext" />.
        /// </param>
        protected ParametersBase(SerializationInfo info, StreamingContext context)
            : base(info, context) 
        {
        }

        #endregion
		
        #region Properties

        #region Property: Name

        /// <summary>
        ///     Register the name property so it is known in the class.
        /// </summary>
        public static readonly PropertyData NameProperty =
            RegisterProperty("Name", typeof (String), null);

        /// <summary>
        ///     Path to Subversion Configuration File.
        /// </summary>
        public String Name
        {
            get { return GetValue<String>(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        #endregion

        #endregion

        public Guid Id { get; private set; }
        
        public Guid PluginId { get; private set; }

        static Type[] GetPluginParameterTypes()
        {
            var types = new List<Type>();
            var pluginRepository = ServiceLocator.Default.GetService(typeof(IPluginRepository)) as IPluginRepository;
            foreach (var plugin in pluginRepository.Plugins)
            {
                types.Add(plugin.GetParameters().GetType());
            }
            return types.ToArray();
        }        
    }
}