using System;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Runtime.InteropServices;

using UUM.Api;
using UUM.Api.Interfaces;
using UUM.Plugin.Subversion.Models;

namespace UUM.Plugin.Subversion
{
    [Export(typeof (IPlugin))]
    [Guid("5D4E8772-0C14-4B2B-8BD5-347DAE494C4E")]
    public class SubversionPlugin : PluginBase<Parameters, UserInSource>
    {
		#region Constructors
		public SubversionPlugin()
		{
			Name = "Subversion";
			Description = "Plugin for the Subversion file based rights system";
		}
		#endregion
    	
		protected override IRepository GetRepositoryInternal(Parameters parameters)
		{
			Subversion.Models.Parameters = paramaeters;
		}
		
		public  ObservableCollection<UserInSource> GetUserInSourceType()
		{
			//get the whole line that seperated the group name and divide it to many different users and add to list
			var users = new List<String>();

			if (File.Exists(ConfigurationFile))
            {
                // Read the file and display it line by line.
                foreach (String line in File.ReadAllLines(ConfigurationFile))
                {
                    Regex groupDefinition = new Regex(@"^(.*?)=(.*)$");
                    if (groupDefinition.IsMatch(line))
                    {
                        String userNames = groupDefinition.Match(line).Groups[2].Value;
						users.AddRange(userNames.Split(',').Select( x => x.Trim()));
                    }

                }
            }

			//LINQ
			var distinctUsers = users.Distinct().OrderBy(x => x);
			// another syntax is possible... var distinctUsers = from users select x orderby x;
			//users.Count;
			return distinctUsers.Select(x =>  new TUserInSource(x,null, null, true, Name));
		}
    }
}