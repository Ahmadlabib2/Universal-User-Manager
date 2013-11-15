using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Catel.Data;
using Catel.Fody;
using Catel.IoC;
using UUM.Api.Interfaces;
using UUM.Api.Models;

namespace UUM.Engine.Models
{
	/// <summary>
	/// Project class is used to fetch and distinguish each project with a name and a description with its
	/// own Userpool, plugins, Parameters
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
