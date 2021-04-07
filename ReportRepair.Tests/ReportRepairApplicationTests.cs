// <copyright file="ReportRepairApplicationTests.cs" company="David Harillo Sánchez">
// Copyright (C) David Harillo Sánchez. All rights reserved.
// Licensed under the LGPL v2.1 License. See the LICENSE file in the project root for full license information.
// </copyright>

namespace ReportRepair
{
    using System;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class ReportRepairApplicationTests
    {
        private Mock<ICommandLineOptions> optionsMock;

        [SetUp]
        public void BeforeEach()
        {
            this.optionsMock = new Mock<ICommandLineOptions>();
        }

        [Test]
        public void Constructor_NullOptions_ShouldThrow()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => new ReportRepairApplication(null));
            Assert.AreEqual("options", exception.ParamName);
        }
    }
}
