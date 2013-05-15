// See LICENCE.txt in the root for conditions of use

namespace UUM.Engine
{
	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Linq;
	using System.Runtime.Serialization;
	using System.Xml;
	using System.Text;
	using System.IO;
	
	using Catel.Data;

	/// <summary>
	/// User abstraction
	/// </summary>
	[Serializable]
	public class User : SavableModelBase<User>
	{
		public User()
		{
		}

		protected User(SerializationInfo info, StreamingContext context)
			: base(info, context) { }
		
		public string FirstName
		{
			get { return GetValue<string>(FirstNameProperty); }
			set { SetValue(FirstNameProperty, value); }
		}

		public static readonly PropertyData FirstNameProperty = RegisterProperty("FirstName", typeof(string));

		public string LastName
		{
			get { return GetValue<string>(LastNameProperty); }
			set { SetValue(LastNameProperty, value); }
		}

		public static readonly PropertyData LastNameProperty = RegisterProperty("LastName", typeof(string));

		public Boolean IsEnabled {get;set;}
		
		public String EmailAddress {get; set;}

		public String PhoneNumber {get; set;}

	}
}
