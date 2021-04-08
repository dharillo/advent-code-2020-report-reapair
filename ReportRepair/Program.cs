// <copyright file="Program.cs" company="David Harillo Sánchez">
// Copyright (C) David Harillo Sánchez. All rights reserved.
// Licensed under the LGPL v2.1 License. See the LICENSE file in the project root for full license information.
// </copyright>

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("ReportRepair.Tests")]

namespace ReportRepair
{
    using System;
    using System.IO.Abstractions;
    using System.Threading.Tasks;

    using CommandLine;

    using ReportRepair.IO;

    public class Program
    {
        public static async Task<int> Main(string[] args)
        {
            return await Parser.Default.ParseArguments<CommandLineOptions>(args)
                .MapResult(
                (CommandLineOptions opts) =>
                {
                    try
                    {
                        var processor = new ReportRepairApplication(opts, new DataLoader(new FileSystem()), new DataSumFinder());
                        processor.ProcessData();
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine($"Unexpected error: {e.Message}");
                        return Task.FromResult(-3);
                    }
                    return Task.FromResult(0);
                },
                errs => Task.FromResult(-1));
        }
    }
}
