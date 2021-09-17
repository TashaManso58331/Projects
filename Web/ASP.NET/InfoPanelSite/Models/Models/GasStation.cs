using Newtonsoft.Json;

namespace InfoPanelModels.Models
{
    public class GasStation : BaseItem
    {
        public string PublicId { get; set; }

        public string ShortName { get; set; }

        public string Direction { get; set; }

        public string Phone { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
        public string CountryId { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public string Extension { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string State { get; set; }

    }
}
