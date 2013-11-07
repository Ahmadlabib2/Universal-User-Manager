// See LICENCE.txt in the root for conditions of use
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

using Catel.Data;
using UUM.Api.Models;

namespace UUM.Engine.Models
{
	/// <summary>
	/// Description of GroupPoolModel.
	/// </summary>
	[Serializable]
	public class GroupPoolModel : SavableModelBase<GroupPoolModel>
	{
		public GroupPoolModel()
		{
		}
		
		protected GroupPoolModel(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
		
		public static readonly PropertyData UsersInGroupProperty =
			RegisterProperty("UsersInGroup", typeof(ObservableCollection<UserModel>));

		public ObservableCollection<UserModel> UsersInGroup
		{
			get { return GetValue<ObservableCollection<UserModel>>(UsersInGroupProperty); }
			set { SetValue(UsersInGroupProperty, value); }
		}
		
		public void AddUser(UserModel user)
		{
			UsersInGroup.Add(user);
		}

		public void AddUsers(IEnumerable<UserModel> usersToAdd)
		{
			foreach (var user in usersToAdd)
				AddUser(user);
		}
		
	}
}
