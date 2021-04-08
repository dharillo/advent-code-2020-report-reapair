// <copyright file="DataLoaderTests.cs" company="David Harillo Sánchez">
// Copyright (C) David Harillo Sánchez. All rights reserved.
// Licensed under the LGPL v2.1 License. See the LICENSE file in the project root for full license information.
// </copyright>
namespace ReportRepair.IO
{
    using System;
    using System.Collections.Generic;
    using System.IO.Abstractions;

    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class DataLoaderTests
    {
        private DataLoader sut;
        private Mock<IFileSystem> fileSystemMock;
        private string[] lines = new string[] { "1721", "979", "366", "299", "675", "1456" };
        private IEnumerable<int> expectedValues = new List<int> { 1721, 979, 366, 299, 675, 1456 };

        [SetUp]
        public void BeforeEach()
        {
            this.fileSystemMock = new Mock<IFileSystem>();
            this.fileSystemMock.Setup(x => x.File.ReadAllLines(It.IsAny<string>())).Returns(this.lines);
            this.sut = new DataLoader(this.fileSystemMock.Object);
        }

        [TestCase]
        public void Constructor_NullArgument_ShouldThrow()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => new DataLoader(null));
            Assert.AreEqual("fileSystem", exception.ParamName);
        }

        [TestCase]
        public void Load_NullArgument_ShouldThrow()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => this.sut.Load(null));
            Assert.AreEqual("path", exception.ParamName);
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase("\t")]
        public void Load_EmptyString_ShouldThrow(string invalidPath)
        {
            var exception = Assert.Throws<ArgumentException>(() => this.sut.Load(invalidPath));
            Assert.AreEqual("path", exception.ParamName);
        }

        [TestCase]
        public void Load_ReadAllLinesThrowsFileNotFound_ShouldThrow()
        {
            this.fileSystemMock.Setup(x => x.File.ReadAllLines(It.IsAny<string>())).Throws<System.IO.FileNotFoundException>();
            var exception = Assert.Throws<NotSupportedException>(() => this.sut.Load("some/path"));
            Assert.IsInstanceOf(typeof(System.IO.FileNotFoundException), exception.InnerException);
        }

        [TestCase]
        public void Load_ValidData_ReturnsExpectedValues()
        {
            var result = this.sut.Load("some/path");
            CollectionAssert.AreEquivalent(this.expectedValues, result);
        }
    }
}
