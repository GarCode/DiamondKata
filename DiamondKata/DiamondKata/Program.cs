// See https://aka.ms/new-console-template for more information
using DiamondKata;
using DiamondKata.Exceptions;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Diamonds are forever!");
        Console.WriteLine();

        try
        {
            if (args.Length == 0)
            {
                throw new InvalidInputException("You are missing the character you wish to create a diamond of.");
            }

            var input = args[0];

            var diamondCreator = new DiamondCreator();
            Console.WriteLine(diamondCreator.Create(input));
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex.Message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}