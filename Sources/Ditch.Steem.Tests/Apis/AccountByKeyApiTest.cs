﻿using System;
using System.Threading;
using Ditch.Steem.Models.Args;
using Ditch.Steem.Models.Other;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Ditch.Steem.Tests.Apis
{
    [TestFixture]
    public class AccountByKeyApiTest : BaseTest
    {

        [Test]
        public void get_key_references()
        {
            var pubKey = new PublicKeyType("STM6C8GjDBAHrfSqaNRn4FnLLUdCfw3WgjY3td1cC4T7CKpb32YM6");

            var args = new GetKeyReferencesArgs()
            {
                Keys = new[] { pubKey }
            };
            var resp = Api.GetKeyReferences(args, CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
        }
    }
}
