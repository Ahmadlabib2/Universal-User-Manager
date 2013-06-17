﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Catel.Data;
using Catel.MVVM;
using UUM.Api.Interfaces;

namespace UUM.Controls.ViewModels
{
    /// <summary>
    ///     RepositorySettingsViewModel view model.
    /// </summary>
    public class RepositorySettingsViewModel : ViewModelBase
    {
        public RepositorySettingsViewModel(IParameters parameters)
        {
            Parameters = parameters;
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

        public static readonly PropertyData ParametersProperty =
            RegisterProperty("Parameters", typeof (IParameters));

        [Model]
        public IParameters Parameters
        {
            get { return GetValue<IParameters>(ParametersProperty); }
            private set { SetValue(ParametersProperty, value); }
        }

        #endregion

        #region Property: Properties

        public IEnumerable<PluginParameter> Properties
        {
            get
            {
                PropertyInfo[] properties = Parameters.GetType().GetProperties();
                IEnumerable<PropertyInfo> readWriteProperties = properties.Where(x => x.CanRead && x.CanWrite);
                return readWriteProperties.Where(x => x.Module.Name != "Catel.Core.dll").Select(x => new PluginParameter(Parameters, x));
            }
        }

        #endregion

        #endregion

        #region Commands

        #endregion

        protected override void OnPropertyChanged(AdvancedPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (e.PropertyName == "Parameters")
                RaisePropertyChanged("Properties");
        }

        public class PluginParameter
        {
            private readonly PropertyInfo _pi;
            private readonly IParameters _parameters;

            public PluginParameter(IParameters parameters, PropertyInfo pi)
            {
                _pi = pi;
                _parameters = parameters;
            }

            public string Name { get { return _pi.Name;  } }

            /// <summary>
            /// Use refection to set/get the value
            /// </summary>
            public string Value
            {
                get { return Convert.ToString(_pi.GetValue(_parameters, null)); }
                set { _pi.SetValue(_parameters, value, null); }
            }
        }
    }
}