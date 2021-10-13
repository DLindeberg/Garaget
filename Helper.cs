using System;

namespace Garaget
{

    static class Helper
    {
        //Riley
        public static int IntValidator()
        {
            string data = Console.ReadLine();
            int input;
            while (!int.TryParse(data, out input))
            {
                Console.WriteLine("Sorry, that's not a valid input, please try agian..");
                data = Console.ReadLine();
            }

            return input;
        }

        //Riley
        public static bool BoolValidator()
        {
            string input = Console.ReadLine();
            while (true)
            {
                if (input.ToLower() == "yes" || input == "1")
                    return true;
                else if (input.ToLower() == "no" || input == "0")
                    return false;
                else
                {
                    Console.WriteLine("Sorry, it's either a yes or a no, or a 1 or a 0.");
                    input = Console.ReadLine();
                }
            }
        }
    }
}