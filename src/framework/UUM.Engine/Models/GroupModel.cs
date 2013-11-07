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
		

	public static readonly PropertyData SourceProperty =
            RegisterProperty("Source", typeof (string));

        public string Source
        {
            get { return GetValue<string>(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }
        
   public static readonly PropertyData GroupNameProperty =
            RegisterProperty("GroupName", typeof (string));

        public string GroupName
        {
            get { return GetValue<string>(GroupNameProperty); }
            set { SetValue(GroupNameProperty, value); }
        }

		
	}
}


