using System;
using Newtonsoft.Json;

namespace Ditch.Golos.Models.Other
{
    /// <summary>
    /// history_key
    /// libraries\plugins\market_history\include\golos\market_history\order_history_object.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class HistoryKey
    {

        /// <summary>
        /// API name: sequence
        /// = 0;
        /// </summary>
        /// <returns>API type: int64_t</returns>
        [JsonProperty("sequence")]
        public Int64 Sequence {get; set;}
    }
}
