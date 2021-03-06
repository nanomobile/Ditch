using Ditch.Steem.Models.Other;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.Return
{
    /// <summary>
    /// get_required_signatures_return
    /// libraries\plugins\apis\database_api\include\steem\plugins\database_api\database_api_args.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class GetRequiredSignaturesReturn
    {

        /// <summary>
        /// API name: keys
        /// 
        /// </summary>
        /// <returns>API type: public_key_type</returns>
        [JsonProperty("keys")]
        public PublicKeyType[] Keys {get; set;}
    }
}
