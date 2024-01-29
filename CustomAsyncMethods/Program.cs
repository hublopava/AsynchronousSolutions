DeadlockExample.Run();

public static class DeadlockExample
{
    private static readonly object Lock1 = new();
    private static readonly object Lock2 = new();

    public static void Run()
    {
        var thread1 = new Thread(DoWork1);
        var thread2 = new Thread(DoWork2);

        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();

        Console.WriteLine("Program completed.");
    }

    private static void DoWork1()
    {
        lock (Lock1)
        {
            Console.WriteLine("Thread 1 acquired lock1");

            Thread.Sleep(100);

            lock (Lock2)
            {
                Console.WriteLine("Thread 1 acquired lock2");
            }
        }
    }

    private static void DoWork2()
    {
        lock (Lock2)
        {
            Console.WriteLine("Thread 2 acquired lock2");

            Thread.Sleep(100);

            lock (Lock1)
            {
                Console.WriteLine("Thread 2 acquired lock1");
            }
        }
    }
}


