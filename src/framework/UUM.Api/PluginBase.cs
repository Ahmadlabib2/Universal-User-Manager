using System;
using UUM.Api.Interfaces;
using UUM.Api.Models;

namespace UUM.Api
{
	/// <summary>
	/// PluginBase is used to get or call the plugin details like the GUID, Name of Plugin, Description of Plugin,
	/// Build the repository based on their settings.
	/// </summary>
	public abstract class PluginBase<TParameters, TUserInSource> : IPlugin
		where TParameters : ParametersBase, new()
		where TUserInSource : UserInSourceBase, new()
	{
		protected PluginBase()
		{
			Id = GetType().GUID;
		}
		
		public string Name {
			get; protected set;
		}
		
		public string Description {
			get; protected set;
		}
		
		public Guid Id {
			get; private set;
		}
		
		protected abstract IRepository GetRepositoryInternal(TParameters parameters);

        /// <summary>
        /// Build the repository based on the settings
        /// </summary>
        /// <exception cref="InvalidOperationException">Parameters not belonging to this plugin</exception>
        /// <param name="parameters"></param>
        /// <returns></returns>
	    public IRepository GetRepository(ParametersBase parameters)
		{
			var p = parameters as TParameters;
			if (p == null)
				throw new InvalidOperationException("Parameters not belonging to this plugin");
			return GetRepositoryInternal(p);
		}
		
		public ParametersBase GetParameters()
		{
			return new TParameters();
		}
		
		public Type GetParametersType()
		{
			return typeof(TParameters);
		}

		public Type GetUserInSourceType()
		{
			return typeof(TUserInSource);
		}
	}
}
