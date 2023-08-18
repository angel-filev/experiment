namespace Functional;

public class State
{
    private readonly string _internalState;

    public State(string internalState)
    {
        _internalState = internalState;
    }

    public override string ToString()
    {
        return _internalState;
    }

    public State PerformOperation(Operation command) =>
        command switch
        {
            Operation.SystemTest => RunDiagnostics(),
            Operation.Start => StartSystem(),
            Operation.Stop => StopSystem(),
            Operation.Reset => ResetToReady(),
            _ => throw new ArgumentException("Invalid enum value for command", nameof(command)),
        };

    private static State RunDiagnostics()
    {
        Console.WriteLine("Running Diagnostics...");
        return new State("diagnosed");

    }
    private static State StartSystem()
    {
        Console.WriteLine("Starting System...");
        return new State("system running");
    }
    private static State StopSystem()
    {
        Console.WriteLine("Stopping System...");
        return new State("off");
    }
    private static State ResetToReady()
    {
        Console.WriteLine("Resetting to ready...");
        return new State("idle");
    }

    public enum Operation
    { 
        SystemTest,
        Start,
        Stop,
        Reset
    }
}