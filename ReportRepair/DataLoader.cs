[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("ReportRepair.Tests")]
namespace ReportRepair
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.IO.Abstractions;

    /// <summary>
    /// Loader class for the input data from a file
    /// </summary>
    internal class DataLoader
    {
        private readonly IFileSystem _fileSystem;
        internal DataLoader(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
        }

        /// <summary>
        /// Loads the problem data from the file indicated
        /// </summary>
        /// <param name="path">Path to the file to load</param>
        /// <returns>Collection of the numbers loaded from the file</returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="path"/> is <c>null</c></exception>
        /// <exception cref="System.ArgumentException">The <paramref name="path"/> is empty or contains only whitespaces</exception>
        /// <exception cref="System.NotSupportedException">The <paramref name="path"/> file does not contain valid data</exception>
        internal IEnumerable<int> Load(string path)
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
                return LoadInternal(path);
            }
            catch (Exception e)
            {
                throw new NotSupportedException("The file given is not valid", e);
            }
        }

        private IEnumerable<int> LoadInternal(string path)
        {
            var lines = this._fileSystem.File.ReadAllLines(path);
            return lines.Select(x => int.Parse(x));
        }
    }
}
