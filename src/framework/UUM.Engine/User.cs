// See LICENCE.txt in the root for conditions of use

namespace UUM.Engin

{
	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Linq;
	using System.Xml;
	using System;
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
		string filepath = "";
		#region ISerializable

		public System.Xml.Schema.XmlSchema GetSchema()
		{
			return null;
		}
		
		public void WriteXml(XmlReader reader)
		{
			
			//Login = reader.GetAttribute("Id");
			//reader.ReadStartElement();
			//Firstname = reader.ReadElementString("Firstname");
			//Lastname = reader.ReadElementString("Lastname");
			//IsEnabled = Convert.ToBoolean(reader.ReadElementString("Active"));
			//reader.MoveToContent();
			//bool empty = reader.IsEmptyElement;
			//reader.ReadEndElement();

        IFormatter formatter = new BinaryFormatter();
       	SerializeItem(filepath, formatter); // Serialize an instance of the class.
        Console.WriteLine("Done deserializing");
        Console.ReadLine();
    }

    public static void SerializeItem(string filepath, IFormatter formatter)
    {
        // Create an instance of the type and serialize it.
        User t = new User("Ahmed.labib","Ahmed","Labib",false);
       // t.MyProperty = "Hello World";
        FileStream s = new FileStream(filepath , FileMode.Create);
        formatter.Serialize(s, t);            
        s.Close();
    }
    
		
		
		
		public void ReadXml(XmlWriter writer)
		{
			
		//	writer.WriteAttributeString("Id", Login);
		//	writer.WriteElementString("Firstname", Firstname);
		//	writer.WriteElementString("Lastname", Lastname);
		//	writer.WriteElementString("Active", Convert.ToString(IsEnabled));
		IFormatter formatter = new BinaryFormatter();
		 	DeserializeItem(filepath, formatter); // Deserialize the instance.
			Console.WriteLine("Done Serializing");
        	Console.ReadLine();
		
		}
		 public static void DeserializeItem(string filepath, IFormatter formatter)
    {
        FileStream s = new FileStream(filepath, FileMode.Open);
        User t = (User)formatter.Deserialize(s);
        //Console.WriteLine(t.MyProperty);            
    }       
		#endregion
	
		
	
		
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			throw new NotImplementedException();
		}
	}
}
