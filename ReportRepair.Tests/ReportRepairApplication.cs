// <copyright file="ReportRepairApplication.cs" company="David Harillo Sánchez">
// Copyright (C) David Harillo Sánchez. All rights reserved.
// Licensed under the LGPL v2.1 License. See the LICENSE file in the project root for full license information.
// </copyright>

namespace ReportRepair
{
    using System;

    /// <summary>
    /// Implments the application logic.
    /// </summary>
    internal class ReportRepairApplication
    {
        private ICommandLineOptions options;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportRepairApplication"/> class.
        /// </summary>
        /// <param name="options">Options parsed from the command line arguments.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="options"/> are <c>null</c>.</exception>
        public ReportRepairApplication(ICommandLineOptions options)
        {
            this.options = options ?? throw new ArgumentNullException(nameof(options));
        }
    }
}