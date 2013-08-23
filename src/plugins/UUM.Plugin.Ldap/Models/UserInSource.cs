using System;
using System.Runtime.Serialization;
using Catel.Data;
using UUM.Api.Interfaces;
using UUM.Api.Models;

namespace UUM.Plugin.Ldap.Models
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

        #endregion

        #region Properties

        #region Property: UserAccountControl

        public static readonly PropertyData UserAccountControlProperty =
            RegisterProperty("UserAccountControl", typeof (Int32));

        public string UserAccountControl
        {
            get { return GetValue<string>(UserAccountControlProperty); }
            set { SetValue(UserAccountControlProperty, value); }
        }

        #endregion

        #region Property: GivenName

        public static readonly PropertyData GivenNameProperty =
            RegisterProperty("GivenName", typeof (string));

        public string GivenName
        {
            get { return GetValue<string>(GivenNameProperty); }
            set { SetValue(GivenNameProperty, value); }
        }

        #endregion

        #region Property: DisplayName

        public static readonly PropertyData DisplayNameProperty =
            RegisterProperty("DisplayName", typeof (string));

        public string DisplayName
        {
            get { return GetValue<string>(DisplayNameProperty); }
            set { SetValue(DisplayNameProperty, value); }
        }

        #endregion

        #region Property: UserName
        /// <summary>
        /// Name of a User with administrative rights.
        /// </summary>
        public String UserName
        {
            get { return GetValue<String>(UserNameProperty); }
            set { SetValue(UserNameProperty, value); }
        }

        public static readonly PropertyData UserNameProperty =
            RegisterProperty("UserName", typeof(String), null);
        #endregion


        #endregion

        #region Methods

        #endregion
    }
}