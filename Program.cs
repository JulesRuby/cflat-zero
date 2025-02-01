

namespace Lab0ConsoleApp
{
    internal class Program
    {

        // Let's see if I can begin abtracting a validator function to make these do...while loops a bit easier to look at and code. 
        public static bool validateInterger(string userInput, out int value)
        {
            // Yay ternary!
            return int.TryParse(userInput, out value) && value > 0 ? true : false;
        }

        // Try to make a function to generate an array fom the positiveIntergers[] used later
        static int[] fillSequenceArray(params int[] positiveIntegers)
        {
            // calculate the difference + 1 to include all numbers
            int calculatedRange = positiveIntegers[1] - positiveIntegers[0] + 1;
            // declare an array of length = calculatedDifference
            int[] sequenceArray = new int[calculatedRange];

            // use a for loop to populate the array
            for (int i = 0; i < calculatedRange; i++)
            {
                sequenceArray[i] = positiveIntegers[0] + i;
            }

            return sequenceArray;
        }

        static void writeReverseSequenceFile(int[] sequence, string filePath = "numbers.txt")
        {
            // I want to use foreach forFUN so I'm just doing this instead of counting backward through a standard for loop
            Array.Reverse(sequence);


            using(StreamWriter writer = new StreamWriter(filePath)) {
                foreach (int number in sequence)
                {
                    writer.WriteLine(number);
                    // NOTE I guess this saves to the project bin\Debug\net8.0 folder but I have another assignment due soon so I will ahve to be satsfied with this.
                }

            }

            // Seems like Array.reverse is destructive, so now we'll undo that in case I needed the original later or something SO WORTH THE TECH DEBT
            Array.Reverse(sequence);

            Console.WriteLine($"Sequence has been reversed and written to filename {filePath}");
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
                }
                else
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


            int[] sequenceArray = fillSequenceArray(positiveIntegers);

            writeReverseSequenceFile(sequenceArray);

            // Probably a better way to do this...
            Console.WriteLine("\n\nHit any key to finish program.");
            Console.ReadLine();

        }
    }
}
