using System;
using System.Collections.ObjectModel;

namespace UUM.Api.Interfaces
{
	/// <summary>
	///     The IPluginRepository is a service used to have a central point
    ///     enumerating all currently loaded plugins and how to resolve the
    ///     plugin implementing a given type.
	/// </summary>
    public interface IPluginRepository
    {
        /// <summary>
        /// Load the plugins
        /// </summary>
        void Initialize();

        /// <summary>
        /// All currently loaded plugins
        /// </summary>
        ObservableCollection<IPlugin> Plugins { get; }

        /// <summary>
        /// Retrieve the plugin implementing a given Parameters type
        /// </summary>
        /// <param name="type">Type to look for</param>
        /// <returns>A plugin or throws an exception if the type cannot be resolved</returns>
        IPlugin ResolvePluginFromType(Type type);
    }
}