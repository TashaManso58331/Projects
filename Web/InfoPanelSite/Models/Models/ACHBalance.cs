using InfoPanelService.Data.Enums;
using System;

namespace InfoPanelModels.Models
{
    /// <summary>
    /// Summary description for TodoItem
    /// </summary>
    public class ACHBalance : BaseFakeItem
    {        
        public string MemberId { get; set; }
        public string MemberBeneficiaryId { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public double Amount { get; set; }
        public BalanceStatus Status { get; set; }
    }
}
