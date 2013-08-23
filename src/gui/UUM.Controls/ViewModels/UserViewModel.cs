using Catel.Data;
using Catel.MVVM;
using UUM.Engine.Models;

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
        public UserViewModel(UserModel model)
        {
            User = model;
            
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the title of the view model.
        /// </summary>
        /// <value>The title.</value>
        public override string Title { get { return "User"; } }

        #region Model

        [Model]
        [Expose("FirstName")]
        [Expose("LastName")]
        [Expose("EmailAddress")]
        [Expose("PhoneNumber")]
         
        public UserModel User
        {
            get { return GetValue<UserModel>(ModelProperty); }
            private set { SetValue(ModelProperty, value); }
        }

        /// <summary>
        /// Register the Model property so it is known in the class.
        /// </summary>
        public static readonly PropertyData ModelProperty =
            RegisterProperty("User", typeof(UserModel));

        #endregion

        #endregion
    	
    }
}
