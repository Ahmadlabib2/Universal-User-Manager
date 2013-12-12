using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

using Catel.Data;
using Catel.IoC;

using UUM.Api.Interfaces;

namespace UUM.Api.Models
{
	/// <summary>
	///     Base class for implementing Plugin specific Parameters. The ability
	///     to serialize and deserialize to/from disk is implemented. Automatic
	///     notifications are sent on property changes.
	/// </summary>
	[Serializable()]
	[KnownType("GetPluginTypes")]
	public abstract class ParametersBase : SavableModelBase<ParametersBase>, IParametersBase
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
		protected ParametersBase(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		#endregion

		#region Properties

		#region Property: Name

		/// <summary>
		///     Name of this parameter set.
		/// </summary>
		public String Name { get; set; }

		#endregion

		#region Property: Id

		/// <summary>
		///     Guid that identifies this parameter set.
		/// </summary>
		public Guid Id { get; private set; }

		#endregion

		#endregion

		#region Property: Plugin

		/// <summary>
		/// Determine the associated plugin
		/// </summary>
		public IPlugin Plugin {
			get {
				if (_plugin == null) {
					var pluginRepository = ServiceLocator.Default.ResolveType<IPluginRepository>();
					_plugin = pluginRepository.ResolvePluginFromType(GetType());
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
			var pluginRepository = ServiceLocator.Default.ResolveType<IPluginRepository>();
			foreach (var plugin in pluginRepository.Plugins) {
				types.Add(plugin.GetParametersType());
			}
			return types.ToArray();
		}
		#endregion
	}
}
