await ExampleAsyncAndThreadLocal.RunAsync();

public static class ExampleAsyncAndThreadLocal
{
    // private static ThreadLocal<int> local = new ThreadLocal<int>();//output 53000 0;

    private static AsyncLocal<int> _local = new();//output 53000 53000;

    public static Task RunAsync()
    {
        return RunAsyncInternal();
    }

    private static async Task RunAsyncInternal()
    {
        _local.Value = 53000;

        Console.WriteLine($"Before await：{nameof(_local)} = {_local.Value}");

        await Task.Delay(50);

        Console.WriteLine($"After await：{nameof(_local)} = {_local.Value}");
    }
}

