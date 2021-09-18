using Newtonsoft.Json;
using System;

namespace InfoPanelModels.Models
{
    /// <summary>
    /// Summary description for TodoItem
    /// </summary>
    public class User : BaseFakeItem
    {
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string MemberId { get; set; }
        public bool IsConfirmed { get; set; }
        public string ParentUserId { get; set; }

        #region WireCard fields
        public string WireCardUserName { get; set; }
        public string Mobile { get; set; }
        public string Salutation { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        #endregion

        #region Address
        public string CountryId { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public string Extension { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string FormattedAddress { get; set; }
        #endregion

        public string Email { get; set; }
    }
}
