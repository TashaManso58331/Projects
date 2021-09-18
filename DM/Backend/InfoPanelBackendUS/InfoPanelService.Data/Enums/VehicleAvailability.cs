using System;

namespace InfoPanelService.Data.Enums
{
    public enum VehicleAvailability
    {
        None = 0,
        Car = 1,
        Van = 2,
        Truck = 4,
        Car_Van = Car | Van,
        Car_Van_Truck = Car | Van | Truck,
    }
}
