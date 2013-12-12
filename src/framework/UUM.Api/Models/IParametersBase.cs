using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

using Catel.Data;
using Catel.IoC;

using UUM.Api.Interfaces;

namespace UUM.Api.Models
{
	public interface IParametersBase
	{
		string Name { get; set; }
		Guid Id { get; }
		IPlugin Plugin { get; }
	}
}
