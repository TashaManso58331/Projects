using Newtonsoft.Json;

namespace InfoPanelModels.Models
{
    public class Currency : BaseItem
    {
        string shortName;
        [JsonProperty(PropertyName = "shortname")]
        public string ShortName
        {
            get { return shortName; }
            set { shortName = value; }
        }

        string fullName;
        [JsonProperty(PropertyName = "fullname")]
        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        string textCode;
        [JsonProperty(PropertyName = "textcode")]
        public string TextCode
        {
            get { return textCode; }
            set { textCode = value; }
        }

        int numCode;
        [JsonProperty(PropertyName = "numcode")]
        public int NumCode
        {
            get { return numCode; }
            set { numCode = value; }
        }
    }
}
