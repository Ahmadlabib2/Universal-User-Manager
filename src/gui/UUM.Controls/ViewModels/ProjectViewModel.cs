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
		public ProjectViewModel()
			: this(null)
		{
		}
		
		public ProjectViewModel(Project model)
		{
			Model = model;
		}

        #region Model

        [Model]
        public Project Model
        {
            get { return GetValue<Project>(ModelProperty); }
            private set { SetValue(ModelProperty, value); }
        }

        /// <summary>
        /// Register the Model property so it is known in the class.
        /// </summary>
        public static readonly PropertyData ModelProperty = RegisterProperty("Model", typeof(Project));

        #endregion

		public Visibility Visibility
		{
			get
			{
				return (Model == null) ? Visibility.Collapsed : Visibility.Visible;
			}
		}
		
		
	}
}
