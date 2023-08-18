namespace Functional;

//https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/pattern-matching
public class PatternMatching
{
    public bool IsInteger(int? input)
    {
        if (input is int number)
        {
            Console.WriteLine($"The nullable int 'input' has the value {number}");
            return true;
        }
        else
        {
            Console.WriteLine("The nullable int 'input' doesn't hold a value");
            return false;
        }
        
    }
    
    public static T MidPoint<T>(IEnumerable<T> sequence)
    {
        if (sequence is IList<T> list)
        {
            return list[list.Count / 2];
        }
        else if (sequence is null)
        {
            throw new ArgumentNullException(nameof(sequence), "Sequence can't be null.");
        }
        else
        {
            int halfLength = sequence.Count() / 2 - 1;
            if (halfLength < 0) halfLength = 0;
            return sequence.Skip(halfLength).First();
        }
    }
    
    
}