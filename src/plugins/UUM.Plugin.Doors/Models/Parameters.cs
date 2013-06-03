using System;
using System.Runtime.Serialization;
using Catel.Data;
using UUM.Api.Interfaces;

namespace UUM.Plugin.Doors.Models
{
    /// <summary>
    /// Parameters model which fully supports serialization, property changed notifications,
    /// backwards compatibility and error checking.
    /// </summary>
    [Serializable]
    public class Parameters : SavableModelBase<Parameters>, IParameters
    {
        #region Fields
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new object from scratch.
        /// </summary>
        public Parameters() { }

        /// <summary>
        /// Initializes a new object based on <see cref="SerializationInfo"/>.
        /// </summary>
        /// <param name="info"><see cref="SerializationInfo"/> that contains the information.</param>
        /// <param name="context"><see cref="StreamingContext"/>.</param>
        protected Parameters(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
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
            RegisterProperty("Server", typeof(String), null);
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

        #region Property: UserName
        /// <summary>
        /// Password.
        /// </summary>
        public String Password
        {
            get { return GetValue<String>(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        public static readonly PropertyData PasswordProperty = 
            RegisterProperty("Password", typeof(String), null);
        #endregion

        #endregion

        #region Methods
        #endregion
    }
}
