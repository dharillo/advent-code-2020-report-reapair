/// <copyright file="DataSumFinder.cs" company="David Harillo Sánchez">
/// Copyright (C) David Harillo Sánchez. All rights reserved.
/// Licensed under the LGPL v2.1 License. See the LICENSE file in the project root for full license information.
/// </copyright>
namespace ReportRepair.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Finds two numbers in a collection that sum an specific amount
    /// </summary>
    internal class DataSumFinder
    {
        /// <summary>
        /// Value searched as summatory of two values in a collection
        /// </summary>
        /// <value>The value searched</value>
        internal int AmountSearched { get; } = 2020;

        /// <summary>
        /// Finds a pair of values in the given collection that sums the expected value
        /// </summary>
        /// <param name="values">Collection of values to search</param>
        /// <returns>Pair of value that sum the searched value or <c>null</c> if the collection does not contain a pair valid</returns>
        /// <exception cref="ArgumentNullException"><paramref name="values"/> is <c<null</c></exception>
        internal Tuple<int, int> FindPair(IEnumerable<int> values)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            var valuesList = new List<int>(values);
            int first = 0;
            int? second = null;
            for (int i = 0; i < valuesList.Count && second == null; ++i)
            {
                first = valuesList[i];
                second = this.FindSecond(first, valuesList.Skip(i));
            }

            return second != null ? new Tuple<int, int>(first, second.Value) : null;
        }

        private int? FindSecond(int firstCandidate, IEnumerable<int> enumerable)
        {
            foreach (var candidate in enumerable)
            {
                if (firstCandidate + candidate == this.AmountSearched)
                {
                    return candidate;
                }
            }

            return null;
        }
    }
}
