using BenchmarkDotNet.Attributes;

namespace Lab.Benchmark.StringOp;

[MemoryDiagnoser]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class StringCollection
{
    private readonly List<string> data = new List<string>();

    [GlobalSetup]
    public void GlobalSetup()
    {
        for(int i = 65; i < 90; i++)
        {
            char c = (char)i;
            data.Add(c.ToString());
        }
    }

    [Benchmark]
    public string? Single() => data.SingleOrDefault(x => x.Equals("M"));

    [Benchmark]
    public string? First() => data.FirstOrDefault(x => x.Equals("M"));
}
