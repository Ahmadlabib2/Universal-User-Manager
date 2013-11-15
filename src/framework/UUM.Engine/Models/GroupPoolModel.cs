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

        public ObservableCollection<UserModel> UsersInGroup
        { get; private set; }
		
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
