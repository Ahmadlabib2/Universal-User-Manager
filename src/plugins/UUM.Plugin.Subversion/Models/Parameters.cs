using System;
using System.Runtime.Serialization;
using Catel.Data;
using UUM.Api;

namespace UUM.Plugin.Subversion.Models
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

        #region Property: ConfigurationFile
        /// <summary>
        /// Path to Subversion Configuration File.
        /// </summary>
        public String ConfigurationFile
        {
            get { return GetValue<String>(ConfigurationFileProperty); }
            set { SetValue(ConfigurationFileProperty, value); }
        }

        /// <summary>
        /// Register the name property so it is known in the class.
        /// </summary>
        public static readonly PropertyData ConfigurationFileProperty =
            RegisterProperty("ConfigurationFile", typeof(String), null);
        #endregion
        
        #endregion

        #region Methods
        #endregion
    }
}
