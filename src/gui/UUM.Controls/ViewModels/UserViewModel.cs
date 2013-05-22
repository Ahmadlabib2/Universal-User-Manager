using Catel.Data;
using Catel.MVVM;
using UUM.Engine;

namespace UUM.Controls.ViewModels
{
    /// <summary>
    /// User view model.
    /// </summary>
    public class UserViewModel : ViewModelBase
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="UserViewModel"/> class.
        /// </summary>
        public UserViewModel(User model)
        {
            Model = model;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the title of the view model.
        /// </summary>
        /// <value>The title.</value>
        public override string Title { get { return "User view model"; } }

        #region Model

        [Model]
        public User Model
        {
            get { return GetValue<User>(ModelProperty); }
            private set { SetValue(ModelProperty, value); }
        }

        /// <summary>
        /// Register the Model property so it is known in the class.
        /// </summary>
        public static readonly PropertyData ModelProperty = RegisterProperty("Model", typeof(User));

        #endregion

        #endregion
    }
}
