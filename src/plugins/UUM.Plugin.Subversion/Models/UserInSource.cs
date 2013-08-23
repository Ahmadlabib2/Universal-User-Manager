using System;
using System.Runtime.Serialization;
using Catel.Data;
using UUM.Api.Interfaces;
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
            Id = Guid.NewGuid();
        }

        protected UserInSource(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
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

        #endregion

        #endregion

        #region Methods

        #endregion
    }
}