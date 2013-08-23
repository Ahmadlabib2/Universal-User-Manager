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
    [KnownType("GetPluginTypes")]
    public abstract class ParametersBase : SavableModelBase<ParametersBase>
    {
        #region Constructors

        /// <summary>
        ///     Initializes a new object from scratch.
        /// </summary>
        protected ParametersBase() 
        {
        	Id = Guid.NewGuid();
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
        ///     Name of this parameter set.
        /// </summary>
        public String Name
        {
            get { return GetValue<String>(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        #endregion

        #region Property: Id

        /// <summary>
        ///     Register the id property so it is known in the class.
        /// </summary>
        public static readonly PropertyData IdProperty =
            RegisterProperty("Id", typeof (Guid), null);

        /// <summary>
        ///     Guid that identifies this parameter set.
        /// </summary>
        public Guid Id
        {
            get { return GetValue<Guid>(IdProperty); }
            private set { SetValue(IdProperty, value); }
        }

        #endregion

        #endregion
        
        #region Property: Plugin
        
        /// <summary>
        /// Determine the associated plugin
        /// </summary>
        public IPlugin Plugin 
        {
        	get
        	{
        		if (_plugin == null)
        		{
					var pluginRepository = ServiceLocator.ResolveType<IPluginRepository>();
		            foreach (var plugin in pluginRepository.Plugins)
		            {
		            	if (plugin.GetParametersType() == GetType())
		            	{
		            		_plugin = plugin;
		            		break;
		            	}
		            }
        		}
        		return _plugin;
        	}
        }
        
        private IPlugin _plugin;
        
        #endregion

        #region KnownTypes
        static Type[] GetPluginTypes()
        {
            var types = new List<Type>();
			var pluginRepository = ServiceLocator.ResolveType<IPluginRepository>();
            foreach (var plugin in pluginRepository.Plugins)
            {
                types.Add(plugin.GetParametersType());
            }
            return types.ToArray();
        }
        #endregion
    }
}