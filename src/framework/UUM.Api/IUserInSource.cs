using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UUM.Api.Models;

namespace UUM.Api
{
    public interface IUserInSource
    {
        /// <summary>
        /// Return a user model representation of this user in a source
        /// </summary>
        UserModel UserModel { get; }
    }
}
