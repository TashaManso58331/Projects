using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace InfoPanelModels.Models
{
    public class EnumsManager
    {
        public readonly static EnumsManager DefaultManager = new EnumsManager();

        public async Task<ObservableCollection<EnumValues>> GetDispencerVehicleTypesAsync()
        {
            return await LoadEnumValues(typeof(InfoPanelService.Data.Enums.DispencerVehicleType));
        }

        public async Task<ObservableCollection<EnumValues>> GetTruckPortalDispencersTypesAsync()
        {
            return await LoadEnumValues(typeof(InfoPanelService.Data.Enums.TruckPortalDispencersType));
        }

        private static async Task<ObservableCollection<EnumValues>> LoadEnumValues(System.Type type)
        {
            return await Task.Run(() =>
            {
                var result = new List<EnumValues>();
                try
                {
                    foreach (var value in System.Enum.GetValues(type))
                    {
                        result.Add(new EnumValues { Id = ((int)value).ToString(), Name = value.ToString() });
                    }
                    return new ObservableCollection<EnumValues>(result.OrderBy(c => c.Name).ToList());
                }
                catch
                {
                    return new ObservableCollection<EnumValues>(result);
                }
            });
        }

        public async Task<ObservableCollection<EnumValues>> GetTaskSidesAsync()
        {
            return await LoadEnumValues(typeof(InfoPanelService.Data.Enums.TankSide));
        }

        public async Task<ObservableCollection<EnumValues>> GetStationPortalDispencersTypeAsync()
        {
            return await LoadEnumValues(typeof(InfoPanelService.Data.Enums.StationPortalDispencersType));
        }

        public async Task<ObservableCollection<EnumValues>> GetVehicleClassesAsync()
        {
            return await LoadEnumValues(typeof(InfoPanelService.Data.Enums.VehicleClass));
        }

        public async Task<ObservableCollection<EnumValues>> GetVehicleAvailabilityAsync()
        {
            return await LoadEnumValues(typeof(InfoPanelService.Data.Enums.VehicleAvailability));
        }

        public async Task<ObservableCollection<EnumValues>> GetTextTypesAsync()
        {
            return await LoadEnumValues(typeof(InfoPanelService.Data.Enums.TextType));
        }

        public async Task<ObservableCollection<EnumValues>> GetRouteFuelTransactionStepTypesAsync()
        {
            return await LoadEnumValues(typeof(InfoPanelService.Data.Enums.RouteFuelTransactionStepType));
        }

        public async Task<ObservableCollection<EnumValues>> GetStepBehaviorsAsync()
        {
            return await LoadEnumValues(typeof(InfoPanelService.Data.Enums.StepBehavior));
        }

        public async Task<ObservableCollection<EnumValues>> GetPaymentMethodsAsync()
        {
            return await LoadEnumValues(typeof(InfoPanelService.Data.Enums.PaymentMethod));
        }

        public async Task<ObservableCollection<EnumValues>> GetCalcTypesAsync()
        {
            return await LoadEnumValues(typeof(InfoPanelService.Data.Enums.CalcType));
        }
    }
}
