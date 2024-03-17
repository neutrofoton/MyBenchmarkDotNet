using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Toolchains.Roslyn;
using Microsoft.Extensions.Logging;

namespace Lab.Benchmark.NetLog;

[MemoryDiagnoser]
public class NetLogTechniqueComparation
{
    private const string MessageWithParameters = "sample message with parameters {1}, {2}";
    private const string MessageWithoutParameters = "sample message without parameters";
    private ILogger<NetLogTechniqueComparation>? netLogger;

    [GlobalSetup]
    public void GlobalSetup()
    {
        //BenchmarkDotNet comes with a few attributes that can help you accomplish this. 
        //These attributes are [GlobalSetup], [GlobalCleanup], [IterationSetup], and [IterationCleanup].

        //Write your initialization code here
        ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.SetMinimumLevel(LogLevel.Warning);
        });

        netLogger = new Logger<NetLogTechniqueComparation>(loggerFactory);
    }

    [Benchmark]
    public void Log_Without_If_With_Parameters()
    {
        netLogger!.LogInformation(MessageWithParameters,"param1", 2);
    }

    [Benchmark]
    public void Log_Without_If_Without_Parameters()
    {
        netLogger!.LogInformation(MessageWithoutParameters);
    }

    [Benchmark]
    public void Log_With_If_With_Parameters()
    {
        if(netLogger!.IsEnabled(LogLevel.Information))
        {
            netLogger!.LogInformation(MessageWithParameters,"param1", 2);
        }
    }

    [Benchmark]
    public void Log_With_If_Without_Parameters()
    {   
        if(netLogger!.IsEnabled(LogLevel.Information))
        {
            netLogger!.LogInformation(MessageWithoutParameters);
        }
    }
}
