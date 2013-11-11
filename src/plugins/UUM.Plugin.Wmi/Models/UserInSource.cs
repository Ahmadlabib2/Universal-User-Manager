using System;

using UUM.Api.Models;

namespace UUM.Plugin.Wmi.Models
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
            : base(typeof(WmiPlugin).GUID)
        {
        }
        #endregion

        #region Properties
        
        #endregion

        #region Methods

        #endregion
    }
}