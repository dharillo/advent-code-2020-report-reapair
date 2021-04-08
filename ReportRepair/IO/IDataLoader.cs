// <copyright file="IDataLoader.cs" company="David Harillo Sánchez">
// Copyright (C) David Harillo Sánchez. All rights reserved.
// Licensed under the LGPL v2.1 License. See the LICENSE file in the project root for full license information.
// </copyright>

namespace ReportRepair.IO
{
    using System.Collections.Generic;

    /// <summary>
    /// Loader for input data from a file.
    /// </summary>
    public interface IDataLoader
    {
        /// <summary>
        /// Loads the problem data from the file indicated.
        /// </summary>
        /// <param name="path">Path to the file to load.</param>
        /// <returns>Collection of the numbers loaded from the file</returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="path"/> is <c>null</c>.</exception>
        /// <exception cref="System.ArgumentException">The <paramref name="path"/> is empty or contains only whitespaces.</exception>
        /// <exception cref="System.NotSupportedException">The <paramref name="path"/> file does not contain valid data.</exception>
        IEnumerable<int> Load(string path);
    }
}