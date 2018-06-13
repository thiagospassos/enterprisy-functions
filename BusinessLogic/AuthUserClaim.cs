using Newtonsoft.Json;

namespace BusinessLogic
{
    public class AuthUserClaim
    {
        [JsonProperty("typ")]
        public string Type { get; set; }
        [JsonProperty("val")]
        public string Value { get; set; }
    }
}