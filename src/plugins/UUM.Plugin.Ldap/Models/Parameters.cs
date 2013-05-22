using System;
using System.Runtime.Serialization;
using Catel.Data;

namespace UUM.Plugin.Ldap.Models
{
    /// <summary>
    /// Parameters model which fully supports serialization, property changed notifications,
    /// backwards compatibility and error checking.
    /// </summary>
    [Serializable]
    public class Parameters : SavableModelBase<Parameters>
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
        #endregion

        #region Methods
        #endregion
    }
}
