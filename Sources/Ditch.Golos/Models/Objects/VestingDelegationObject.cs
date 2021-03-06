using System;
using Ditch.Golos.Models.Other;
using Newtonsoft.Json;

namespace Ditch.Golos.Models.Objects
{
    /// <summary>
    /// vesting_delegation_object
    /// libraries\chain\include\golos\chain\objects\account_object.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class VestingDelegationObject
    {

        /// <summary>
        /// API name: id
        /// 
        /// </summary>
        /// <returns>API type: id_type</returns>
        [JsonProperty("id")]
        public object Id { get; set; }

        /// <summary>
        /// API name: delegator
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("delegator")]
        public string Delegator { get; set; }

        /// <summary>
        /// API name: delegatee
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("delegatee")]
        public string Delegatee { get; set; }

        /// <summary>
        /// API name: vesting_shares
        /// 
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("vesting_shares")]
        public Asset VestingShares { get; set; }

        /// <summary>
        /// API name: min_delegation_time
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("min_delegation_time")]
        public DateTime MinDelegationTime { get; set; }
    }
}
