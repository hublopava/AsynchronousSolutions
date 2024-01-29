
InterlockedExample.RunIncrement();
InterlockedExample.RunAdd();
InterlockedExample.RunCompareExchange();
InterlockedExample.RunExchange();

public static class InterlockedExample
{
    public static void RunIncrement()
    {
        var counter = 0;

        Parallel.ForEach(Enumerable.Range(0, 1000), (_) =>
        {
            Interlocked.Increment(ref counter);
        });

        Console.WriteLine("Counter: " + counter);
    }

    public static void RunAdd()
    {
        var counter = 0;

        Parallel.ForEach(Enumerable.Range(0, 1000), (_) =>
        {
            Interlocked.Add(ref counter, 10);
        });

        Console.WriteLine("Counter: " + counter);
    }

    public static void RunCompareExchange()
    {
        var counter = 0;

        Parallel.ForEach(Enumerable.Range(0, 1000), (_) =>
        {
            Interlocked.CompareExchange(ref counter, 10, 0);
        });

        Console.WriteLine("Counter: " + counter);
    }

    public static void RunExchange()
    {
        var counter = 0;

        Parallel.ForEach(Enumerable.Range(0, 1000), (_) =>
        {
            Interlocked.Exchange(ref counter, 10);
        });

        Console.WriteLine("Counter: " + counter);
    }
}
