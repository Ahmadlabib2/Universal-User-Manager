using System;
using Catel.Data;
using UUM.Api.Models;

namespace UUM.Plugin.Subversion.Models
{
    [Serializable]
    public class Parameters : ParametersBase
    {
        #region Fields

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new object from scratch.
        /// </summary>
        public Parameters()
            : base(SubversionPlugin.PluginId)
        {
        }

        #endregion

        #region Properties

        #region Property: ConfigurationFile

        /// <summary>
        ///     Register the name property so it is known in the class.
        /// </summary>
        public static readonly PropertyData ConfigurationFileProperty =
            RegisterProperty("ConfigurationFile", typeof (String), null);

        /// <summary>
        ///     Path to Subversion Configuration File.
        /// </summary>
        public String ConfigurationFile
        {
            get { return GetValue<String>(ConfigurationFileProperty); }
            set { SetValue(ConfigurationFileProperty, value); }
        }

        #endregion

        #endregion

        #region Methods

        #endregion
    }
}