// See LICENCE.txt in the root for conditions of use
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

using Catel.Data;
using Catel.MVVM;
using UUM.Engine.Models;

namespace UUM.Controls.ViewModels
{
	#region Constructor
	/// <summary>
	/// Description of UserpoolViewModel.
	/// </summary>
	public class UserpoolViewModel : ViewModelBase, IXmlSerializable
	{
		public UserpoolViewModel(UserpoolModel pool)
		{
			Userpool = pool;
		}
		#endregion
	
		#region Properties
		public  IList<UserModel> users;
		
		public void AddUser(UserModel user)
			{
			users.Add(user);
			}
			
		public void RemoveUser(UserModel user)
			{
			users.Remove(user);
			}
		public void EditUser(UserModel user)
			{
			
			}
		#endregion
		
		[Model]
        public UserpoolModel Userpool
        {
            get { return GetValue<UserpoolModel>(ModelProperty); }
            private set { SetValue(ModelProperty, value); }
        }

       
        public static readonly PropertyData ModelProperty =
            RegisterProperty("Userpool", typeof(UserpoolModel));
        
        
		public System.Xml.Schema.XmlSchema GetSchema()
		{
			throw new NotImplementedException();
		}
		
		public void ReadXml(System.Xml.XmlReader reader)
		{
			throw new NotImplementedException();
		}
		
		public void WriteXml(System.Xml.XmlWriter writer)
		{
			throw new NotImplementedException();
		}
	}
}
