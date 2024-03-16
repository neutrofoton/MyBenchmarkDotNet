
using BenchmarkDotNet.Running;
using Lab.Benchmark.StringOp;

Console.WriteLine("Benchmark");

var summaryStringConcate = BenchmarkRunner.Run<StringConcatenation>();
var summaryStringCollection = BenchmarkRunner.Run<StringCollection>();
