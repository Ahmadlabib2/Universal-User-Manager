using System.Collections.Generic;
using UUM.Api.Models;

namespace UUM.Api.Interfaces
{
    /// <summary>
    ///     Abstraction of the remote data access to the target system
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        ///     Retrieve the users from the repository
        /// </summary>
        IEnumerable<UserInSourceBase> Users { get; }
    }
}
