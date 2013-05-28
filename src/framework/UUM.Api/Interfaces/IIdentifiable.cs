using System;

namespace UUM.Api.Interfaces
{
    /// <summary>
    ///     Interface used for identifying or referring to objects independently
    ///     of the context. A user or group might get renamed and we still can try
    ///     to match the right user depending on other criteria known to the plugin
    ///     providing the users.
    /// </summary>
    public interface IIdentifiable
    {
        /// <summary>
        ///     The GUID of this object
        /// </summary>
        Guid Id { get; }
    }
}