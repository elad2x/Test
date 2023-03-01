//Docs on NUnit parallelization: https://github.com/nunit/docs/wiki/Framework-Parallel-Test-Execution
using NUnit.Framework;

[assembly: Parallelizable(ParallelScope.All)]
[assembly: LevelOfParallelism(3)]

