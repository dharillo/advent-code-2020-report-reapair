// <copyright file="CommandLineOptionsTests.cs" company="David Harillo Sánchez">
// Copyright (C) David Harillo Sánchez. All rights reserved.
// Licensed under the LGPL v2.1 License. See the LICENSE file in the project root for full license information.
// </copyright>
namespace ReportRepair.IO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CommandLine;

    using NUnit.Framework;

    [TestFixture]
    public class CommandLineOptionsTests
    {
        private const string PropertySearchedSum = "SearchedSum";
        private const string PropertyPath = "Path";

        [Test]
        public void Path_ShouldHaveValueAttribute()
        {
            var attributes = this.GetPropertyAttributes<ValueAttribute>(typeof(CommandLineOptions), PropertyPath);
            Assert.IsNotNull(attributes);
            CollectionAssert.IsNotEmpty(attributes);
        }

        [Test]
        public void Path_ShouldConfigureValueAttributeCorrectly()
        {
            var attribute = this.GetPropertyAttributes<ValueAttribute>(typeof(CommandLineOptions), PropertyPath).FirstOrDefault();
            Assert.AreEqual(0, attribute.Index);
            Assert.IsTrue(attribute.Required);
            Assert.AreEqual("Input file with the values to check", attribute.HelpText);
        }

        [Test]
        public void SearchedSum_ShouldHaveOptionAttribute()
        {
            var attributes = this.GetPropertyAttributes<OptionAttribute>(typeof(CommandLineOptions), PropertySearchedSum);
            Assert.IsNotNull(attributes);
            CollectionAssert.IsNotEmpty(attributes);
        }

        [Test]
        public void SearchedSum_ShouldConfigureOptionAttributeCorrectly()
        {
            var attribute = this.GetPropertyAttributes<OptionAttribute>(typeof(CommandLineOptions), PropertySearchedSum).FirstOrDefault();
            Assert.AreEqual("s", attribute.ShortName);
            Assert.AreEqual("searched", attribute.LongName);
            Assert.AreEqual(false, attribute.Required);
            Assert.AreEqual("Sum value searched", attribute.HelpText);
            Assert.AreEqual(2020, attribute.Default);
        }

        private IEnumerable<TResult> GetPropertyAttributes<TResult>(Type type, string propertyName)
        where TResult : Attribute
        {
            var property = type.GetProperty(propertyName);
            return property?.GetCustomAttributes(typeof(TResult), true).Select(x => x as TResult);
        }
    }
}
