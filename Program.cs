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

       static char[] GeneratingCharFromString()
        {
            string word = GeneratingRandomWords();
            char[] wordChar = word.ToCharArray();
            
           
            //foreach (var item in wordChar)
            //{
            //    Console.WriteLine(item);
            //}
            return wordChar;
        }
        static void TransformingCharToInvisible(string word)
        {
            word = GeneratingRandomWords();
            

            foreach (var item in word)
            {
                Console.Write("_ ");
            }
            Console.WriteLine();

        }
        static char Input()
        {
            char inputt= char.Parse(Console.ReadLine());
            return inputt;
        }
       static bool GameRunning(int guesses,char input, char[]word )
       {
            bool gameRunning = true;
            bool guessedWord = true;
            guesses = 10;
            input = Input();
            word = GeneratingCharFromString();
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] != input)
                {
                    guessedWord = false;
                    Console.WriteLine("You have {0} guesses left", guesses);
                }
                else if (word[i] == input)
                {
                    guessedWord = true;
                }
            }
            if (guessedWord == false )
            {
                guesses--;
            }
            if (guesses == 0)
            {
                gameRunning = false;
            }
            return gameRunning;
        }
       static char Update (char input, char[]word)
       {
            input = Input();
            word = GeneratingCharFromString();
            for (int i = 0; i < word.Length; i++)
            {
                if (input == word[i])
                {
                    Console.WriteLine(word[i]);
                }
                else if (input!= word[i])
                {
                    TransformingCharToInvisible(word.ToString());
                }
                
            }
            return input;
            
       }
        

        static void Main(string[] args)
        {
            string randomWord = GeneratingRandomWords();
            TransformingCharToInvisible(randomWord);
            GeneratingCharFromString();
            int guesses = 10;
            

           while (true)
           {
                char input = Input();
                bool gameIsRunning = GameRunning(guesses, input, GeneratingCharFromString());
                Update(input, GeneratingCharFromString());
                if (gameIsRunning == false)
                {
                    break;
                }
           }

        }
    }
}
