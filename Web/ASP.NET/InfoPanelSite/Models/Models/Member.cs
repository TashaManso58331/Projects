using Newtonsoft.Json;

namespace InfoPanelModels.Models
{
    /// <summary>
    /// Summary description for TodoItem
    /// </summary>
    public class Member : BaseFakeItem
    {
        public string Name { get; set; }
        public string MemberTypeId { get; set; }
        
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

        public string BankAccount { get; set; }
        public string BIC { get; set; }
        public string BankName { get; set; }
        public string RegistrationNumber { get; set; }
        public string TaxNumber { get; set; }
        public string VATNumber { get; set; }
        public string Phone { get; set; }

        #region WireCard fields
        public string MerchantId { get; set; }
        public string MerchantMCC { get; set; }
        public string BankCity { get; set; }
        public string BankOwner { get; set; }
        #endregion
    }
}
