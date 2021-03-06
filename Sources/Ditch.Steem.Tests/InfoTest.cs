﻿using System.Threading;
using NUnit.Framework;
using System;
using Newtonsoft.Json;

namespace Ditch.Steem.Tests
{
    [TestFixture]
    public class InfoTest : BaseTest
    {
        [Test]
        public void get_methods()
        {
            var resp = Api.CustomGetRequest(KnownApiNames.JsonrpcApi, "get_methods", CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
            WriteLine(JsonConvert.SerializeObject(resp.Result).Replace("\",\"", $"\",{Environment.NewLine}\""));
        }

        [Test]
        public void get_signature()
        {
            var resp = Api.CustomGetRequest(KnownApiNames.JsonrpcApi, "get_signature", new Method(KnownApiNames.DatabaseApi, "list_witness_votes"), CancellationToken.None);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);
            WriteLine(JsonConvert.SerializeObject(resp.Result).Replace("\",\"", $"\",{Environment.NewLine}\""));
        }

        private class Method
        {
            [JsonProperty("method")]
            public string Name { get; set; }

            public Method(string name)
            {
                Name = name;
            }

            public Method(string api, string name)
            {
                Name = $"{api}.{name}";
            }
        }
    }
}
