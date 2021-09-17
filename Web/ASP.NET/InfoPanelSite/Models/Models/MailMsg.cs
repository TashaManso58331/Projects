using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoPanelModels.Models
{
    public class MailMsg
    {
        [JsonProperty(PropertyName = "fromadress")]
        public string FromAdress { get; set; }

        [JsonProperty(PropertyName = "fromname")]
        public string FromName { get; set; }


        [JsonProperty(PropertyName = "toadress")]
        public string ToAdress { get; set; }

        [JsonProperty(PropertyName = "toname")]
        public string ToName { get; set; }


        [JsonProperty(PropertyName = "subject")]
        public string Subject { get; set; }

        [JsonProperty(PropertyName = "plaintextcontent")]
        public string plainTextContent { get; set; }

        [JsonProperty(PropertyName = "htmlcontent")]
        public string htmlContent { get; set; }

    }
}
