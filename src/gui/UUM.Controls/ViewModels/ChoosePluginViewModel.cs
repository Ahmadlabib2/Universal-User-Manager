﻿using System.Collections.ObjectModel;
using Catel.Data;
using Catel.MVVM;
using UUM.Api.Interfaces;
using UUM.Engine.Interfaces;
using UUM.Engine.Models;

namespace UUM.Controls.ViewModels
{
	/// <summary>
	/// Description of ChoosePluginViewModel.
	/// </summary>
	public class ChoosePluginViewModel : ViewModelBase
	{
		public ChoosePluginViewModel()
		{
			var pluginRepository = GetService<IPluginRepository>();
			Plugins = pluginRepository.Plugins;
		}
		#region Model
		/// <summary>
		/// Loads the Plugins
		/// </summary>
		/// 
		public static readonly PropertyData PluginsProperty =
			RegisterProperty("Plugins", typeof (ObservableCollection<IPlugin>), null);

		public ObservableCollection<IPlugin> Plugins
		{
			get { return GetValue<ObservableCollection<IPlugin>>(PluginsProperty); }
			set { SetValue(PluginsProperty, value); }
		}

		#endregion
		
	}
}