using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

using Catel.Data;
using Catel.MVVM;
using UUM.Engine.Models;

namespace UUM.Controls.ViewModels
{
	/// <summary>
	///     Viewing and Adding commands within the UserPool.
	/// </summary>
	public class UserPoolViewModel : ViewModelBase
	{
		#region Constructor

		public UserPoolViewModel(UserPoolModel pool)
		{
			UserPool= pool;
			LoadUser = new Command(OnLoadUserExecute);
			AddUser = new Command(OnAddUserExecute);
			RemoveUser = new Command(OnRemoveUserExecute);
			EditUser = new Command(OnEditUserExecute);
		}

		#endregion

		#region Model: UserPool
		public static readonly PropertyData UserPoolProperty =
			RegisterProperty("UserPool", typeof(UserPoolModel), new ObservableCollection<UserPoolModel>());
		
		[Model]
		[Expose("Users")]
		public UserPoolModel UserPool
		{
			get { return GetValue<UserPoolModel>(UserPoolProperty); }
			set { SetValue(UserPoolProperty, value); }
		}
		#endregion

		#region Property: SelectedUser

		public static readonly PropertyData SelectedUserProperty =
			RegisterProperty("SelectedUser", typeof (UserModel));

		public UserModel SelectedUser
		{
			get { return GetValue<UserModel>(SelectedUserProperty); }
			set { SetValue(SelectedUserProperty, value); }
		}

		#endregion

		#region Commands

		#region Command: AddUser

		
		public Command AddUser { get; private set; }

		private void OnAddUserExecute()
		{
			
			UserPool.Add(new UserModel());
		}
		
		#endregion
		
		#region Command: EditUser
		public Command EditUser {get; private set; }
		
		private void OnEditUserExecute()
		{
			throw new NotImplementedException();
			//IEditableObject.BeginEdit();
			
		}
		#endregion
		
		#region Command: LoadUser
		public Command LoadUser {get; private set; }
		
		private void OnLoadUserExecute()
		{
			UserPoolModel.Load("Users.txt");
			
		}
		#endregion

		#region Command: RemoveUser

		public Command RemoveUser { get; private set; }

		private void OnRemoveUserExecute()
		{
			UserPool.Remove(SelectedUser);
		}

		#endregion

		#endregion
	}
}