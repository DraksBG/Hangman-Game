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

        //static char[] GeneratingCharFromString(string randomWord)
        //{

        //    char[] wordChar = randomWord.ToCharArray();


        //    foreach (var item in wordChar)
        //    {

        //    }
        //    return wordChar;
        //}
        static char Input()
        {
            char inputt = char.Parse(Console.ReadLine());
            return inputt;
        }
        static char[] TransformingCharToInvisible(string randomWord)
        {

            char[] charFromString = randomWord.ToCharArray();
            for (int i = 0; i < randomWord.Length; i++)
            {
                charFromString[i] = '*';

            }
            Console.WriteLine(charFromString);

            return charFromString;
        }

        static int CorrectGuesses(char input, string randomWord, int correct)
        {
            if (randomWord.Contains(input))
            {
                Console.WriteLine("Next");
                correct++;

            }
            return correct;
        }


        static int Lives(string randomWord, char input, int lives)
        {
            if (!randomWord.Contains(input))
            {
                Console.WriteLine("Try another one");
                lives--;
            }
            return lives;
        }

        static List<char> CorrectWord(List<char> correctGuesses, string randomWord, char input)
        {
          
            if (randomWord.Contains(input))
            {
                correctGuesses.Add(input);
                char[] charFromString = randomWord.ToCharArray();
                for (int i = 0; i < randomWord.Length; i++)
                {
                    charFromString[i] = '*';
                    if (correctGuesses.Contains(randomWord[i]))
                    {
                        charFromString[i] = randomWord[i];
                    }

                }
                Console.WriteLine(charFromString);

            }
            return correctGuesses;
        }

        static void Main(string[] args)
        {
            string randomWord = GeneratingRandomWords();
            TransformingCharToInvisible(randomWord);
            List<char> correctGuesses = new List<char>();
            int lives = 10;
            int correct = 0;


            while (true)
            {

                Console.WriteLine("Write a char");
                char input = Input();

                correct = CorrectGuesses(input, randomWord, correct);
                lives = Lives(randomWord, input, lives);
                if (correctGuesses.Contains(input))
                {
                    Console.WriteLine("You've already tried '{0}', and it was correct!", input);
                    continue;
                }
                correctGuesses = CorrectWord(correctGuesses, randomWord, input);
                
                if (lives == 0)
                {
                    Console.WriteLine("You lose sorry, try againg next time ");
                    break;
                }

                if (correctGuesses.Count == randomWord.Length)
                {
                    Console.WriteLine("You won the word is: {0}", randomWord);
                    break;
                }
            }
        }
    }
}
