namespace InfoPanelService.Data.Enums
{
    public enum RouteFuelTransactionStepType
    {
        // before first step
        AcceptedRouteSummary = 0,
        GoToNextGasStation = 1,   
        ArrivedAndLocationMatch = 2, 
        SelectDispencerNumberAndReadyToGetFuel = 3,
        CheckingOutFAandAMS = 4, 
        SwitchDispencerOn = 5,
        GettingFuel = 6,
        AwaitConfirmFromCashier = 7, 
        CheckingOutPayment = 9,
        CashierConfirmation = 8,
        CreditCardPayment = 20,

        DefiningPaymentMethod = 10,
        EstimationVolumeWishOrOrdered = 11,

        CheckingOutPaymentAtCounterFirst = 12,
        CheckingOutPaymentAtCounterSecond = 13,
        CheckingOutPaymentFinalization = 14,
        CheckingOutPaymentHold = 15,

        DefiningPaymentMethodAndConfirmation = 16, // (~AwaitConfirmFromCashier)
        QuickCreditCardPayment = 17,
        ACHPayment = 18,
        PostACHPayment = 19,

        CreditCardAuthorization = 21,
        CreditCardCapture = 22,
        SelectHoldAmount = 23,
        CashierConfirmationAndCardCapture = 24,
        SelectPriceAndPattern = 25,
        CreditCardPaymentAuthorizeNet = 26,
        CreditCardAuthorizationAuthorizeNet = 27,

        RouteCompleted = 100
    }
}
