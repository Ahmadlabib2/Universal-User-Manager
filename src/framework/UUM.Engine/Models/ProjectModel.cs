using System;
using System.Runtime.Serialization;
using Catel.Data;

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
			//UserPool
		}
		
		protected ProjectModel(SerializationInfo info, StreamingContext context)
			: base(info, context) { }
		
		public string Name
		{
			get { return GetValue<string>(NameProperty); }
			set { SetValue(NameProperty, value); }
		}

		public static readonly PropertyData NameProperty =
			RegisterProperty("Name", typeof(string), "<New Project Name>");
		
		public string Description
		{
			get { return GetValue<string>(DescriptionProperty); }
			set { SetValue(DescriptionProperty, value); }
		}
		
		public static readonly PropertyData DescriptionProperty =
			RegisterProperty("Description", typeof(string), "<Add Description Here>");
	}

}
