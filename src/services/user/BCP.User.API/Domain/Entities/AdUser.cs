using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Globalization;
using System.Text;

namespace BCP.User.API.Domain.Entities
{
    public class AdUser
    {
        //public string DisplayName { get; set; } = string.Empty;
        //public string DistinguishedName { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        //public string EmployeeId { get; set; } = string.Empty;
        public bool? Enabled { get; set; }
        //public string GivenName { get; set; } = string.Empty;
        //public Guid? Guid { get; set; }
        //public string MiddleName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string SamAccountName { get; set; } = string.Empty;
        public DateTime? LastLogin { get; set; }
        //public string Surname { get; set; } = string.Empty;
        //public string UserPrincipalName { get; set; } = string.Empty;

        public static AdUser MapToAdUser(UserPrincipal user)
        {
            return new AdUser
            {
                //DisplayName = user.DisplayName,
                //DistinguishedName = user.DistinguishedName,
                EmailAddress = user.EmailAddress,
                //EmployeeId = user.EmployeeId,
                Enabled = user.Enabled,
                //GivenName = user.GivenName,
                //Guid = user.Guid,
                //MiddleName = user.MiddleName,
                Name = user.Name,
                SamAccountName = user.SamAccountName,
                LastLogin = user.LastLogon
                //Surname = user.Surname,
                //UserPrincipalName = user.UserPrincipalName,
            };
        }
        public static StringBuilder ToStringBuilder(List<AdUser> adUsers, string? group = null)
        {
            var newGroup = string.IsNullOrEmpty(group) ? string.Empty : group;

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<table border=`" + "1px" + "`b>");
            stringBuilder.Append("<tr>");
            stringBuilder.Append($"<td><b><font face=Arial Narrow size=3>GRUPO DE RED</font></b></td>");
            stringBuilder.Append($"<td><b><font face=Arial Narrow size=3>MATRICULA</font></b></td>");
            stringBuilder.Append($"<td><b><font face=Arial Narrow size=3>NOMBRES Y APELLIDOS</font></b></td>");
            stringBuilder.Append($"<td><b><font face=Arial Narrow size=3>EMAIL</font></b></td>");
            stringBuilder.Append($"<td><b><font face=Arial Narrow size=3>ESTADO</font></b></td>");
            stringBuilder.Append($"<td><b><font face=Arial Narrow size=3>ULTIMO ACCESO</font></b></td>");
            stringBuilder.Append("</tr>");

            foreach (var user in adUsers)
            {
                var email = string.IsNullOrEmpty(user.EmailAddress) ? string.Empty : user.EmailAddress;
                stringBuilder.Append("<tr>");
                stringBuilder.Append("<td><font face=Arial Narrow size=" + "14px" + ">" + newGroup + "</font></td>");
                stringBuilder.Append("<td><font face=Arial Narrow size=" + "14px" + ">" + user.SamAccountName.ToString() + "</font></td>");
                stringBuilder.Append("<td><font face=Arial Narrow size=" + "14px" + ">" + user.Name.ToString() + "</font></td>");
                stringBuilder.Append("<td><font face=Arial Narrow size=" + "14px" + ">" + email + "</font></td>");
                stringBuilder.Append("<td><font face=Arial Narrow size=" + "14px" + ">" + user.Enabled.ToString() + "</font></td>");
                stringBuilder.Append("<td><font face=Arial Narrow size=" + "14px" + ">" + user.LastLogin.ToString() + "</font></td>");
                stringBuilder.Append("</tr>");
            }
            return stringBuilder;
        }

        //public string GetDomainPrefix() => DistinguishedName
        //    .Split(',')
        //    .FirstOrDefault(x => x.ToLower().Contains("dc"))
        //    .Split('=')
        //    .LastOrDefault()
        //    .ToUpper();
    }
}
