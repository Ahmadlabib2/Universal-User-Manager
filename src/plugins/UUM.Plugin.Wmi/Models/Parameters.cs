using System;
using Catel.Data;
using UUM.Api.Models;

namespace UUM.Plugin.Wmi.Models
{
    [Serializable]
    public class Parameters : ParametersBase
    {
        #region Fields

        #endregion

        #region Properties

        #region Property: ComputerName

        /// <summary>
        ///     Register the name property so it is known in the class.
        /// </summary>
        public static readonly PropertyData ComputerNameProperty =
            RegisterProperty("ComputerName", typeof (String));

        /// <summary>
        ///     Path to Subversion Configuration File.
        /// </summary>
        public String ComputerName
        {
            get { return GetValue<String>(ComputerNameProperty); }
            set { SetValue(ComputerNameProperty, value); }
        }

        #endregion

        #endregion

        #region Methods

        #endregion
    }
}