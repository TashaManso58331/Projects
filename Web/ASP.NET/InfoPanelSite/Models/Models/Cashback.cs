﻿using Newtonsoft.Json;

namespace InfoPanelModels.Models
{
    public class Cashback : BaseFakeItem
    {
        [JsonProperty(PropertyName = "publishdatetime")]
        public System.DateTime PublishDateTime { get; set; }

        [JsonProperty(PropertyName = "gasstationid")]
        public string GasStationId { get; set; }

        [JsonProperty(PropertyName = "memberid")]
        public string MemberId { get; set; }

        [JsonProperty(PropertyName = "fuelid")]  
        public string FuelId { get; set; }
        [JsonProperty(PropertyName = "currencyid")]
        public string CurrencyId { get; set; }
        [JsonProperty(PropertyName = "formula")]
        public string Formula { get; set; }
        [JsonProperty(PropertyName = "buyerid")]
        public string BuyerId { get; set; }
        public System.DateTime ValidFrom { get; set; }
        public System.DateTime? ValidTo { get; set; }
        public bool IsLatestPrice { get; set; }
    }
}
