using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /// <summary>
    /// field_def
    /// libraries\chain\include\eosio\chain\contracts\types.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class FieldDef
    {

        /// <summary>
        /// API name: name
        /// 
        /// </summary>
        /// <returns>API type: field_name</returns>
        [JsonProperty("name")]
        public string Name {get; set;}

        /// <summary>
        /// API name: type
        /// 
        /// </summary>
        /// <returns>API type: type_name</returns>
        [JsonProperty("type")]
        public string Type {get; set;}
    }
}
