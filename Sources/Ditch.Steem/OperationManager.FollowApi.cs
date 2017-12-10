﻿using System;
using System.Threading;
using Ditch.Core.JsonRpc;
using Ditch.Steem.Operations.Enums;
using Ditch.Steem.Operations.Get;

namespace Ditch.Steem
{

    /// <summary>
    /// follow_api
    /// \libraries\plugins\follow\include\steemit\follow\follow_api.hpp
    /// </summary>
    public partial class OperationManager
    {

        /// <summary>
        /// 
        /// Возвращает список: Либо всех подписчиков пользователя 'following'. 
        /// Либо если указано имя пользователя в параметре 'startFollower' возвращается список совпадающих подписчиков.
        /// </summary>
        /// <param name="following"></param>
        /// <param name="startFollower"></param>
        /// <param name="followType"></param>
        /// <param name="limit"></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<FollowApiObj[]> GetFollowers(string following, string startFollower, FollowType followType, UInt16 limit, CancellationToken token)
        {
            return CustomGetRequest<FollowApiObj[]>("call", token, "follow_api", "get_followers", new object[] { following, startFollower, followType.ToString().ToLower(), limit });
        }

        /// <summary>
        /// 
        /// Aналогично GetFollowers только для подписок
        /// </summary>
        /// <param name="follower"></param>
        /// <param name="startFollowing"></param>
        /// <param name="followType"></param>
        /// <param name="limit"></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<FollowApiObj[]> GetFollowing(string follower, string startFollowing, FollowType followType, UInt16 limit, CancellationToken token)
        {
            return CustomGetRequest<FollowApiObj[]>("call", token, "follow_api", "get_following", new object[] { follower, startFollowing, followType.ToString().ToLower(), limit });
        }

        ///// <summary>
        ///// API name: get_follow_count
        ///// 
        ///// </summary>
        ///// <param name="account">API type: string</param>
        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        ///// <returns>API type: follow_count_api_obj</returns>
        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse<FollowCountApiObj> GetFollowCount(string account, CancellationToken token)
        //{
        //    return CustomGetRequest<FollowCountApiObj>("get_follow_count", token, account);
        //}

        ///// <summary>
        ///// API name: get_feed_entries
        ///// 
        ///// </summary>
        ///// <param name="account">API type: string</param>
        ///// <param name="entryId">API type: uint32_t</param>
        ///// <param name="limit">API type: uint16_t</param>
        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        ///// <returns>API type: feed_entry</returns>
        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse<FeedEntry[]> GetFeedEntries(string account, UInt32 entryId, UInt16 limit, CancellationToken token)
        //{
        //    return CustomGetRequest<FeedEntry[]>("get_feed_entries", token, account, entryId, limit);
        //}

        ///// <summary>
        ///// API name: get_feed
        ///// 
        ///// </summary>
        ///// <param name="account">API type: string</param>
        ///// <param name="entryId">API type: uint32_t</param>
        ///// <param name="limit">API type: uint16_t</param>
        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        ///// <returns>API type: comment_feed_entry</returns>
        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse<CommentFeedEntry[]> GetFeed(string account, UInt32 entryId, UInt16 limit, CancellationToken token)
        //{
        //    return CustomGetRequest<CommentFeedEntry[]>("get_feed", token, account, entryId, limit);
        //}

        ///// <summary>
        ///// API name: get_blog_entries
        ///// 
        ///// </summary>
        ///// <param name="account">API type: string</param>
        ///// <param name="entryId">API type: uint32_t</param>
        ///// <param name="limit">API type: uint16_t</param>
        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        ///// <returns>API type: blog_entry</returns>
        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse<BlogEntry[]> GetBlogEntries(string account, UInt32 entryId, UInt16 limit, CancellationToken token)
        //{
        //    return CustomGetRequest<BlogEntry[]>("get_blog_entries", token, account, entryId, limit);
        //}

        ///// <summary>
        ///// API name: get_blog
        ///// 
        ///// </summary>
        ///// <param name="account">API type: string</param>
        ///// <param name="entryId">API type: uint32_t</param>
        ///// <param name="limit">API type: uint16_t</param>
        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        ///// <returns>API type: comment_blog_entry</returns>
        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse<CommentBlogEntry[]> GetBlog(string account, UInt32 entryId, UInt16 limit, CancellationToken token)
        //{
        //    return CustomGetRequest<CommentBlogEntry[]>("get_blog", token, account, entryId, limit);
        //}

        ///// <summary>
        ///// API name: get_account_reputations
        ///// 
        ///// </summary>
        ///// <param name="lowerBoundName">API type: string</param>
        ///// <param name="limit">API type: uint32_t</param>
        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        ///// <returns>API type: account_reputation</returns>
        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse<AccountReputation[]> GetAccountReputations(string lowerBoundName, UInt32 limit, CancellationToken token)
        //{
        //    return CustomGetRequest<AccountReputation[]>("get_account_reputations", token, lowerBoundName, limit);
        //}


        ///**
        // * Gets list of accounts that have reblogged a particular post
        // */
        ///// <summary>
        ///// API name: get_reblogged_by
        ///// 
        ///// </summary>
        ///// <param name="author">API type: string</param>
        ///// <param name="permlink">API type: string</param>
        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        ///// <returns>API type: account_name_type</returns>
        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse<AccountNameType[]> GetRebloggedBy(string author, string permlink, CancellationToken token)
        //{
        //    return CustomGetRequest<AccountNameType[]>("get_reblogged_by", token, author, permlink);
        //}


        ///**
        // * Gets a list of authors that have had their content reblogged on a given blog account
        // */
        ///// <summary>
        ///// API name: get_blog_authors
        ///// 
        ///// </summary>
        ///// <param name="blogAccount">API type: account_name_type</param>
        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse<KeyValuePair<AccountNameType, UInt32>[]> GetBlogAuthors(AccountNameType blogAccount, CancellationToken token)
        //{
        //    return CustomGetRequest<KeyValuePair<AccountNameType, UInt32>[]>("get_blog_authors", token, blogAccount);
        //}


    }
}
