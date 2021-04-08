// <copyright file="IDataSumFinder.cs" company="David Harillo Sánchez">
// Copyright (C) David Harillo Sánchez. All rights reserved.
// Licensed under the LGPL v2.1 License. See the LICENSE file in the project root for full license information.
// </copyright>

namespace ReportRepair
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Data finder to get the values in a collection that sum an specific amount.
    /// </summary>
    public interface IDataSumFinder
    {
        /// <summary>
        /// Gets the value searched as summatory of two values in a collection.
        /// </summary>
        /// <value>The value searched.</value>
        int AmountSearched { get; }

        /// <summary>
        /// Finds a pair of values in the given collection that sums the expected value.
        /// </summary>
        /// <param name="values">Collection of values to search.</param>
        /// <returns>Pair of value that sum the searched value or <c>null</c> if the collection does not contain a pair valid.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="values"/> is <c>null</c>.</exception>
        Tuple<int, int> FindPair(IEnumerable<int> values);
    }
}