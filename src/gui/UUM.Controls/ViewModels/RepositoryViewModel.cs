using System;
using System.Collections.ObjectModel;
using Catel.Data;
using Catel.MVVM;
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
            AddParameter = new Command(OnAddParameterExecute);
            RemoveParameter = new Command(OnRemoveParameterExecute);
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

        #endregion

        #region Commands

        #region Command: AddParameter

        public Command AddParameter { get; private set; }

        private void OnAddParameterExecute()
        {
            // TODO: Select the plugin / repository type to create
            // then add to the list
            throw new NotImplementedException();
        }

        #endregion

        #region Command: RemoveParameter

        public Command RemoveParameter { get; private set; }

        private void OnRemoveParameterExecute()
        {
            // TODO: Handle command logic here
            throw new NotImplementedException();
        }

        #endregion

        #endregion
    }
}