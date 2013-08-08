using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Catel.Data;
using UUM.Api.Interfaces;

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
            RegisterProperty("Users", typeof(ObservableCollection<UserModel>), new ObservableCollection<UserModel>());

        public ObservableCollection<UserModel> Users
        {
            get { return GetValue<ObservableCollection<UserModel>>(UserProperty); }
            set { SetValue(UserProperty, value); }
        }

        #endregion

        #region Property: UsersInSources

        public static readonly PropertyData UsersInSourcesProperty =
            RegisterProperty("UsersInSources", typeof(ObservableCollection<UserModel>));

        public ObservableCollection<IUserInSource> UsersInSources
        {
            get { return GetValue<ObservableCollection<IUserInSource>>(UsersInSourcesProperty); }
            set { SetValue(UsersInSourcesProperty, value); }
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

        public IUserInSource FindUserInSourceById(Guid id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}