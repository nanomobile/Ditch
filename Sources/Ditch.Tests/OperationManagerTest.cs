﻿using System;
using Ditch.Operations.Post;
using NUnit.Framework;

namespace Ditch.Tests
{
    [TestFixture]
    public class OperationManagerTest : BaseTest
    {
        private readonly OperationManager _operationManager;
        private const string Name = "login";
        private const string PostingKey = "wif";

        public OperationManagerTest()
        {
            GlobalSettings.Init(Name, PostingKey, ChainManager.KnownChains.Steem);
            _operationManager = new OperationManager();
        }


        [Test]
        public void GetDynamicGlobalPropertiesTest()
        {
            var prop = _operationManager.GetDynamicGlobalProperties();
            Assert.IsTrue(prop != null);
            Assert.IsTrue(prop.Result != null);
            Assert.IsFalse(prop.IsError);
        }

        [Test]
        public void GetContentTest()
        {
            var prop = _operationManager.GetContent("steepshot", "c-lib-ditch-1-0-for-graphene-from-steepshot-team-under-the-mit-license");
            Assert.IsTrue(prop != null);
            Assert.IsTrue(prop.Result != null);
            Assert.IsFalse(prop.IsError);
            Assert.IsTrue(prop.Result.TotalPayoutValue.Value > 0);
        }

        [Test]
        [TestCase("277.126 SBD")]
        public void ParseTestTest(string test)
        {
            var money = new Money(test);
            Assert.IsTrue(money.Value == 277126);
            Assert.IsTrue(money.Precision == 3);
            Assert.IsTrue(money.Currency == "SBD");
        }

        [Test]
        public void GetHelp()
        {
            var rez = _operationManager.GetCustomRequest<object>("help");
            Console.WriteLine(rez.Error);
        }

        [Test]
        public void VerifyAuthoritySuccessTest()
        {
            var op = new FollowOperation(GlobalSettings.Login, "steepshot", "blog", new[] { GlobalSettings.Login });
            var rez = _operationManager.VerifyAuthority(op);
            Assert.IsFalse(rez.IsError, rez.GetErrorMessage());
            Assert.IsTrue(rez.Result);
        }

        [Test]
        public void VerifyAuthorityFallTest()
        {
            var op = new FollowOperation(GlobalSettings.Login, "steepshot", "blog", new[] { "StubLogin" });
            var rez = _operationManager.VerifyAuthority(op);
            Assert.IsTrue(rez.IsError);
        }

        [Test]
        public void GetAccountsTest()
        {
            var rez = _operationManager.GetAccounts(GlobalSettings.Login);
            Assert.IsFalse(rez.IsError, rez.GetErrorMessage());
        }

        [Test]
        public void GetChainPropertiesHelp()
        {
            var rez = _operationManager.GetCustomRequest<object>("get_chain_properties");
            Console.WriteLine(rez.Error);
        }

        [Test]
        [Ignore("make transaction")]
        public void FollowTest()
        {
            var op = new FollowOperation(GlobalSettings.Login, "korzunav", "blog", new[] { GlobalSettings.Login });
            var prop = _operationManager.BroadcastOberations(op);
            Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
        }

        /// <summary>
        /// "params": [
        ///     3,
        ///     "broadcast_transaction",
        ///     [
        ///         {
        ///             "ref_block_num": 7663,
        ///             "ref_block_prefix": 66978938,
        ///             "expiration": "2017-07-06T09:42:45",
        ///             "operations": [
        ///                 [
        ///                     "custom_json",
        ///                     {
        ///                         "required_auths": [],
        ///                         "required_posting_auths": [
        ///                             "joseph.kalu"
        ///                         ],
        ///                         "id": "follow",
        ///                         "json": "[\"follow\", {\"follower\": \"joseph.kalu\", \"following\": \"korzunav\", \"what\": [\"\"]}]"
        ///                     }
        ///                 ]
        ///             ],
        ///             "extensions": [],
        ///             "signatures": ["**********************************************************************************************************************************"
        ///             ]
        ///         }
        ///     ]
        /// ],
        /// </summary>
        [Test]
        [Ignore("make transaction")]
        public void UnFollowTest()
        {
            var op = new UnfollowOperation(GlobalSettings.Login, "korzunav", GlobalSettings.Login);
            var prop = _operationManager.BroadcastOberations(op);
            Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
        }

        [Test]
        [Ignore("make transaction")]
        public void UpVoteOperationTest()
        {
            var op = new UpVoteOperation(GlobalSettings.Login, "joseph.kalu", "fkkl");
            var prop = _operationManager.BroadcastOberations(op);
            Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
        }

        [Test]
        [Ignore("make transaction")]
        public void DownVoteOperationTest()
        {
            var op = new DownVoteOperation(GlobalSettings.Login, "joseph.kalu", "fkkl");
            var prop = _operationManager.BroadcastOberations(op);
            Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
        }

        [Test]
        [Ignore("make transaction")]
        public void FlagTest()
        {
            var op = new FlagOperation(GlobalSettings.Login, "joseph.kalu", "fkkl");
            var prop = _operationManager.BroadcastOberations(op);
            Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
        }

        [Test]
        [Ignore("make transaction")]
        [TestCase("steepshot", "testpostwithbeneficiares", "test post with beneficiares", "http://yt3.ggpht.com/-Z7aLVW1IhkQ/AAAAAAAAAAI/AAAAAAAAAAA/k54r-HgKdJc/s900-c-k-no-mo-rj-c0xffffff/photo.jpg", "{\"app\": \"steepshot / 0.0.4\", \"tags\": []}")]
        public void PostTest(string beneficiar, string permlink, string title, string body, string jsonMetadata)
        {
            var op = new PostOperation("test", GlobalSettings.Login, permlink, title, body, jsonMetadata);
            var popt = new BeneficiaresOperation(GlobalSettings.Login, permlink, GlobalSettings.ChainInfo.SbdSymbol, new Beneficiary(beneficiar, 1000));
            var prop = _operationManager.BroadcastOberations(op, popt);
            Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
        }

        [Test]
        [Ignore("make transaction")]
        [TestCase("steepshot", "rutestpostwithbeneficiares", "test post with beneficiares and ru text", "http://yt3.ggpht.com/-Z7aLVW1IhkQ/AAAAAAAAAAI/AAAAAAAAAAA/k54r-HgKdJc/s900-c-k-no-mo-rj-c0xffffff/photo.jpg фотачка и русский текст в придачу!", "{\"app\": \"steepshot / 0.0.4\", \"tags\": []}")]
        public void RuPostTest(string beneficiar, string permlink, string title, string body, string jsonMetadata)
        {
            var op = new PostOperation("test", GlobalSettings.Login, permlink, title, body, jsonMetadata);
            var popt = new BeneficiaresOperation(GlobalSettings.Login, permlink, GlobalSettings.ChainInfo.SbdSymbol, new Beneficiary(beneficiar, 1000));
            var prop = _operationManager.BroadcastOberations(op, popt);
            Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
        }

        [Test]
        [Ignore("make transaction")]
        [TestCase("yanakorsak", "orchids")]
        public void RepostTest(string author, string permlink)
        {
            var op = new RePostOperation(GlobalSettings.Login, author, permlink, GlobalSettings.Login);
            var prop = _operationManager.BroadcastOberations(op);
            Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
        }
    }
}