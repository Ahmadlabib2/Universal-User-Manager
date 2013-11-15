using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Catel.Data;
using Catel.MVVM;

using UUM.Api.Models;

namespace UUM.Controls.ViewModels
{
    /// <summary>
    ///     RepositorySettingsViewModel view model.
    /// </summary>
    public class RepositorySettingsViewModel : ViewModelBase
    {
        public RepositorySettingsViewModel(ParametersBase parameters)
        	: base(false)
        {
            Parameters = parameters;
            GetUsers = new Command(GetUsersExecute);
            GetGroups = new Command(GetGroupsExecute);
        }

        /// <summary>
        ///     Gets the title of the view model.
        /// </summary>
        /// <value>The title.</value>
        public override string Title
        {
            get { return "RepositorySettings"; }
        }

        #region Properties

        #region Property: Parameters

        [Model]
        [Expose("Name")]
        public ParametersBase Parameters
        { get; private set; }

        #endregion

        #region Property: Properties

        public IEnumerable<PluginParameter> Properties
        {
            get
            {
                PropertyInfo[] properties = Parameters.GetType().GetProperties();
                IEnumerable<PropertyInfo> readWriteProperties = properties.Where(x => x.CanRead && x.CanWrite);
                return readWriteProperties
                	.Where(x => x.Module.Name != "Catel.Core.dll" && x.Name != "Name")
                    .Select(x => new PluginParameter(Parameters, x));
            }
        }

        #endregion

        #endregion
        
        #region Commands

        #region Command: GetUsers

        public Command GetUsers { get; private set; }

        private void GetUsersExecute()
        {
        
        	
        	
        }

        #endregion

        #region Command: GetGroups

        public Command GetGroups { get; private set; }

        private void GetGroupsExecute()
        {
        	throw new NotImplementedException();
        }

        #endregion

        #endregion

        public class PluginParameter
        {
            private readonly ParametersBase _parameters;
            private readonly PropertyInfo _pi;

            public PluginParameter(ParametersBase parameters, PropertyInfo pi)
            {
                _pi = pi;
                _parameters = parameters;
            }

            public string Name
            {
                get { return _pi.Name; }
            }

            /// <summary>
            ///     Use refection to set/get the value
            /// </summary>
            public string Value
            {
                get { return Convert.ToString(_pi.GetValue(_parameters, null)); }
                set { _pi.SetValue(_parameters, value, null); }
            }
        }
    }
}