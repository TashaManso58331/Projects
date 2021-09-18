namespace InfoPanelService.Data.Enums
{
    public enum FuelTransactionStatus
    { 
        // Created
        Generated = 100,
        Queued = 110,
        Next = 120,
        Approved = 210,
        Performed = 310,

        // Cancelled 
        Cancelled = 1000,
        System = 9999
    }
}
