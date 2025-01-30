namespace Lab0ConsoleApp
{
    internal class Program
    {

        // Let's see if I can begin abtracting a validator function to make these do...while loops a bit easier to look at and code. 
        public static bool validateInterger (string userInput, out int value)
        {
            //if (int.TryParse(userInput, out value) && value > 0)
            //{
            //    return true;
            //} else
            //{
            //    return false;
            //}

            return int.TryParse(userInput, out value) && value > 0 ? true : false;
        }
        

        static void Main(string[] args)
        {
            // PART 1
            string? lowInput = String.Empty;
            string? highInput = String.Empty;
            int lowInt;
            int highInt;
            bool passIntCheck;
           
            Console.WriteLine("Welcome to this really cool, sexy and popular program!\n\n");
            Console.Write("Enter a low number: ");

            do
            {
                lowInput = Console.ReadLine();
                passIntCheck = int.TryParse(lowInput, result: out lowInt);

                if (!passIntCheck)
                {
                    Console.WriteLine("Invalid input, please make sure you are entering an integer.");
                }
            } while (!passIntCheck);


            Console.Write("Enter a high number: ");

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


            //PART 2
            // insert task 2 variables with validation checks here
            int[] positiveIntegers = { 0, 0 };
            positiveIntegers[0] = 1;
            int positiveInteger = 0;
            bool isPosInt = false;
            bool isHigherThanLow = false;

            do
            {
                // Reset validation boolean on each loop
                isPosInt = false;

                string? userInput = String.Empty;

                Console.Write("Enter a low positive integer: ");
                userInput = Console.ReadLine();
                passIntCheck = validateInterger(userInput, out positiveInteger);

                if (passIntCheck)
                {
                    positiveIntegers[0] = positiveInteger;
                    isPosInt = true;
                } else
                {
                    Console.WriteLine("Your input must be a valid integer and also positive!");
                }

            } while (!isPosInt);

            do
            {
                // Reset both validation booleans on higher number loop
                isPosInt = isHigherThanLow = false;
                string? userInput = String.Empty;

                Console.Write("Enter a positive higher value integer: ");
                userInput = Console.ReadLine();
                passIntCheck = validateInterger(userInput, out positiveInteger);

                if (!passIntCheck)
                {
                    Console.WriteLine("Your input must be a valid integer and also positive!");
                    // Skip over the remaining loop 
                    continue;
                }

                positiveIntegers[1] = positiveInteger;
                
                if (positiveIntegers[1] <= positiveIntegers[0])
                {
                    Console.WriteLine("Your integer must be of higher value than your input from the previous step!");
                }
                else
                {
                    isPosInt = isHigherThanLow = true;
                }

            } while (!isPosInt || !isHigherThanLow);
        }
    }
}
