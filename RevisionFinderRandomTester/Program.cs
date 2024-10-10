var seedGen = new Random(0);
var guard = new object();
var seedsCompleted = new Dictionary<int, bool>();

IEnumerable<int> GetNextSeed()
{
    while (true)
    {
        int seed;
        lock (guard)
        {
            while (true)
            {
                seed = seedGen.Next();
                if (seedsCompleted.TryAdd(seed, false))
                {
                    break;
                }
            }
        }
        
        Thread.Sleep(100);

        yield return seed;
    }
}

void TestSeed(int seed)
{
    var random = new Random(seed);
    lock (guard)
        Console.WriteLine($"Testing seed {seed}");

    var repository = BuildMemoryGitTree(random);
    var 
}

Parallel.ForEach(GetNextSeed(), TestSeed);
