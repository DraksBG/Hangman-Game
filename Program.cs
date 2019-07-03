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
            
           
            foreach (var item in wordChar)
            {
                Console.WriteLine(item);
            }
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
       static int Guessed(int guesses, char input, char[] word)
       {
            bool gameRunning = true;
            guesses = 10;
            input = Input();
            word = GeneratingCharFromString();

            for (int i = 0; i < word.Length; i++)
            {
                if (input != word[i])
                {
                    guesses = -1;
                }
            }
            if (inp)
            {
                gameRunning = false;

            }
        }
        //static bool Update (int input, int number, char guesses, char symbols)
        //{
        //    return with if statmen if true if the user guessed the right char from the word it apears or 
        //        if false if it dosent it his guesses are decreesed
        //}
        //static bool GameRunningUntil(int input, int number, string word, char guessed)
        //{
        //    return the game will run while the user sucessfuly input all the char until the guesses hasn't ended
        //        or if the guesses becomes 0;
        //}

        static void Main(string[] args)
        {
            string randomWord = GeneratingRandomWords();
            TransformingCharToInvisible(randomWord);
           
            
            

            //while (true)
            //{
            //    //here will go all the other methods
            //}

        }
    }
}
