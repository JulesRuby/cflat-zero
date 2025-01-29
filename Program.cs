namespace Lab0ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string? lowInput = String.Empty;
            string? highInput = String.Empty;
            int lowInt;
            int highInt;
            bool passIntCheck;


            Console.WriteLine("Welcome to this really cool, sexy and popular program!");
            Console.WriteLine("Enter a low number: ");

            do
            {
                lowInput = Console.ReadLine();
                passIntCheck = int.TryParse(lowInput, result: out lowInt);

                if (!passIntCheck)
                {
                    Console.WriteLine("Invalid input, please make sure you are entering an integer.");
                }
            } while (!passIntCheck);


            Console.WriteLine("Enter a high number: ");

            do
            {
                highInput = Console.ReadLine();
                passIntCheck = int.TryParse(highInput, result: out highInt);

                if (!passIntCheck)
                {
                    Console.WriteLine("Invalid input, please make sure you are entering an integer.");
                }
            } while (!passIntCheck);

            int absoluteValDifference = Math.Abs(highInt - lowInt);

            Console.WriteLine($"The difference between these two values is {absoluteValDifference}");
        }
    }
}
