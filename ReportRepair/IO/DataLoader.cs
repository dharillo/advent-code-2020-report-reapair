// <copyright file="DataLoader.cs" company="David Harillo Sánchez">
// Copyright (C) David Harillo Sánchez. All rights reserved.
// Licensed under the LGPL v2.1 License. See the LICENSE file in the project root for full license information.
// </copyright>
namespace ReportRepair.IO
{
    using System;
    using System.Collections.Generic;
    using System.IO.Abstractions;
    using System.Linq;

    /// <summary>
    /// Loader class for the input data from a file.
    /// </summary>
    internal class DataLoader : IDataLoader
    {
        private readonly IFileSystem fileSystem;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLoader"/> class.
        /// </summary>
        /// <param name="fileSystem">Facade to access to the file system.</param>
        /// <exception cref="System.ArgumentNullException">The <paramref name="fileSystem"/> is <c>null</c>.</exception>
        public DataLoader(IFileSystem fileSystem)
        {
            this.fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
        }

        /// <summary>
        /// Loads the problem data from the file indicated.
        /// </summary>
        /// <param name="path">Path to the file to load.</param>
        /// <returns>Collection of the numbers loaded from the file</returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="path"/> is <c>null</c>.</exception>
        /// <exception cref="System.ArgumentException">The <paramref name="path"/> is empty or contains only whitespaces.</exception>
        /// <exception cref="System.NotSupportedException">The <paramref name="path"/> file does not contain valid data.</exception>
        public IEnumerable<int> Load(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException("The path cannot be empty", nameof(path));
            }

            try
            {
                return this.LoadInternal(path);
            }
            catch (Exception e)
            {
                throw new NotSupportedException("The file given is not valid", e);
            }
        }

        private IEnumerable<int> LoadInternal(string path)
        {
            var lines = this.fileSystem.File.ReadAllLines(path);
            return lines.Select(x => int.Parse(x));
        }
    }
}
