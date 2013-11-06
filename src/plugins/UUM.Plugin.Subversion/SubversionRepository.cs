using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

using UUM.Api.Interfaces;
using UUM.Api.Models;
using UUM.Plugin.Subversion.Models;

namespace UUM.Plugin.Subversion
{
    public class SubversionRepository : IRepository
    {
        private readonly Parameters _parameters;
        private IEnumerable<UserInSource> _users;

        public SubversionRepository(Parameters parameters)
        {
            _parameters = parameters;
        }

        public IEnumerable<UserInSourceBase> Users
        {
            get { return _users ?? (_users = ReadUsers()); }
        }

        public IEnumerable<UserInSource> ReadUsers()
        {
            //get the whole line that seperated the group name and divide it to many different users and add to list
            var users = new List<String>();

            if (File.Exists(_parameters.ConfigurationFile))
            {
                // Read the file and display it line by line.
                foreach (String line in File.ReadAllLines(_parameters.ConfigurationFile))
                {
                    Regex groupDefinition = new Regex(@"^(.*?)=(.*)$");
                    if (groupDefinition.IsMatch(line))
                    {
                        String userNames = groupDefinition.Match(line).Groups[2].Value;
                        users.AddRange(userNames.Split(',').Select(x => x.Trim()));
                    }

                }
            }

            //LINQ
            var distinctUsers = users.Distinct().OrderBy(x => x);
            // another syntax is possible... var distinctUsers = from users select x orderby x;
            //users.Count;
            return distinctUsers.Select(x => new UserInSource(x, null, null, "Subversion"));
        }
    }
}