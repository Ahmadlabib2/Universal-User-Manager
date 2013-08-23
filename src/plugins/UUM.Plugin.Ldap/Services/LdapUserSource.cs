using System;
using System.Collections.Generic;
using System.DirectoryServices;

using UUM.Plugin.Ldap.Models;

namespace UUM.Plugin.Ldap.Services
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
		
		private readonly string _ldapServer;
		private readonly string _username;
		private readonly string _password;
		private readonly string _ldapSearchFilter;
		private readonly string _nameProperty;
		
		public IEnumerable<UserInSource> GetUsers()
		{
			var entry = new DirectoryEntry(_ldapServer, _username, _password);
			
			entry.AuthenticationType = AuthenticationTypes.None;
			var searcher = new DirectorySearcher(entry);
			
			searcher.Filter = _ldapSearchFilter;
			searcher.SearchScope = SearchScope.Subtree;

			var option = new SortOption(_nameProperty, SortDirection.Ascending);
			searcher.Sort = option;
			searcher.PageSize = 500;
			int count = 0;

			IList<UserInSource> users = new List<UserInSource>();
			foreach (SearchResult resEnt in searcher.FindAll())
			{
				
				//Trace.TraceInformation("Loading User #"+count);
				count++;
				DirectoryEntry de = resEnt.GetDirectoryEntry();
				switch (de.SchemaClassName)
				{
				    case "group":
				        break;
				    case "user":
				        {
				            String account = Convert.ToString(de.Properties[_nameProperty].Value);
				            String displayName = Convert.ToString(de.Properties["displayName"].Value);
				            String sn = Convert.ToString(de.Properties["sn"].Value);
				            String fn = Convert.ToString(de.Properties["givenName"].Value);
				            Int32 userAccountControl = Convert.ToInt32(de.Properties["userAccountControl"].Value);
				            var flags = (LdapFlags)userAccountControl;
				            bool isEnabled = (flags & LdapFlags.AccountDisabled) == 0;
					
				            // get the group from Ldap and assign it to the user
				            var newUser = new UserInSource();
				            //newUser.LoginName = account;
				            // fn, sn, isEnabled;
				            users.Add(newUser);
				        }
				        break;
				    case "computer":
				        break;
				    default:
				        break;
				}
			}
			
			return users;
		}
		
	}
}
