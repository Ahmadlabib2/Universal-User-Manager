/*
 * Created by SharpDevelop.
 * User: Ahmed-Labib.Wadi
 * Date: 25.12.2013
 * Time: 19:09
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.ObjectModel;
using System.Xml;

using Catel.Data;
using UUM.Api.Models;

namespace UUM.Engine.Models
{
	/// <summary>
	/// Synchronizes Users from userpool and user in source
	/// </summary>
	public class UserSynchronizer
	{
		public UserSynchronizer()
		{
			UserModel Users = new UserModel();
			UsersInPool = new ObservableCollection<UserModel>();
			UserinSource = new ObservableCollection<UserInSourceBase>();
		}
		
		public int Counter {get;set;}
		
		public ObservableCollection<UserModel> UsersInPool
		{ get; set; }
		
		public ObservableCollection<UserInSourceBase> UserinSource;
		
		public void Synchronize(UserPoolModel userpool, String repository)
		{
			
			userpool = UserPoolModel.Load(repository);
		}
		
		public void ReadXml(XmlReader reader)
		{
			UserModel usermodel = new UserModel();
			reader.ReadStartElement();
			usermodel.FirstName = reader.ReadElementString("FirstName");
			usermodel.LastName = reader.ReadElementString("LastName");
			usermodel.IsEnabled = Convert.ToBoolean(reader.ReadElementString("Active"));
			reader.MoveToContent();
			bool empty = reader.IsEmptyElement;
			reader.ReadStartElement("Plugin");
				while(reader.IsStartElement("User"))
				{
					
					
					
					UsersInPool.Add(usermodel);
					
				//	UserSynchronizer synchronize();
					ReadXml(reader);
					Counter++;
				}
				reader.ReadEndElement();
			}
	}
}
