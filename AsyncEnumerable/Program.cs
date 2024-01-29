await AsyncEnumerableExample.Run();
public static class AsyncEnumerableExample
{
    public static async Task Run()
    {
        await foreach (var number in GenerateNumbersAsync(1, 100))
        {
            Console.WriteLine(number);
        }
    }

    private static async IAsyncEnumerable<int> GenerateNumbersAsync(int start, int end)
    {
        var random = new Random();

        var getNumberTasks = Enumerable
            .Range(start, end - start + 1)
            .Select(number => GetNumberAsync(number, random.Next(1, 3)))
            .ToList();

        while (getNumberTasks.Any())
        {
            var completedTask = await Task.WhenAny(getNumberTasks);
            getNumberTasks.Remove(completedTask);
            yield return await completedTask;
        }
    }

    private static async Task<int> GetNumberAsync(int number, int delayInSeconds)
    {
        await Task.Delay(delayInSeconds * 1000);
        return number;
    }
}