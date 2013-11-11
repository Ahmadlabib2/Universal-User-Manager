using System;

using UUM.Api.Models;

namespace UUM.Plugin.Sbm.Models
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
            : base(typeof(SbmPlugin).GUID)
        {
        }
        #endregion

        #region Properties
        
        #endregion

        #region Methods

        #endregion
    }
}