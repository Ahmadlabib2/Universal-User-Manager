// See LICENCE.txt in the root for conditions of use

namespace UUM.Engine

{
	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Linq;
	using System.Xml;
	using System.Text;
	using System.IO;
	// Add references to Soap and Binary formatters.
	using System.Runtime.Serialization.Formatters.Binary;
	using System.Runtime.Serialization;

	/// <summary>
	/// Description of User.
	/// </summary>
	[Serializable]
	[DebuggerDisplay("{Login} [{IsEnabled}]")]
	public class User : ISerializable
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
		//string filepath = "D:/Work/uum/Users.xml";
		#region ISerializable

		public System.Xml.Schema.XmlSchema GetSchema()
		{
			return null;
		}
		
		
		public static void SerializeItem(string filepath, IFormatter formatter)
		{
			// Create an instance of the type and serialize it.
			User t = new User("Ahmed.labib","Ahmed","Labib",false);
			// t.MyProperty = "Hello World";
			FileStream s = new FileStream(filepath , FileMode.Create);
			formatter.Serialize(s, t);
			s.Close();
			Console.WriteLine("Done deserializing");
			Console.ReadLine();
			
		}
		
		public static void DeserializeItem(string filepath, IFormatter formatter)
		{
			DeserializeItem(filepath, formatter); // Deserialize the instance.
			Console.WriteLine("Done Serializing");
			Console.ReadLine();
			FileStream s = new FileStream(filepath, FileMode.Open);
			User t = (User)formatter.Deserialize(s);
			//Console.WriteLine(t.MyProperty);
		}
		#endregion
		
		
		
		
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("props", Login, typeof(string));
		}
	}
}
