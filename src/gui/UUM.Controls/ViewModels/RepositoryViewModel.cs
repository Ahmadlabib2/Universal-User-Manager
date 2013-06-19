using System;
using System.Collections.ObjectModel;
using Catel.Data;
using Catel.MVVM;
using Catel.MVVM.Services;
using UUM.Api.Interfaces;

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
        public RepositoryViewModel(ObservableCollection<IParameters> parameters)
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

        public static readonly PropertyData ParametersProperty =
            RegisterProperty("Parameters", typeof (ObservableCollection<IParameters>));

        [Model]
        public ObservableCollection<IParameters> Parameters
        {
            get { return GetValue<ObservableCollection<IParameters>>(ParametersProperty); }
            private set { SetValue(ParametersProperty, value); }
        }
         #endregion
         
         #region Property: SelectedParameters
         
        public static readonly PropertyData SelectedParametersProperty =
            RegisterProperty("SelectedParameters", typeof (ObservableCollection<IParameters>));

        
        public ObservableCollection<IParameters> SelectedParameters
        {
            get { return GetValue<ObservableCollection<IParameters>>(SelectedParametersProperty); }
            private set { SetValue(SelectedParametersProperty, value); }
        }
		#endregion
        #endregion

       

        #region Commands

        #region Command: AddRepository

        public Command AddRepository { get; private set; }

        private void OnAddRepositoryExecute()
        {
            var viewModel = new ChoosePluginViewModel();
            var uiVisualizerService = GetService<IUIVisualizerService>();
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
            // TODO: Handle command logic here
            
            Parameters.Remove(SelectedParameters);
        }

        #endregion
        
        #endregion
    }
}