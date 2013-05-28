using System;
using System.Runtime.Serialization;
using Catel.Data;
using UUM.Api;
using UUM.Api.Interfaces;
using UUM.Api.Models;

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

        public Guid Id
        {
            get { return GetValue<Guid>(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        public static readonly PropertyData IdProperty =
            RegisterProperty("Id", typeof(Guid));

        #endregion

        #region Property: LoginName

        public string LoginName
        {
            get { return GetValue<string>(LoginNameProperty); }
            set { SetValue(LoginNameProperty, value); }
        }

        public static readonly PropertyData LoginNameProperty =
            RegisterProperty("LoginName", typeof(string));

        #endregion

        #endregion

        #region Methods

        #endregion
    }
}