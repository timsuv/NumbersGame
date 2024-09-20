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
            int stringLowGuess = -1;
            int stringHighGuess = -1;
           

            Console.WriteLine("Välkommen! Jag tänker på ett nummer mellan 1 - 20. Kan du gissa vilket? Du får fem försök");
            Console.WriteLine("Skriv din siffra!");



            while (!outOfGuesses)
            {
                //creating an array to to the randomise the message for the low guess and high guesses
                string[] lowGuess = new string[4] { "Tyvärr det var för lågt!", "Ha ha, lågt", "nope, låg", "försök igen, det var lågt" };
                Random randomLowGuesss = new Random();
                stringLowGuess = randomLowGuesss.Next(0, lowGuess.Length);

                string[] highGuess = new string[4] { "För högt!", "Wow, det var långt ifrån", "Ha Ha försök igen, det var långt ifrån", "Nej för högt" };
                Random randomHighGuesses = new Random();
                stringHighGuess = randomHighGuesses.Next(0, highGuess.Length);

                if (Int32.TryParse(Console.ReadLine().Trim(), out userNumber))
                {
                    if (userNumber > 0 && userNumber < 21) //checks is userNumber is in the range
                    {
                        guessCount++;
                        if (userNumber < number)
                        {
                            Console.WriteLine(lowGuess[stringLowGuess]);
                            
                            AlmostOrNot(number, userNumber);
                        }
                        else if (userNumber > number)
                        {
                            Console.WriteLine(highGuess[stringHighGuess]);
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
        static void AlmostOrNot(int number, int userNumber)
        {
            if (number - userNumber == 1 || userNumber - number == 1)
            {
                Console.WriteLine("Men det var nära!");
            }
            else
            {
                Console.WriteLine("Det var långt ifrån!");

            }
        }
        static void Main(string[] args)
        {
            bool playAgain = false;


            while (!playAgain)
            {
                Random random = new Random();
                int number = random.Next(1, 21);

                GuessCount(number);
                Console.WriteLine("Vill du spela igen? (ja/nej)");


                while (true)
                {
                    string answer = Console.ReadLine().ToLower();
                    if (answer == "ja")
                    {
                        playAgain = false;
                        Console.Clear();
                        break;
                    }
                    else if (answer == "nej")
                    {
                        playAgain = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Skriv ja eller nej");
                    }
                }
            }




        }
    }
}
