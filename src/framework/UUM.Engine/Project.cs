// See LICENCE.txt in the root for conditions of use
using System;
using System.Runtime.Serialization;
using Catel.Data;


namespace UUM.Engine
{
	/// <summary>
	/// Description of Project.
	/// </summary>
	[Serializable]
	public class Project : SavableModelBase<Project>
	{
		public Project()
		{
			//UserPool
		}
		
		protected Project(SerializationInfo info, StreamingContext context)
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
