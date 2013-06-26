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
    public abstract class ParametersBase : SavableModelBase<ParametersBase>, IParameters
    {
        #region Constructors

        /// <summary>
        ///     Initializes a new object from scratch.
        /// </summary>
        protected ParametersBase(Guid pluginId)
        {
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