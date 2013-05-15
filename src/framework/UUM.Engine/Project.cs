// See LICENCE.txt in the root for conditions of use
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml;
using System.Text;
using System.IO;
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
		}
		
		protected Project(SerializationInfo info, StreamingContext context)
			: base(info, context) { }
		
		public string ProjectName
		{
			get { return GetValue<string>(ProjectNameProperty); }
			set { SetValue(ProjectNameProperty, value); }
		}

		public static readonly PropertyData ProjectNameProperty = RegisterProperty("ProjectName", typeof(string));
		
		public string ProjectDescription
		{
			get { return GetValue<string>(ProjectDescriptionProperty); }
			set { SetValue(ProjectDescriptionProperty, value); }
		}
		
		public static readonly PropertyData ProjectDescriptionProperty = RegisterProperty("ProjectDescription", typeof(string));
	}

}
