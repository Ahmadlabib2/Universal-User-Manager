using System;
using Catel.Data;

namespace UUM.Api.Interfaces
{
    /// <summary>
    ///     Parameters for a plugin instance, this is a tagging interface
    ///     without any properties or methods. The plugins may implement it
    ///     with the properties they need.
    /// </summary>
    public interface IParameters : IModel
    {
        /// <summary>
        ///     Plugin where these parameters come from
        /// </summary>
        Guid PluginId { get; }
    }
}