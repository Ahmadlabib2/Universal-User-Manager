// See LICENCE.txt in the root for conditions of use

using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Catel.Data;
using UUM.Api.Models;

namespace UUM.Engine.Models
{
    /// <summary>
    ///     UserPool: contains the users.
    /// </summary>
    [Serializable]
    public class UserPoolModel : SavableModelBase<UserPoolModel>
    {
        public UserPoolModel()
        {
        }

        protected UserPoolModel(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        #region Property: Users

        public static readonly PropertyData UserProperty =
            RegisterProperty("Users", typeof (ObservableCollection<UserModel>));

        public ObservableCollection<UserModel> Users
        {
            get { return GetValue<ObservableCollection<UserModel>>(UserProperty); }
            set { SetValue(UserProperty, value); }
        }

        #endregion

        #region Methods

        public void Add(UserModel user)
        {
            Users.Add(user);
        }

        public void Remove(UserModel user)
        {
            Users.Remove(user);
        }

        #endregion
    }
}