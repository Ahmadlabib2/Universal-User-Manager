using System;

using Catel.Data;

using UUM.Api.Models;

namespace UUM.Plugin.Doors.Models
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
            : base(typeof(DoorsPlugin).GUID)
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