using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Catel.Data;
using UUM.Api.Interfaces;

namespace UUM.Engine.Models
{
	/// <summary>
	/// Description of Project.
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

        public ObservableCollection<IParameters> Parameters
        {
            get { return GetValue<ObservableCollection<IParameters>>(ParametersProperty); }
            set { SetValue(ParametersProperty, value); }
        }

        public static readonly PropertyData ParametersProperty =
        	RegisterProperty("Parameters", typeof(ObservableCollection<IParameters>), new ObservableCollection<IParameters>());

        #endregion
    }

}
