using System.Collections.ObjectModel;

using Catel.Data;
using Catel.IoC;
using Catel.MVVM;
using Catel.MVVM.Services;

using UUM.Api.Models;

namespace UUM.Controls.ViewModels
{
    /// <summary>
    ///     RepositoryViewModel view model.
    /// </summary>
    public class RepositoryViewModel : ViewModelBase
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="RepositoryViewModel" /> class.
        /// </summary>
        public RepositoryViewModel(ObservableCollection<IParametersBase> parameters)
        	: base(false)
        {
            Parameters = parameters;
            AddRepository = new Command(OnAddRepositoryExecute);
            RemoveRepository = new Command(OnRemoveRepositoryExecute);
        }

        /// <summary>
        ///     Gets the title of the view model.
        /// </summary>
        /// <value>The title.</value>
        public override string Title
        {
            get { return "RepositoryView"; }
        }

        #region Properties

        #region Property: Parameters

        [Model]
        public ObservableCollection<IParametersBase> Parameters
        { get; private set; }

        #endregion

        #region Property: SelectedParameters

        public ParametersBase SelectedParameters
        { get; set; }

        #endregion

        #endregion

        #region Commands

        #region Command: AddRepository

        public Command AddRepository { get; private set; }

        private void OnAddRepositoryExecute()
        {
            var viewModel = TypeFactory.Default.CreateInstance<ChoosePluginViewModel>();
            var uiVisualizerService = DependencyResolver.Resolve<IUIVisualizerService>();
            if (uiVisualizerService.ShowDialog(viewModel) == true)
            {
                if (viewModel.SelectedPlugin != null)
                {
                    Parameters.Add(viewModel.SelectedPlugin.GetParameters());
                }
            }
        }

        #endregion

        #region Command: RemoveRepository

        public Command RemoveRepository { get; private set; }

        private void OnRemoveRepositoryExecute()
        {
            Parameters.Remove(SelectedParameters);
        }

        #endregion

        #endregion
    }
}