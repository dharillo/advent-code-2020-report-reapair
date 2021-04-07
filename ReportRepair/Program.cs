// <copyright file="Program.cs" company="David Harillo Sánchez">
// Copyright (C) David Harillo Sánchez. All rights reserved.
// Licensed under the LGPL v2.1 License. See the LICENSE file in the project root for full license information.
// </copyright>

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("ReportRepair.Tests")]

namespace ReportRepair
{
    using System.Threading.Tasks;
    using CommandLine;

    public class Program
    {
        public static async Task<int> Main(string[] args)
        {
            return await Parser.Default.ParseArguments<CommandLineOptions>(args)
                .MapResult(
                (CommandLineOptions opts) =>
                {
                    // TODO
                    return Task.FromResult(-3);
                },
                errs => Task.FromResult(-1));
        }
    }
}
