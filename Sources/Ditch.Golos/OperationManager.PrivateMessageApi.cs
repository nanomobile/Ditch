﻿using System;
using System.Threading;
using Ditch.Core.JsonRpc;
using Ditch.Golos.Models.ApiObj;

namespace Ditch.Golos
{
    /// <summary>
    /// private_message
    /// plugins\private_message\include\golos\plugins\private_message\private_message_plugin.hpp
    /// </summary>
    public partial class OperationManager
    {
        /// <summary>
        /// API name: get_inbox
        /// 
        /// </summary>
        /// <param name="to">API type: string</param>
        /// <param name="newest">API type: time_point</param>
        /// <param name="limit">API type: uint16_t</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: message_api_obj</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<MessageApiObj[]> GetInbox(string to, object newest, UInt16 limit, CancellationToken token)
        {
            return CustomGetRequest<MessageApiObj[]>(KnownApiNames.PrivateMessage, "get_inbox", new object[] { to, newest, limit }, token);
        }

        /// <summary>
        /// API name: get_outbox
        /// 
        /// </summary>
        /// <param name="from">API type: string</param>
        /// <param name="newest">API type: time_point</param>
        /// <param name="limit">API type: uint16_t</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: message_api_obj</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<MessageApiObj[]> GetOutbox(string from, object newest, UInt16 limit, CancellationToken token)
        {
            return CustomGetRequest<MessageApiObj[]>(KnownApiNames.PrivateMessage, "get_outbox", new object[] { from, newest, limit }, token);
        }
    }
}
