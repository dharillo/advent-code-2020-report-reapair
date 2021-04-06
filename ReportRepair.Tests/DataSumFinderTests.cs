/// <copyright file="DataSumFinderTests.cs" company="David Harillo Sánchez">
/// Copyright (C) David Harillo Sánchez. All rights reserved.
/// Licensed under the LGPL v2.1 License. See the LICENSE file in the project root for full license information.
/// </copyright>
namespace ReportRepair
{
    using System;
    using System.Collections.Generic;

    using NUnit.Framework;

    [TestFixture]
    public class DataSumFinderTests
    {
        private DataSumFinder sut;
        private IEnumerable<int> sampleValues;

        [SetUp]
        public void BeforeEach()
        {
            this.sampleValues = new List<int> { 1721, 979, 366, 299, 675, 1456 };
            this.sut = new DataSumFinder();
        }

        [TestCase]
        public void FindPair_NullArgument_Throws()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => this.sut.FindPair(null));
            Assert.AreEqual("values", exception.ParamName);
        }

        [TestCase]
        public void FindPair_EmptyCollection_ReturnsNull()
        {
            var result = this.sut.FindPair(new List<int>());
            Assert.IsNull(result);
        }

        [TestCase]
        public void FindPair_CollectionWithSum_ReturnsPair()
        {
            var result = this.sut.FindPair(this.sampleValues);
            Assert.AreEqual(1721, result.Item1);
            Assert.AreEqual(299, result.Item2);
        }
    }
}
