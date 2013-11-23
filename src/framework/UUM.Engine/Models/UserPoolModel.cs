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
		}

		protected UserPoolModel(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}

		#region Property: Users

		public static readonly PropertyData UserProperty =
			RegisterProperty("Users", typeof(ObservableCollection<UserModel>), new ObservableCollection<UserModel>());

		public ObservableCollection<UserModel> Users
		{
			get { return GetValue<ObservableCollection<UserModel>>(UserProperty); }
			set { SetValue(UserProperty, value); }
		}

		#endregion

		#region Property: UsersInSources

		public static readonly PropertyData UsersInSourcesProperty =
			RegisterProperty("UsersInSources", typeof(ObservableCollection<UserModel>));

		public ObservableCollection<UserInSourceBase> UsersInSources
		{
			get { return GetValue<ObservableCollection<UserInSourceBase>>(UsersInSourcesProperty); }
			set { SetValue(UsersInSourcesProperty, value); }
		}

		#endregion

		#region Methods

		public void Add(UserModel user)
		{
			Users.Add(user);
		}

		public void Remove(UserModel user)
		{
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