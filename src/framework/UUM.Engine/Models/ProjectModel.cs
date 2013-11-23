using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.Serialization;
using Catel.Data;
using Catel.IoC;
using UUM.Api.Interfaces;
using UUM.Api.Models;

namespace UUM.Engine.Models
{
	/// <summary>
	///     A ProjectModel contains all data strucutres that have to be stored into a file and
    ///     reloaded later on. This includes the defines Users and their links in other sources,
    ///     parameters to update these users from the remote sources, ...
	/// </summary>
	[Serializable]
	public class ProjectModel : SavableModelBase<ProjectModel>
	{
		public ProjectModel()
		{
            Parameters = new ObservableCollection<ParametersBase>();
		}
		
		protected ProjectModel(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}

		#region Property: Name

        [DefaultValue("<New Project Name>")]
        public string Name
        { get; set; }

		#endregion

		#region Property: Description

        [DefaultValue("<Add Description Here>")]
		public string Description
        { get; set; }
		
		#endregion

		#region Property: UserPool

		public UserPoolModel UserPool
        { get; set; }

		#endregion

		#region Property: Parameters

        public ObservableCollection<ParametersBase> Parameters
        { get; set; }

		#endregion

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
