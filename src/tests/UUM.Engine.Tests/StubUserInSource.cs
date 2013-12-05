using System;
using System.Runtime.Serialization;
using UUM.Api.Models;

namespace UUM.Engine.Tests
{
    public class StubUserInSource : UserInSourceBase
    {
        private static readonly Guid _pluginId = Guid.NewGuid();

        public StubUserInSource()
            : base(_pluginId)
        {
        //UserInSourceBase userinsource = new Api.Models.UserInSourceBase();
        //	UserInSourceBase.Load
        }

        public StubUserInSource(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        	
        }
    }
}
