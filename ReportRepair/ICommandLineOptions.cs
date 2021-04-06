// <copyright file="ICommandLineOptions.cs" company="David Harillo Sánchez">
// Copyright (C) David Harillo Sánchez. All rights reserved.
// Licensed under the LGPL v2.1 License. See the LICENSE file in the project root for full license information.
// </copyright>
namespace ReportRepair
{
    /// <summary>
    /// Application command line options.
    /// </summary>
    public interface ICommandLineOptions
    {
        /// <summary>
        /// Gets or sets the path to the file with the values to check.
        /// </summary>
        string Path { get; set; }

        /// <summary>
        /// Gets or sets the sum result searched for two values in the file.
        /// </summary>
        int SearchedSum { get; set; }
    }
}