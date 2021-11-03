using System;

namespace TalkingClock
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();

            if (args.Length == 0)
            {
                Console.WriteLine(Virtusa.TellTime(string.Empty));
            }
            else
            {
                Console.WriteLine(Virtusa.TellTime(args[0]));
            }

            Console.ReadLine();
        }
    }
}
