using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Catel.Data;

namespace UUM.Engine.Models
{
    /// <summary>
    ///     User abstraction of his Firstname, Lastname, Emailaddress, Phonenumber, IsEnabled property and LinkedUsers property. 
    /// </summary>
    [Serializable]
    public class UserModel : SavableModelBase<UserModel>
    {
        public UserModel()
        {
        }

        protected UserModel(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        #region Property: FirstName

        public static readonly PropertyData FirstNameProperty =
            RegisterProperty("FirstName", typeof (string));

        public string FirstName
        {
            get { return GetValue<string>(FirstNameProperty); }
            set { SetValue(FirstNameProperty, value); }
        }

        #endregion

        #region Property: LastName

        public static readonly PropertyData LastNameProperty =
            RegisterProperty("LastName", typeof (string));

        public string LastName
        {
            get { return GetValue<string>(LastNameProperty); }
            set { SetValue(LastNameProperty, value); }
        }

        #endregion

        #region Property: EmailAddress

        public static readonly PropertyData EmailAddressProperty =
            RegisterProperty("EmailAddress", typeof (string));

        public string EmailAddress
        {
            get { return GetValue<string>(EmailAddressProperty); }
            set { SetValue(EmailAddressProperty, value); }
        }

        #endregion

        #region Property: PhoneNumber

        public static readonly PropertyData PhoneNumberProperty =
            RegisterProperty("PhoneNumber", typeof (string));

        public string PhoneNumber
        {
            get { return GetValue<string>(PhoneNumberProperty); }
            set { SetValue(PhoneNumberProperty, value); }
        }

        #endregion

        #region Property: IsEnabled

        public static readonly PropertyData IsEnabledProperty =
            RegisterProperty("IsEnabled", typeof (bool), true);

        public bool IsEnabled
        {
            get { return GetValue<bool>(IsEnabledProperty); }
            set { SetValue(IsEnabledProperty, value); }
        }

        #endregion

        #region Property: LinkedUsers

        public static readonly PropertyData LinkedUsersProperty =
            RegisterProperty("LinkedUsers", typeof(ObservableCollection<Guid>), new ObservableCollection<Guid>());

        public ObservableCollection<Guid> LinkedUsers
        {
            get { return GetValue<ObservableCollection<Guid>>(LinkedUsersProperty); }
            private set { SetValue(LinkedUsersProperty, value); }
        }

        #endregion
    }
}