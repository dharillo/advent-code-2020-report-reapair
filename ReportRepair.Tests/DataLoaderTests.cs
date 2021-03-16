namespace ReportRepair
{
    using Moq;
    using NUnit.Framework;
    using System.IO.Abstractions;
    using System;
    using System.Collections.Generic;

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
            fileSystemMock = new Mock<IFileSystem>();
            fileSystemMock.Setup(x => x.File.ReadAllLines(It.IsAny<string>())).Returns(lines);
            sut = new DataLoader(fileSystemMock.Object);
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
            var exception = Assert.Throws<ArgumentNullException>(() => sut.Load(null));
            Assert.AreEqual("path", exception.ParamName);
        }
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("\t")]
        public void Load_EmptyString_ShouldThrow(string invalidPath)
        {
            var exception = Assert.Throws<ArgumentException>(() => sut.Load(invalidPath));
            Assert.AreEqual("path", exception.ParamName);
        }

        [TestCase]
        public void Load_ReadAllLinesThrowsFileNotFound_ShouldThrow()
        {
            fileSystemMock.Setup(x => x.File.ReadAllLines(It.IsAny<string>())).Throws<System.IO.FileNotFoundException>();
            var exception = Assert.Throws<NotSupportedException>(() => sut.Load("some/path"));
            Assert.IsInstanceOf(typeof(System.IO.FileNotFoundException), exception.InnerException);
        }

        [TestCase]
        public void Load_ValidData_ReturnsExpectedValues()
        {
            var result = sut.Load("some/path");
            CollectionAssert.AreEquivalent(expectedValues, result);
        }
    }
}
