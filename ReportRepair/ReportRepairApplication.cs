// <copyright file="ReportRepairApplication.cs" company="David Harillo Sánchez">
// Copyright (C) David Harillo Sánchez. All rights reserved.
// Licensed under the LGPL v2.1 License. See the LICENSE file in the project root for full license information.
// </copyright>

namespace ReportRepair
{
    using System;

    using ReportRepair.IO;

    /// <summary>
    /// Implments the application logic.
    /// </summary>
    internal class ReportRepairApplication
    {
        private readonly ICommandLineOptions options;
        private readonly IDataLoader loader;
        private readonly IDataSumFinder sumFinder;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportRepairApplication"/> class.
        /// </summary>
        /// <param name="options">Options parsed from the command line arguments.</param>
        /// <param name="loader">Report data loader.</param>
        /// <param name="sumFinder">Data processor to find the values that sum the expected amount.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="options"/> are <c>null</c>.</exception>
        public ReportRepairApplication(ICommandLineOptions options, IDataLoader loader, IDataSumFinder sumFinder)
        {
            this.options = options ?? throw new ArgumentNullException(nameof(options));
            this.loader = loader ?? throw new ArgumentNullException(nameof(loader));
            this.sumFinder = sumFinder ?? throw new ArgumentNullException(nameof(sumFinder));
        }

        /// <summary>
        /// Processes the data from the file and prints the result of multiplying the two values.
        /// </summary>
        public void ProcessData()
        {
            var data = this.loader.Load(this.options.Path);
            var values = this.sumFinder.FindPair(data);
            Console.WriteLine(values.Item1 * values.Item2);
        }
    }
}