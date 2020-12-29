using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Linq;
using System.Diagnostics;

namespace Ishiika.Framework
{
    public class CLI
    {
        public static Serilog.Core.Logger DefaultLogger;
        public static Serilog.Core.Logger IndentLogger;

        public CLI()
        {
            string defaultLoggerTemplate = "[{Timestamp:HH:mm:ss ffff} {Level:u3}] {Message}{NewLine}{Exception}";
            DefaultLogger = new LoggerConfiguration()
                                     .MinimumLevel.Information()
                                     .WriteTo.Console(outputTemplate: defaultLoggerTemplate)
                                     .CreateLogger();

            string indentLoggerTemplate = "[{Timestamp:HH:mm:ss ffff} {Level:u3}] \t{Message}{NewLine}{Exception}";
            IndentLogger = new LoggerConfiguration()
                                     .MinimumLevel.Information()
                                     .WriteTo.Console(outputTemplate: indentLoggerTemplate)
                                     .CreateLogger();
            [Conditional("DEBUG")]
            static void DebugLoggers()
            {
                string defaultLoggerTemplate = "[{Timestamp:HH:mm:ss ffff} {Level:u3}] {Message}{NewLine}{Exception}";
                DefaultLogger = new LoggerConfiguration()
                                     .MinimumLevel.Verbose()
                                     .WriteTo.Console(outputTemplate: defaultLoggerTemplate)
                                     .CreateLogger();

                string indentLoggerTemplate = "[{Timestamp:HH:mm:ss ffff} {Level:u3}] \t{Message}{NewLine}{Exception}";
                IndentLogger = new LoggerConfiguration()
                                         .MinimumLevel.Verbose()
                                         .WriteTo.Console(outputTemplate: indentLoggerTemplate)
                                         .CreateLogger();
            }

            DebugLoggers();
            Log.Logger = DefaultLogger;
        }

        public void Process(string[] args)
        {
            if (args.Length == 1
                && string.Equals(args[0], "all", System.StringComparison.OrdinalIgnoreCase))
            {
                RunAll();
            }
            else if (args.Length == 1)
            {
                RunOne(args[0]);
            }
            else if (args.Length > 1)
            {
                RunMany(args);
            }
            else
            {
                NoArgs();
            }
        }

        private void RunAll()
        {
            var problemTypes = FindProblems();
            if (problemTypes.Count == 0)
            {
                Log.Error("No problems to run. Did you create any?");
                return;
            }

            foreach (var problemType in problemTypes)
            {
                var problem = (IIshiikaProblem)Activator.CreateInstance(problemType);

                ProblemRunner(problem);
            }
        }

        private void RunMany(string[] args)
        {
            foreach (var arg in args)
            {
                RunOne(arg);
            }
        }

        private void RunOne(string problemName)
        {
            var problemTypes = FindProblems();
            if (problemTypes.Count == 0)
            {
                Log.Error("No problems to run. Did you create any?");
                return;
            }

            problemName = problemName.ToLower().Trim().Replace("_", "");

            var problemType = problemTypes.First(p => p.FullName.Contains(problemName));

            if (problemType == null)
            {
                Log.Error("Could find problem named {}.", problemName);
                return;
            }

            var problem = (IIshiikaProblem)Activator.CreateInstance(problemType);

            ProblemRunner(problem);
        }

        private void NoArgs()
        {
            var problemTypes = FindProblems();
            if (problemTypes.Count == 0)
            {
                Log.Error("No problems to run. Did you create any?");
                return;
            }

            var problemType = problemTypes.Last();

            var problem = (IIshiikaProblem)Activator.CreateInstance(problemType);

            ProblemRunner(problem);
        }

        private void ProblemRunner(IIshiikaProblem problem)
        {
            Console.WriteLine();
            Log.Information("Running {id}: {ProblemName}", problem.ProblemID, problem.ProblemName);
            Log.Information("Problem found here: {url}", problem.ProblemURL);

            Log.Logger = CLI.IndentLogger;
            problem.Solve();
            Log.Logger = CLI.DefaultLogger;
        }

        private List<Type> FindProblems()
        {
            var problemInterface = typeof(IIshiikaProblem);
            var problems = AppDomain.CurrentDomain.GetAssemblies()
                            .SelectMany(a => a.GetTypes())
                            .Where(t => problemInterface.IsAssignableFrom(t) && t.Name != "IIshiikaProblem")
                            .OrderBy(p => p.FullName);

            return problems.ToList();
        }
    }
}