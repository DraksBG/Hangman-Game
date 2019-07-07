using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman_game
{
    class Program
    {
        static string GeneratingRandomWords()
        {
            Random r = new Random();

            List<string> words = new List<string>() { "cat", "dog", "eagle", "lion", "shark" };
            string word = words[r.Next(0, words.Count)];
            return word;
        }

        static char[] GeneratingCharFromString(string randomWord)
        {

            char[] wordChar = randomWord.ToCharArray();


            foreach (var item in wordChar)
            {

            }
            return wordChar;
        }
        static char Input()
        {
            char inputt = char.Parse(Console.ReadLine());
            return inputt;
        }
        static char[] TransformingCharToInvisible(string randomWord)
        {

            char[] charFromString = GeneratingCharFromString(randomWord);
            for (int i = 0; i < randomWord.Length; i++)
            {
                charFromString[i] = '*';
            }
            Console.WriteLine(charFromString);
            return charFromString;
        }
        //static int Lives()
        //{
        //    int lives = 10;
        //    return lives;
        //}
        static bool CorrectGuesses(char input, string randomWord, List<char> coreguesses)
        {
            coreguesses = new List<char>();
            //char[] playerSees = TransformingCharToInvisible(randomWord);

            int correct = 0;

            if (randomWord.Contains(input))
            {
                Console.WriteLine("Next");
                correct++;
                for (int i = 0; i < randomWord.Length; i++)
                {
                    if (randomWord[i] == input)
                    {
                        coreguesses.Add(input);
                    }


                }
            }

            if (correct == randomWord.Length)
            {
                Console.WriteLine("You won the word is: {0}", randomWord);
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool IncorrectGuesses(char input, string randomWord, int lives)
        {
            if (!randomWord.Contains(input))
            {
                lives--;
                Console.WriteLine("Try another one");
            }
            if (lives == 0)
            {
                Console.WriteLine("You lose sorry, try againg next time ");
                return true;
            }
            else
            {
                return false;
            }

        }



        static void Main(string[] args)
        {
            string randomWord = GeneratingRandomWords();
            int lives = 10;
            TransformingCharToInvisible(randomWord);
            List<char> correctGuesses = new List<char>();
            while (true)
            {
                Console.WriteLine("Write a char");
                char input = Input();
                bool won = CorrectGuesses(input, randomWord, correctGuesses);
                bool game = IncorrectGuesses(input, randomWord, lives);
                if (game)
                {
                    break;
                }
                if (won)
                {
                    break;
                }
                if (correctGuesses.Count== randomWord.Length)
                {
                    Console.WriteLine("WINNER");
                    break;
                }


            }
        }
    }
}
