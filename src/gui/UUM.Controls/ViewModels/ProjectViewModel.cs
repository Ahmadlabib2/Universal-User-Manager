// See LICENCE.txt in the root for conditions of use
using System;
using System.Windows;
using Catel.Data;
using Catel.MVVM;
using UUM.Engine;

namespace UUM.Controls.ViewModels
{
	/// <summary>
	/// Description of ProjectViewModel.
	/// </summary>
	public class ProjectViewModel : ViewModelBase
	{
		private readonly Project _model;
		
		public ProjectViewModel()
			: this(null)
		{
		}
		
		public ProjectViewModel(Project model)
		{
			_model = model;
		}
		
		[Model]
		public Project Model
		{
			get { return _model; }
		}

		public Visibility Visibility
		{
			get
			{
				return (Model == null) ? Visibility.Collapsed : Visibility.Visible;
			}
		}
		
		
	}
}
