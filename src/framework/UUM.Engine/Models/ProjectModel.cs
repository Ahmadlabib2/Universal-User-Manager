using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

using Catel.Data;
using Catel.IoC;
using UUM.Api.Interfaces;
using UUM.Api.Models;

namespace UUM.Engine.Models
{
	/// <summary>
	/// Project class is used to fetch and distinhuish each project with a name and a description with its own Userpool, plugins, Parameters and Parameter types.
	/// </summary>
	[Serializable]
	public class ProjectModel : SavableModelBase<ProjectModel>
	{
		public ProjectModel()
		{
		}
		
		protected ProjectModel(SerializationInfo info, StreamingContext context)
			: base(info, context) 
        {
        }

        #region Property: Name

        public string Name
		{
			get { return GetValue<string>(NameProperty); }
			set { SetValue(NameProperty, value); }
		}

		public static readonly PropertyData NameProperty =
			RegisterProperty("Name", typeof(string), "<New Project Name>");

        #endregion

        #region Property: Description

        public string Description
		{
			get { return GetValue<string>(DescriptionProperty); }
			set { SetValue(DescriptionProperty, value); }
		}
		
		public static readonly PropertyData DescriptionProperty =
			RegisterProperty("Description", typeof(string), "<Add Description Here>");
    
        #endregion

        #region Property: UserPool

        public UserPoolModel UserPool
        {
            get { return GetValue<UserPoolModel>(UserPoolProperty); }
            set { SetValue(UserPoolProperty, value); }
        }

        public static readonly PropertyData UserPoolProperty =
            RegisterProperty("UserPool", typeof(UserPoolModel), new UserPoolModel());

        #endregion

        #region Property: Parameters
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
        public ObservableCollection<ParametersBase> Parameters
        {
            get { return GetValue<ObservableCollection<ParametersBase>>(ParametersProperty); }
            set { SetValue(ParametersProperty, value); }
        }

        public static readonly PropertyData ParametersProperty =
        	RegisterProperty("Parameters", typeof(ObservableCollection<ParametersBase>), new ObservableCollection<ParametersBase>());

        #endregion
    }

}
