using System.Collections.Generic;
using Catel.Data;

namespace UUM.Api.Interfaces
{
    /// <summary>
    /// Parameters for a plugin instance
    /// </summary>
    public interface IParameters: IModel
    {
    	IEnumerable<IParameters> GetParameters(IPlugin plugin);
    }
}