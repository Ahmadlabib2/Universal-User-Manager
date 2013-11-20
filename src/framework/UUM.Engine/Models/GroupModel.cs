// See LICENCE.txt in the root for conditions of use
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;

using Catel.Data;

namespace UUM.Engine.Models
{
    /// <summary>
    /// Description of GroupModel.
    /// </summary>
    /// 
    [Serializable]
    public class GroupModel : SavableModelBase<GroupModel>
    {
        public GroupModel()
        {
        }

        protected GroupModel(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }


        public string Source
        { get; set; }

        /// <summary>
        ///     Name of this group
        /// </summary>
        public string Name
        { get; set; }
    }
}


