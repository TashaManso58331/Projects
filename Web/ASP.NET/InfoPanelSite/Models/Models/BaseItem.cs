using System;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace InfoPanelModels.Models
{
    public class BaseItem
    {
        string id;

        [JsonProperty(PropertyName = "id")]
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        [Version]
        public string Version { get; set; }

        public virtual bool HasFake()
        {
            return false;
        }
    }
}
