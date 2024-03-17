
using BenchmarkDotNet.Running;
using Lab.Benchmark.NetLog;

public class Program
{
    public static void Main(string[] args)
    {
        var summaries = BenchmarkRunner.Run(typeof(Program).Assembly);
        //var summaries = BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);

        //var summaryNetLogTechnique = BenchmarkRunner.Run<NetLogTechniqueComparation>();
    }
    
}

