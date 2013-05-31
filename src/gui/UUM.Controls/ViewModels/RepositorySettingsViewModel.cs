using Catel.Data;
using Catel.MVVM;
using UUM.Api;

namespace UUM.Controls.ViewModels
{
    /// <summary>
    ///     RepositorySettingsViewModel view model.
    /// </summary>
    public class RepositorySettingsViewModel : ViewModelBase
    {
        public RepositorySettingsViewModel(IParameters parameters)
        {
            Parameters = parameters;
        }

        /// <summary>
        ///     Gets the title of the view model.
        /// </summary>
        /// <value>The title.</value>
        public override string Title
        {
            get { return "RepositorySettings"; }
        }

        #region Properties

        #region Property: Parameters

        public static readonly PropertyData ParametersProperty =
            RegisterProperty("Parameters", typeof (IParameters));

        [Model]
        public IParameters Parameters
        {
            get { return GetValue<IParameters>(ParametersProperty); }
            private set { SetValue(ParametersProperty, value); }
        }

        #endregion

        #endregion

        #region Commands

        #endregion
    }
}