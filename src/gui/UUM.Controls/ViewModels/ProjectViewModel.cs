using Catel.Data;
using Catel.MVVM;
using UUM.Engine.Models;

namespace UUM.Controls.ViewModels
{
	/// <summary>
	/// Description of ProjectViewModel.
	/// </summary>
	public class ProjectViewModel : ViewModelBase
	{
		public ProjectViewModel(ProjectModel project)
			: base(false)
		{
			Project = project;
		}

        #region Model

        /// <summary>
        /// Gets the title of the view model.
        /// </summary>
        /// <value>The title.</value>
        public override string Title { get { return "Project"; } }

        [Model]
        [Expose("Name")]
        [Expose("Description")]
        [Expose("UserPool")]
        [Expose("Parameters", Mode = ViewModelToModelMode.OneWay)]
        public ProjectModel Project
        {
            get { return GetValue<ProjectModel>(ModelProperty); }
            private set { SetValue(ModelProperty, value); }
        }

        /// <summary>
        /// Register the Model property so it is known in the class.
        /// </summary>
        public static readonly PropertyData ModelProperty =
            RegisterProperty("Project", typeof(ProjectModel));

        #endregion
	}
}
