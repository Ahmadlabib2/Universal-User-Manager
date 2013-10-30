using System;

using Catel.Data;

using UUM.Api.Models;

namespace UUM.Plugin.Subversion.Models
{
    /// <summary>
    ///     User in source class.
    /// </summary>
    [Serializable]
    public class UserInSource : UserInSourceBase
    {
        #region Fields
		
        #endregion

        #region Constructors

        public UserInSource()
        {
        }

        public UserInSource(string login, string firstname, string lastname, string source)
		{
			Source = source;
			FirstName = firstname;
			LastName = lastname;
			//IsEnabled = enabled;
			LoginName = login;
		}

		public UserInSource(UserInSource user)
		{
			Source = user.Source;
			FirstName = user.FirstName;
			LastName = user.LastName;
			LoginName = user.LoginName;
		}
        #endregion

        #region Properties

        #region Property: LoginName

        public static readonly PropertyData LoginNameProperty =
            RegisterProperty("LoginName", typeof (string));

        public string LoginName
        {
            get { return GetValue<string>(LoginNameProperty); }
            set { SetValue(LoginNameProperty, value); }
        }

         public static readonly PropertyData FirstNameProperty =
            RegisterProperty("FirstName", typeof (string));

        public string FirstName
        {
            get { return GetValue<string>(FirstNameProperty); }
            set { SetValue(FirstNameProperty, value); }
        }
        
         public static readonly PropertyData LastNameProperty =
            RegisterProperty("LastName", typeof (string));

        public string LastName
        {
            get { return GetValue<string>(LastNameProperty); }
            set { SetValue(LastNameProperty, value); }
        }
        
         public static readonly PropertyData SourceProperty =
            RegisterProperty("Source", typeof (string));

        public string Source
        {
            get { return GetValue<string>(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }
        
        public override string ToString()
		{
			return string.Format("UserInSource: {2}, IsEnabled={0}, Login={1}", Source);
		}
        #endregion

        #endregion

        #region Methods

        #endregion
    }
}