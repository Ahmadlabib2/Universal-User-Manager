// See LICENCE.txt in the root for conditions of use

namespace UUM.Engin

{
	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Linq;
	using System.Xml;
	using System.Xml.Serialization;

	/// <summary>
	/// Description of User.
	/// </summary>
	[Serializable]
	[DebuggerDisplay("{Login} [{IsEnabled}]")]
	public class User : IXmlSerializable
	{
		public static User DEFAULT = new User("_ not associated _", "", "", false);
		
		//assign the group you get from LDAP here
		public User(string login, string firstname, string lastname, bool enabled)
			
		{
			Firstname = firstname;
			Lastname = lastname;
			IsEnabled = enabled;
			Login = login;
		}
		
		public  String Firstname {get;set;}
		
		public String Lastname {get;set;}
		
		public Boolean IsEnabled {get;set;}

		public String Login {get; private set;}
		
		public override string ToString()
		{
			return string.Format("User: IsEnabled={0}, Login={1}",
			                     IsEnabled, Login);
		}

		#region IXmlSerializable

		public System.Xml.Schema.XmlSchema GetSchema()
		{
			return null;
		}
		
		public void ReadXml(XmlReader reader)
		{
			
			Login = reader.GetAttribute("Id");
			reader.ReadStartElement();
			Firstname = reader.ReadElementString("Firstname");
			Lastname = reader.ReadElementString("Lastname");
			IsEnabled = Convert.ToBoolean(reader.ReadElementString("Active"));
			reader.MoveToContent();
			bool empty = reader.IsEmptyElement;
			reader.ReadEndElement();
		}
		
		
		public void WriteXml(XmlWriter writer)
		{
			
			writer.WriteAttributeString("Id", Login);
			writer.WriteElementString("Firstname", Firstname);
			writer.WriteElementString("Lastname", Lastname);
			writer.WriteElementString("Active", Convert.ToString(IsEnabled));
		}
		#endregion
	
	}
}