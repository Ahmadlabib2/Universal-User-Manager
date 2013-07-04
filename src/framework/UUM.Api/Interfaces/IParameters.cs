using System;
using System.Xml.Serialization;
using Catel.Data;
using UUM.Api.Models;

namespace UUM.Api.Interfaces
{
    /// <summary>
    ///     Parameters for a plugin instance, this is a tagging interface
    ///     without any properties or methods. The plugins may implement it
    ///     with the properties they need.
    /// </summary>
    [XmlInclude(typeof (ParametersBase))]
    public interface IParameters : IModel
    {
        /// <summary>
        ///     Plugin where these parameters come from
        /// </summary>
        Guid PluginId { get; }
    }
}