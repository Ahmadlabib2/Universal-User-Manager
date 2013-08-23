using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices;
using System.Xml;

using UUM.Api;
using UUM.Plugin.Ldap.Models;

namespace UUM.Plugin.Ldap
{
    /// <summary>
	/// Description of LdapUserSource.
	/// </summary>
	public class LdapUserSource
	{
		public LdapUserSource(String server, String username, String password, String filter, String nameProperty)
		{
			_ldapServer = server;
			_username = username;
			_password = password;
			_ldapSearchFilter = filter;
			_nameProperty = nameProperty;
		}
		
		private string _ldapServer;
		private string _username;
		private string _password;
		private string _ldapSearchFilter;
		private string _nameProperty;
		
		public IEnumerable<UserInSource> GetUsers()
		{
			DirectoryEntry entry = new DirectoryEntry(_ldapServer, _username, _password);
			
			entry.AuthenticationType = AuthenticationTypes.None;
			DirectorySearcher searcher = new DirectorySearcher(entry);
			
			searcher.Filter = _ldapSearchFilter;
			searcher.SearchScope = SearchScope.Subtree;

			SortOption option = new SortOption(_nameProperty, SortDirection.Ascending);
			searcher.Sort = option;
			searcher.PageSize = 500;
			int count = 0;

			IList<UserInSource> users = new List<UserInSource>();
			foreach (SearchResult resEnt in searcher.FindAll())
			{
				
				//Trace.TraceInformation("Loading User #"+count);
				count++;
				DirectoryEntry de = resEnt.GetDirectoryEntry();
				if (de.SchemaClassName == "group")
				{
					// ignore
				}
				else if (de.SchemaClassName == "user")
				{
					String account = Convert.ToString(de.Properties[_nameProperty].Value);
					String displayName = Convert.ToString(de.Properties["displayName"].Value);
					String sn = Convert.ToString(de.Properties["sn"].Value);
					String fn = Convert.ToString(de.Properties["givenName"].Value);
					Int32 userAccountControl = Convert.ToInt32(de.Properties["userAccountControl"].Value);
					LdapFlags flags = (LdapFlags)userAccountControl;
					bool isEnabled = (flags & LdapFlags.AccountDisabled) == 0;
					
					// get the group from Ldap and assign it to the user
					var newUser = new UserInSource();
					//newUser.LoginName = account;
					// fn, sn, isEnabled;
					users.Add(newUser);
				}
				else if (de.SchemaClassName == "computer")
				{
					// ignore
				}
				else
				{
					//ignore
				}
			}
			
			return users;
		}
		
	}
}
