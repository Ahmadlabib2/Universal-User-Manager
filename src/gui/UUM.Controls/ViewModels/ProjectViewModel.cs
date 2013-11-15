using Catel.Data;
using Catel.MVVM;
using UUM.Engine.Models;

namespace UUM.Controls.ViewModels
{
    /// <summary>
    /// Viewing the title and description of each Project.
    /// </summary>
    public class ProjectViewModel : ViewModelBase
    {
        public ProjectViewModel(ProjectModel project)
            : base(false)
        {
            Project = project;
        }

        /// <summary>
        /// Gets the title of the view model.
        /// </summary>
        /// <value>The title.</value>
        public override string Title { get { return "Project"; } }

        #region Property: Project

        [Model]
        [Expose("Name")]
        [Expose("Description")]
        [Expose("UserPool")]
        [Expose("Parameters", Mode = ViewModelToModelMode.OneWay)]
        public ProjectModel Project
        { get; private set; }

        #endregion
    }
}
