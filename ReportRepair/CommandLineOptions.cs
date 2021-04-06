// <copyright file="CommandLineOptions.cs" company="David Harillo Sánchez">
// Copyright (C) David Harillo Sánchez. All rights reserved.
// Licensed under the LGPL v2.1 License. See the LICENSE file in the project root for full license information.
// </copyright>
namespace ReportRepair
{
    using CommandLine;

    /// <summary>
    /// Options for the program arguments that allow parsing them using the CommandLine library.
    /// </summary>
    public class CommandLineOptions : ICommandLineOptions
    {
        /// <inheritdoc/>
        [Value(index: 0, Required = true, HelpText = "Input file with the values to check")]
        public string Path { get; set; }

        /// <inheritdoc/>
        [Option(shortName: 's', longName: "searched", Required = false, HelpText = "Sum value searched", Default = 2020)]
        public int SearchedSum { get; set; }
    }
}
