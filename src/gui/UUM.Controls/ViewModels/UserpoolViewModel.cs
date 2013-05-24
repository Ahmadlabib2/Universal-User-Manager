using System.Collections.Generic;
using Catel.Data;
using Catel.MVVM;
using UUM.Engine.Models;

namespace UUM.Controls.ViewModels
{
    /// <summary>
    ///     Description of UserpoolViewModel.
    /// </summary>
    public class UserPoolViewModel : ViewModelBase
    {
        #region Constructor

        public UserPoolViewModel(UserPoolModel pool)
        {
            UserPool = pool;
            AddUser = new Command(OnAddUserExecute);
            RemoveUser = new Command(OnRemoveUserExecute);
        }

        #endregion

        #region Model: UserPool

        public static readonly PropertyData ModelProperty =
            RegisterProperty("UserPool", typeof(UserPoolModel));

        [Model]
        public UserPoolModel UserPool
        {
            get { return GetValue<UserPoolModel>(ModelProperty); }
            private set { SetValue(ModelProperty, value); }
        }

        #endregion

        #region Property: SelectedUser
        public UserModel SelectedUser
        {
            get { return GetValue<UserModel>(SelectedUserProperty); }
            set { SetValue(SelectedUserProperty, value); }
        }

        public static readonly PropertyData SelectedUserProperty =
            RegisterProperty("SelectedUser", typeof(UserModel), null);
        #endregion

        #region Commands

        #region Command: AddUser
        public Command AddUser { get; private set; }

        private void OnAddUserExecute()
        {
            UserPool.Add(new UserModel());
        }
        #endregion

        #region Command: RemoveUser
        public Command RemoveUser { get; private set; }

        private void OnRemoveUserExecute()
        {
            UserPool.Remove(SelectedUser);
        }
        #endregion

        #endregion
    }
}