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

        #region Property: LoginName

        public static readonly PropertyData LoginNameProperty =
            RegisterProperty("LoginName", typeof (string));

        public string LoginName
        {
            get { return GetValue<string>(LoginNameProperty); }
            set { SetValue(LoginNameProperty, value); }
        }

        #endregion

        #endregion

        #region Methods

        #endregion
    }
}