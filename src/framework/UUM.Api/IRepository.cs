using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UUM.Api
{
    /// <summary>
    /// Abstraction of the remote data access to the target system
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Retrieve the users from the repository
        /// </summary>
        IEnumerable<IUserInSource> Users { get; }
    }
}
