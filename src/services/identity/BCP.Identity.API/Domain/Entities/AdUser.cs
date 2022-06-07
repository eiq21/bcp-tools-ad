using System.DirectoryServices.AccountManagement;
using System.Security.Principal;

namespace BCP.Identity.API.Domain.Entities
{
    public class AdUser
    {
        public DateTime? AccountExpirationDate { get; set; }
        public DateTime? AccountLockoutTime { get; set; }
        public int BadLogonCount { get; set; }
        public string Description { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public string DistinguishedName { get; set; } = string.Empty;
        public string Domain { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public string EmployeeId { get; set; } = string.Empty;
        public bool? Enabled { get; set; }
        public string GivenName { get; set; } = string.Empty;
        public Guid? Guid { get; set; }
        public string HomeDirectory { get; set; } = string.Empty;
        public string HomeDrive { get; set; } = string.Empty;
        public DateTime? LastBadPasswordAttempt { get; set; }
        public DateTime? LastLogon { get; set; }
        public DateTime? LastPasswordSet { get; set; }
        public string MiddleName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public bool PasswordNeverExpires { get; set; }
        public bool PasswordNotRequired { get; set; }
        public string SamAccountName { get; set; } = string.Empty;
        public string ScriptPath { get; set; } = string.Empty;
        public SecurityIdentifier Sid { get; set; }
        public string Surname { get; set; } = string.Empty;
        public bool UserCannotChangePassword { get; set; }
        public string UserPrincipalName { get; set; } = string.Empty;
        public string VoiceTelephoneNumber { get; set; } = string.Empty;

        public static AdUser MapToAdUser(UserPrincipal user)
        {
            return new AdUser
            {
                AccountExpirationDate = user.AccountExpirationDate ?? null,
                AccountLockoutTime = user.AccountLockoutTime ?? null,
                BadLogonCount = user.BadLogonCount,
                Description = user.Description,
                DisplayName = user.DisplayName,
                DistinguishedName = user.DistinguishedName,
                EmailAddress = user.EmailAddress,
                EmployeeId = user.EmployeeId,
                Enabled = user.Enabled,
                GivenName = user.GivenName,
                Guid = user.Guid,
                HomeDirectory = user.HomeDirectory,
                HomeDrive = user.HomeDrive,
                LastBadPasswordAttempt = user.LastBadPasswordAttempt,
                LastLogon = user.LastLogon,
                LastPasswordSet = user.LastPasswordSet,
                MiddleName = user.MiddleName,
                Name = user.Name,
                PasswordNeverExpires = user.PasswordNeverExpires,
                PasswordNotRequired = user.PasswordNotRequired,
                SamAccountName = user.SamAccountName,
                ScriptPath = user.ScriptPath,
                Sid = user.Sid,
                Surname = user.Surname,
                UserCannotChangePassword = user.UserCannotChangePassword,
                UserPrincipalName = user.UserPrincipalName,
                VoiceTelephoneNumber = user.VoiceTelephoneNumber
            };
        }

        public string GetDomainPrefix() => DistinguishedName
            .Split(',')
            .FirstOrDefault(x => x.ToLower().Contains("dc"))
            .Split('=')
            .LastOrDefault()
            .ToUpper();
    }


}