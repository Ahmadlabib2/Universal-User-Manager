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

		public string EmailAddress
		{
			get { return GetValue<string>(EmailAddressProperty); }
			set { SetValue(EmailAddressProperty, value); }
		}

		public static readonly PropertyData EmailAddressProperty = RegisterProperty("EmailAddress", typeof(string));
		
		public string PhoneNumber
		{
			get { return GetValue<string>(PhoneNumberProperty); }
			set { SetValue(PhoneNumberProperty, value); }
		}

		public static readonly PropertyData PhoneNumberProperty = RegisterProperty("PhoneNumber", typeof(string));
		
		public bool IsEnabled
		{
			get { return GetValue<bool>(IsEnabledProperty); }
			set { SetValue(IsEnabledProperty, value); }
		}

		public static readonly PropertyData IsEnabledProperty = RegisterProperty("IsEnabled", typeof(bool), true);
		
		
	}
}
