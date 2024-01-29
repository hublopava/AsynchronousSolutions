await TaskCompletionSourceExample.RunAsync();

public static class TaskCompletionSourceExample
{
    public static async Task RunAsync()
    {
        Console.WriteLine("Starting the RunAsync method");
        var result = await RunInternalAsync();
        Console.WriteLine($"Result: {result}");

    }

    private static Task<int> RunInternalAsync()
    {
        TaskCompletionSource<int> tcs = new TaskCompletionSource<int>();

        ThreadPool.QueueUserWorkItem(_ =>
        {
            Console.WriteLine("Starting background task");
            Thread.Sleep(2000);

            Console.WriteLine("Sleep completed");
            tcs.SetResult(1000);
            Console.WriteLine("Background task completed -- setting result");
        });

        return tcs.Task;
    }
}
