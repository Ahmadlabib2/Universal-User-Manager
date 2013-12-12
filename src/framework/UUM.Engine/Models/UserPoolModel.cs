using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;

using Catel.Data;
using UUM.Api.Models;

namespace UUM.Engine.Models
{
	/// <summary>
	///     UserPool: Pool containing the users from different plugins (i.e different sources).
	/// </summary>
	[Serializable]
	public class UserPoolModel : SavableModelBase<UserPoolModel>
		
	{
		public UserPoolModel()
		{
			Users = new ObservableCollection<UserModel>();
			UsersInSources = new ObservableCollection<UserInSourceBase>();
		}
		
		protected UserPoolModel(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}

		public int Counter {get;set;}

		#region Property: Users

		public ObservableCollection<UserModel> Users
		{ get; set;}

		#endregion

		#region Property: UsersInSources

		public ObservableCollection<UserInSourceBase> UsersInSources
		{ get; set;}

		#endregion

		#region Methods

		public void Add(UserModel user)
		{
			Counter++;
			Users.Add(user);
		}

		public void Remove(UserModel user)
		{
			Counter--;
			Users.Remove(user);
		}

		public UserModel FindUserInSourceById(Guid id)
		{
			return Users.SingleOrDefault(x => x.Id == id);
		}
		
		#region Load/Save
		
		public static UserPoolModel Load(String filePath)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(UserPoolModel));
			using (var xmlReader = XmlReader.Create(filePath))
			{
				return serializer.Deserialize(xmlReader) as UserPoolModel;
			}
		}
		
		public new void Save(String filePath)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(UserPoolModel));
			XmlWriterSettings settings = new XmlWriterSettings();
			settings.Indent = true;
			using (var xmlWriter = XmlWriter.Create(filePath, settings))
			{
				serializer.Serialize(xmlWriter, this);
			}
		}
		
		#endregion
		#endregion
	}
}