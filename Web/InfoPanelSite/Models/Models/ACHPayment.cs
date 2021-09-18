using InfoPanelService.Data.Enums;
using System;

namespace InfoPanelModels.Models
{
    /// <summary>
    /// Summary description for TodoItem
    /// </summary>
    public class ACHPayment : BaseFakeItem
    {
        public string MemberSenderId { get; set; }
        public string MemberBeneficiaryId { get; set; }
        public DateTime PaymentDate { get; set; }
        public double Amount { get; set; }
        public string CurrenyId { get; set; }
        public string CurrencyId { get; set; }
        public PaymentState PaymentState { get; set; }
        public string Error { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
    }
}
