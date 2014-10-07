using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L1A
{
    public class SecretNumber
    {
        //Skriva in variabler
        private int _count; // Ska hålla reda på antalet gissningar.
        private int _number; // Ska tilldelas ett slumpmässigt tal.
        public const int MaxNumberOfGuesses = 7;
        private int MinimumGuess = 1;   //La till dessa två för att minimera fel ifall
        private int MaximumGuess = 100; //man skulle vilja ändra på gissningsintervallet. 

        //Skapa konstruktor/er
            //Hämta Initialize()
        public SecretNumber()
        {
            Initialize();
        }

        //Skapa metoder
            //Initialize
                //Tilldela _number och _count
        public void Initialize()
        {
            _count = 0;
            Random random = new Random();
            _number = random.Next(MinimumGuess, MaximumGuess);
        }

            //MakeGuess
        public bool MakeGuess(int number)
        {
            int guessesLeft = MaxNumberOfGuesses - _count - 1; //Gissningar kvar är antalet angivna maxgissningar, minus antalet försök, minus det senaste försöket.
            //Fel när 7 gissningar gjorts.
            if (_count == MaxNumberOfGuesses) //Skriv MaxNumberOfGuesses och inte 7.
            {
                throw new ApplicationException();
            }

            //Fel vid gissning utanför 1-100.
            if (number < MinimumGuess || number > MaximumGuess)
            {
                throw new ArgumentOutOfRangeException();
            }
            _count++;

                //För låg gissning
            if (number < _number)
            {
                Console.WriteLine("{0} är för lågt. Du har {1} försök kvar.",
                    number, guessesLeft);
            }
            //För hög gissning
            else if (number > _number)
            {
                Console.WriteLine("{0} är för högt. Du har {1} försök kvar.",
                    number, guessesLeft);
            }

            //Noll gissningar kvar - skriv ut en extra rad och avsluta rundan.
            if (guessesLeft == 0)
            {
                Console.WriteLine("Det hemliga talet är {0}", 
                    _number);
                return false;
            }

            //Rätt svar
            if (number == _number)
            {
                return true;
            }

            return false;
        }




    }
}
