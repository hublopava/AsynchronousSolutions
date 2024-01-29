ParallelExample.RunInvoke();
ParallelExample.RunForEach();

public static class ParallelExample
{
    public static void RunInvoke()
    {
        var action1 = () => Console.WriteLine("Action 1");
        var action2 = () => Console.WriteLine("Action 2");
        var action3 = () => Console.WriteLine("Action 3");

        Parallel.Invoke(action1, action2, action3);
    }

    public static void RunForEach()
    {
        var items = new[] { "Foreach-1", "Foreach-2", "Foreach-3" };

        Parallel.ForEach(items, item =>
        {
            Console.WriteLine(item);
        });
    }
}
