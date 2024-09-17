using System.Net.NetworkInformation;

namespace NumbersGame

{
    internal class Program
    {
        static void GuessCount(int number)
        {
            int guessCount = 0;
            int guessLimit = 5;
            bool outOfGuesses = false;
            int userNumber = 0;
            

            Console.WriteLine("Välkommen! Jag tänker på ett nummer mellan 1 -20. Kan du gissa vilket? Du får fem försök");
            Console.WriteLine("Skriv din siffra!");

           

            while (!outOfGuesses)
            {
                if (Int32.TryParse(Console.ReadLine().Trim(), out userNumber))
                {
                    if (userNumber > 0 && userNumber < 21) //checks is userNumber is in the range
                    {
                        guessCount++;
                        if (userNumber < number)
                        {
                            Console.WriteLine("Du gissade för lågt!");
                            AlmostOrNot(number, userNumber);
                        }
                        else if (userNumber > number)
                        {
                            Console.WriteLine("Du gissade för högt!");
                            AlmostOrNot(number, userNumber);
                        }
                        else
                        {
                            Console.WriteLine("Du gissade rätt!");
                            return;
                        }
                        if (guessCount < guessLimit)
                        {
                            
                            Console.WriteLine($"Du har kvar {guessLimit - guessCount} försök! \nFörsök med en ny siffra");
                        }
                        else
                        {
                            outOfGuesses = true;
                            Console.WriteLine("Tyvärr har du slut på försök!");
                        }

                    }
                    else //error message that the number is out of the range
                    {
                        Console.WriteLine("Anger en siffra mellan 1-20");
                    }
                }
                else //message to say that the guess number is not a number
                {
                    Console.WriteLine("Mata in en siffra och ingen text");
                }
            }
        }
        static void AlmostOrNot (int number, int userNumber)
        {
            if (number - userNumber == 1 || userNumber - number == 1)
            {
                Console.WriteLine("Men det var nära!");
            }
            else
            {
                Console.WriteLine("Oj det var långt ifrån!");
            }
        }
        static void Main(string[] args)
        {
            Random random = new Random();
            int number = random.Next(1, 20);
            GuessCount(number);
           

        }
    }
}
