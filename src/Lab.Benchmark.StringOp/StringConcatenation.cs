using System.Text;
using BenchmarkDotNet.Attributes;

namespace Lab.Benchmark.StringOp;

[MemoryDiagnoser]
public class StringConcatenation
{
    const int N = 100;

    [Benchmark]
    public string StringJoin()
    {
      return string.Join(", ", Enumerable.Range(0, N).Select(i => i.ToString()));
    }
    
    [Benchmark]
    public string StringBuilder()
    {
      var sb = new StringBuilder();
      for (int i = 0; i < N; i++)
      {
          sb.Append(i);
          sb.Append(", ");
      }
    
      return sb.ToString();
    }

    [Benchmark]
    public string StringPlusOperation()
    {
      var s = string.Empty;
      for (int i = 0; i < N; i++)
      {
        s+=$"{i},";
      }
    
      return s;
    }
}
