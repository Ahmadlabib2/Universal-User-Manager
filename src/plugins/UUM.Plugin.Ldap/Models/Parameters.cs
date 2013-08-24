using System;
using Catel.Data;
using UUM.Api.Models;

namespace UUM.Plugin.Ldap.Models
{
    [Serializable]
    public class Parameters : ParametersBase
    {
        #region Fields
        #endregion

        #region Properties

        #region Property: Server
        /// <summary>
        /// Server address.
        /// </summary>
        public String Server
        {
            get { return GetValue<String>(ServerProperty); }
            set { SetValue(ServerProperty, value); }
        }

        public static readonly PropertyData ServerProperty =
            RegisterProperty("Server", typeof(String));
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
            RegisterProperty("UserName", typeof(String));
        #endregion

        #region Property: Password
        /// <summary>
        /// Password.
        /// </summary>
        public String Password
        {
            get { return GetValue<String>(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        public static readonly PropertyData PasswordProperty =
            RegisterProperty("Password", typeof(String));
        #endregion

        #region Property: Filter
        /// <summary>
        /// Filter to apply on the data to be retrieven.
        /// </summary>
        public String Filter
        {
            get { return GetValue<String>(FilterProperty); }
            set { SetValue(FilterProperty, value); }
        }

        public static readonly PropertyData FilterProperty =
            RegisterProperty("Filter", typeof(String));
        #endregion

        #endregion

        #region Methods
        #endregion
    }
}
