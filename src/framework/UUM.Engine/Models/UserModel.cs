using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Catel.Data;
using UUM.Api.Interfaces;

namespace UUM.Engine.Models
{
	/// <summary>
	///     User abstraction of his Firstname, Lastname, Emailaddress, Phonenumber, IsEnabled property and LinkedUsers property.
	/// </summary>
	[Serializable]
	public class UserModel : SavableModelBase<UserModel>, IIdentifiable
	{
		public UserModel()
		{
			Id = Guid.NewGuid();
			IsEnabled = true;
			LinkedUsers = new ObservableCollection<Guid>();
		}
		

		protected UserModel(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}

		#region Property: Id

		public Guid Id
		{ get; set; }
		#endregion

		#region Property: FirstName

		public string FirstName
		{ get; set; }
		#endregion

		#region Property: LastName

		public string LastName
		{ get; set; }
		#endregion

		#region Property: EmailAddress

		public string EmailAddress
		{ get; set; }
		#endregion

		#region Property: PhoneNumber

		public string PhoneNumber
		{ get; set; }
		#endregion

		#region Property: IsEnabled


		public bool IsEnabled
		{ get; set; }
		#endregion

		#region Property: LinkedUsers

		public ObservableCollection<Guid> LinkedUsers
		{ get; set; }
		#endregion
	}
}