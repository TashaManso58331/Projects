using System;
using System.Collections;

namespace InfoPanelModels.Models
{
    public partial class UserManager : BaseFakeItemManager<User>
    {

        protected override bool CheckValues(IDictionary newValues)
        {
            if (!base.CheckValues(newValues))
                return false;

            if (newValues["Name"] == null || newValues["MemberId"] == null)
                return false;


            return true;
        }

        protected override void UpdateItemBody(User item, IDictionary newValues)
        {
            if (!CheckValues(newValues))
                return;

            item.Name = newValues["Name"].ToString();
            item.Login = newValues["Login"]?.ToString();
            item.Password = newValues["Password"]?.ToString();
            item.MemberId = newValues["MemberId"].ToString();

            item.WireCardUserName = newValues["WireCardUserName"]?.ToString();
            item.Mobile = newValues["Mobile"]?.ToString();
            item.Salutation = newValues["Salutation"]?.ToString();
            item.LastName = newValues["LastName"]?.ToString();
            item.BirthDate = ConvertToDateTime(newValues["BirthDate"]?.ToString());
            item.CountryId = newValues["CountryId"]?.ToString();
            item.Street = newValues["Street"]?.ToString();
            item.Building = newValues["Building"]?.ToString();
            item.Extension = newValues["Extension"]?.ToString();
            item.Zip = newValues["Zip"]?.ToString();
            item.City = newValues["City"]?.ToString();
            item.State = newValues["State"]?.ToString();
            item.FormattedAddress = newValues["FormattedAddress"]?.ToString();
            item.Email = newValues["Email"]?.ToString();
        }

        private DateTime? ConvertToDateTime(string dateTimeStr)
        {
            if (string.IsNullOrEmpty(dateTimeStr))
                return null;

            if (DateTime.TryParse(dateTimeStr, out DateTime dt))
            {
                return dt;
            }

            return null;
        }

        public static UserManager DefaultManager { get; private set; } = new UserManager();
                
    }
}
