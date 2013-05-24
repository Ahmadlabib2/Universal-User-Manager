// See LICENCE.txt in the root for conditions of use
using System;
using System.Runtime.Serialization;
using Catel.Data;

namespace UUM.Engine.Models
{
	/// <summary>
	///  Userpool abstraction.
	/// </summary>
	 [Serializable]
	public class UserpoolModel : SavableModelBase<UserpoolModel>
	{
		public UserpoolModel()
		{
		}
		
		protected UserpoolModel(SerializationInfo info, StreamingContext context)
			: base(info, context) { }
		
		
		public string SourceName
		{
			get { return GetValue<string>(SourceNameProperty); }
			set { SetValue(SourceNameProperty, value); }
		}
		
			public static readonly PropertyData SourceNameProperty =
            RegisterProperty("SourceName", typeof(string));
			
		public string User
		{
			get { return GetValue<string>(UserProperty); }
			set { SetValue(UserProperty, value); }
		}
		
			public static readonly PropertyData UserProperty =
            RegisterProperty("User", typeof(UserModel));	

	}
}
