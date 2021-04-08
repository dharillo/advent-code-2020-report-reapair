// <copyright file="ReportRepairApplicationTests.cs" company="David Harillo Sánchez">
// Copyright (C) David Harillo Sánchez. All rights reserved.
// Licensed under the LGPL v2.1 License. See the LICENSE file in the project root for full license information.
// </copyright>

namespace ReportRepair
{
    using System;
    using System.Collections.Generic;

    using Moq;

    using NUnit.Framework;

    using ReportRepair.IO;

    [TestFixture]
    public class ReportRepairApplicationTests
    {
        private const string Path = "some/path/to/file.txt";
        private const int ValueSearched = 2020;

        private static readonly List<int> LoadedValues = new List<int> { 1, 2 };

        private Mock<ICommandLineOptions> optionsMock;
        private Mock<IDataLoader> loaderMock;
        private Mock<IDataSumFinder> sumFinder;

        private ReportRepairApplication sut;

        [SetUp]
        public void BeforeEach()
        {
            this.optionsMock = new Mock<ICommandLineOptions>();
            this.loaderMock = new Mock<IDataLoader>();
            this.sumFinder = new Mock<IDataSumFinder>();

            this.optionsMock.SetupGet(x => x.Path).Returns(Path);
            this.optionsMock.SetupGet(x => x.SearchedSum).Returns(ValueSearched);

            this.loaderMock.Setup(x => x.Load(It.IsAny<string>())).Returns(LoadedValues);

            this.sumFinder.Setup(x => x.FindPair(It.IsAny<List<int>>())).Returns(new Tuple<int, int>(1, 2));

            this.sut = new ReportRepairApplication(this.optionsMock.Object, this.loaderMock.Object, this.sumFinder.Object);
        }

        [Test]
        public void Constructor_NullOptions_ShouldThrow()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => new ReportRepairApplication(null, this.loaderMock.Object, this.sumFinder.Object));
            Assert.AreEqual("options", exception.ParamName);
        }

        [Test]
        public void Constructor_NullLoader_ShouldThrow()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => new ReportRepairApplication(this.optionsMock.Object, null, this.sumFinder.Object));
            Assert.AreEqual("loader", exception.ParamName);
        }

        [Test]
        public void Constructor_NullSumFinder_ShouldThrow()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => new ReportRepairApplication(this.optionsMock.Object, this.loaderMock.Object, null));
            Assert.AreEqual("sumFinder", exception.ParamName);
        }

        [Test]
        public void ProcessData_ValidInput_ShouldLoadData()
        {
            this.sut.ProcessData();
            this.loaderMock.Verify(x => x.Load(Path));
        }

        [Test]
        public void ProcessData_ValidInput_ShouldCallSumFinder()
        {
            this.sut.ProcessData();
            this.sumFinder.Verify(x => x.FindPair(LoadedValues));
        }
    }
}
