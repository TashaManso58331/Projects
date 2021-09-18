namespace InfoPanelService.Data.Enums
{
    public enum WireCardReadyStatus
    {
        None = 0,

        MerchantRegistered = 1,
        MerchantProcessing = 2,
        MerchantDocumentsComplete = 3,
        MerchantActive = 4,
        MerchantDeclined = 5,

        BuyerCheckPaymentRegistered = 101,
        BuyerCheckPaymentProcessing = 102,
        BuyerCheckPaymentActive = 103,
        BuyerCheckPaymentDeclined = 104
    }
}
