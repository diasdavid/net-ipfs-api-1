﻿using Ipfs.Api;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;

namespace Ipfs.Api
{

    [TestClass]
    public class BlockApiTest
    {
        IpfsClient ipfs = TestFixture.Ipfs;
        string hash = "QmPv52ekjS75L4JmHpXVeuJ5uX2ecSfSZo88NSyxwA3rAQ";
        byte[] blob = Encoding.UTF8.GetBytes("blorb");

        [TestMethod]
        public void Put_Bytes()
        {
            var block = ipfs.Block.PutAsync(blob).Result;
            Assert.AreEqual(hash, block.Hash);
            CollectionAssert.AreEqual(blob, block.DataBytes);
        }

        [TestMethod]
        public void Put_Block()
        {
            var block1 = new Block { DataBytes = blob };
            var block2 = ipfs.Block.PutAsync(block1).Result;
            Assert.AreEqual(hash, block2.Hash);
            CollectionAssert.AreEqual(blob, block2.DataBytes);
        }

        [TestMethod]
        public void Get()
        {
            var block = ipfs.Block.GetAsync(hash).Result;
            Assert.AreEqual(hash, block.Hash);
            CollectionAssert.AreEqual(blob, block.DataBytes);
        }

        [TestMethod]
        public void Stat()
        {
            var info = ipfs.Block.StatAsync(hash).Result;
            Assert.AreEqual(hash, info.Key);
            Assert.AreEqual(5, info.Size);
        }

    }
}
