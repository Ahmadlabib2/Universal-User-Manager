namespace UUM.Plugin.Ldap
{
    using System;

    [Flags]
	public enum LdapFlags {
		None                                            = 0,
		// The logon script is executed. This flag does not work for the ADSI LDAP
		// provider on either read or write operations. For the ADSI WinNT provider,
		// this flag is read-only data, and it cannot be set for user objects.
		LogonScriptExecuted                             = 1,         // 0x1
		// The user account is disabled.
		AccountDisabled                                 = 2,         // 0x2
		// The home directory is required.
		HomeDirectoryRequired                           = 8,         // 0x8
		// The account is currently locked out.
		LockedOut                                       = 16,        // 0x10
		// No password is required.
		NoPasswordRequired                              = 32,        // 0x20
		// The user cannot change the password. This flag can be read, but not set
		// directly. For more information and a code example that shows how to prevent
		// a user from changing the password, see User Cannot Change Password.
		CannotChangePassword                            = 64,        // 0x40
		// The user can send an encrypted password.
		EncryptedPasswordAllowed                        = 128,       // 0x80
		// This is an account for users whose primary account is in another domain. This
		// account provides user access to this domain, but not to any domain that trusts
		// this domain. Also known as a local user account.
		LocalUserAccount                                = 256,       // 0x100
		// This is a default account type that represents a typical user.
		NormalAccount                                   = 512,       // 0x200
		// This is a permit to trust account for a system domain that trusts other domains.
		InterdomainTrustAccount                         = 2048,      // 0x800
		// This is a computer account for a Windows 2000 Professional or Windows 2000
		// Server that is a member of this domain.
		WorkstationTrustAccount                         = 4096,      // 0x1000
		// This is a computer account for a system backup domain controller that is a member
		// of this domain.
		ServerTrustAccount                              = 8192,      // 0x2000
		// When set, the password will not expire on this account.
		PasswordDoesNotExpire                           = 65536,     // 0x10000
		// This is an Majority Node Set (MNS) logon account. With MNS, you can configure a
		// multi-node Windows cluster without using a common shared disk.
		MnsLogonAccount                                 = 131072,    // 0x20000
		// When set, this flag will force the user to log on using a smart card.
		SmartcardRequired                               = 262144,    // 0x40000
		// When set, the service account (user or computer account), under which a service
		// runs, is trusted for Kerberos delegation. Any such service can impersonate a
		// client requesting the service. To enable a service for Kerberos delegation,
		// set this flag on the userAccountControl property of the service account.
		TrustedForDelegation                            = 524288,    // 0x80000
		// When set, the security context of the user will not be delegated to a service
		// even if the service account is set as trusted for Kerberos delegation.
		CannotBeDelegated                               = 1048576,   // 0x100000
		// Restrict this principal to use only Data Encryption Standard (DES) encryption
		// types for keys.
		// Active Directory Client Extension:  Not supported.
		RestrictToDesKey                                = 2097152,   // 0x200000
		// This account does not require Kerberos preauthentication for logon.
		// Active Directory Client Extension:  Not supported.
		DontRequirePreauthentication                    = 4194304,   // 0x400000
		// The user password has expired. This flag is created by the system using data
		// from the password last set attribute and the domain policy. It is read-only
		// and cannot be set. To manually set a user password as expired, use the
		// NetUserSetInfo function with the USER_INFO_3 (usri3_password_expired member)
		// or USER_INFO_4 (usri4_password_expired member) structure.
		// Active Directory Client Extension:  Not supported.
		PasswordExpired                                 = 8388608,   // 0x800000
		// The account is enabled for delegation. This is a security-sensitive setting;
		// accounts with this option enabled should be strictly controlled. This setting
		// enables a service running under the account to assume a client identity and
		// authenticate as that user to other remote servers on the network.
		// Active Directory Client Extension:  Not supported.
		EnabledForDelegation                           = 16777216   // 0x1000000
	}
}