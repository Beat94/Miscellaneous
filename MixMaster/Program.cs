namespace MixMaster;
public class Program
{
    public static void Main()
    {
        Console.WriteLine("Hello, World!");


        object test = ("1", "2");

        test.GetType().GetMethod("Item1").Invoke(test, null);
    }
}