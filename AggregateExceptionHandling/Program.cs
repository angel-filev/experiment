// See https://aka.ms/new-console-template for more information

void SlowFunction(int delay)
{
    Task.Delay(delay).GetAwaiter().GetResult();
    Console.WriteLine($"Task Thread: {Thread.CurrentThread.ManagedThreadId}");
    throw new CustomException($"Task Thread: {Thread.CurrentThread.ManagedThreadId} failed pretty badly");
}

Console.WriteLine("Hello, World!");

Console.WriteLine($"Main: {Thread.CurrentThread.ManagedThreadId}");

//Wait throws AggregateException. Use AggregateException.Handle to resolve the errors. 
try
{
    // run task on a separate thread that throws exception
    var task1 = Task.Run(() => SlowFunction(500));
    task1.Wait();
}
catch (AggregateException aggregateException)
{
    // Call the Handle method to handle the custom exception, otherwise rethrow the exception.
    aggregateException.Handle(ex =>
    {
        if (ex is CustomException)
        {
            Console.WriteLine(ex.Message);
        }

        return ex is CustomException;
    });
}

//GetAwaiter().GetResult() resolves the AggregateException to the actual exception.
try
{
    // run task on a separate thread that throws exception
    var task2 = Task.Run(() => SlowFunction(500));
    task2.GetAwaiter().GetResult();
}
catch (CustomException customException)
{
    Console.WriteLine(customException.Message);
}

Console.WriteLine($"Main: {Thread.CurrentThread.ManagedThreadId}");