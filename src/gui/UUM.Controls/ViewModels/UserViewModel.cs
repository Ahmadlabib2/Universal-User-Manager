
using System;
using Catel.MVVM;
using UUM.Engine;

namespace UUM.Controls.ViewModels
{
	/// <summary>
	/// Description of UserViewModel.
	/// </summary>
	public class UserViewModel : ViewModelBase
	{
		private readonly User _model;
		
		public UserViewModel(User model)
		{
			_model = model;
		}
		
		[Model]
		public User Model
		{
			get { return _model; }
		}
	}
}
