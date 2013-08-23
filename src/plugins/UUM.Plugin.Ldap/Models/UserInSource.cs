using System;
using System.Runtime.Serialization;
using Catel.Data;
using UUM.Api.Interfaces;

namespace UUM.Plugin.Ldap.Models
{
    /// <summary>
    ///     User in source class.
    /// </summary>
    [Serializable]
    public class UserInSource : SavableModelBase<UserInSource>, IUserInSource
    {
        #region Discriminator

        // discriminator field for serialization
        public Guid PluginId
        {
            get { return LdapPlugin.PluginId; }
        }

        #endregion

        #region Fields

        #endregion

        #region Constructors

        public UserInSource()
        {
            Id = Guid.NewGuid();
        }

        protected UserInSource(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        #endregion

        #region Properties

        #region Property: Id

        public static readonly PropertyData IdProperty =
            RegisterProperty("Id", typeof (Guid));

        public Guid Id
        {
            get { return GetValue<Guid>(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        #endregion

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