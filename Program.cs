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
            List<string> words = new List<string>() { "Cat", "Dog", "Eagle", "Lion", "Shark", "Green", "Booty" }; // съсдаден е лист с думи в него които после ще бъдат използвани.
            string word = words[r.Next(0, words.Count)]; // тази променлива съдържа в себе си листа с думи и изпозвайки систем рандом който генерира псевдо рандом число от бройката на думите в листа това число представлява дума от листа която се използва всеки път когато е използвана променливата.
            return word; // връща избраната дума от рандом генератора. 
        }
        static char Input()
        {
            char inputt = char.Parse(Console.ReadLine()); // с този ред правим така че човека да може да въведе инпут от тип чарактър в конозлата.
            return inputt;
        }
        static int Lives(string randomWord, char input, int lives)
        {
            if (!randomWord.Contains(input)) // ако генерираната дума не съдържа в инпута на потребителя да се намалят животите за всеки път щом не се съдържа с едно.
            {
                Console.WriteLine("Try another one");
                lives--;
            }
            return lives;
        }
        static List<char> CorrectWord(List<char> correctGuesses, string randomWord, char input)
        {
            if (randomWord.Contains(input)) // ако рандом думата съдържа инпута на потребителя
            {
                correctGuesses.Add(input);// да го добавя в списъка 
                char[] charFromString = randomWord.ToCharArray(); // създавам чар арай който съдържа в себеси думта на чарактари
                for (int i = 0; i < randomWord.Length; i++) // обхождам я със фор цикл по нейната дължина
                {
                    charFromString[i] = '*'; // заменям индекса на всеки чарактар при всяко завъртане на цикъла със символа.
                    if (correctGuesses.Contains(randomWord[i])) // ако листа съдържа индекса на рандомУърд
                    {
                        charFromString[i] = randomWord[i]; //  чарактъра на символа да се замени с  чарактара на рандомУърд.
                    }
                }
                Console.WriteLine(charFromString);
            }
            return correctGuesses;
        }
        static void Main(string[] args)
        {
            string randomWord = GeneratingRandomWords(); // тази променлива съдържа метода за генерираната рандом дума.
            char[] charFromString = randomWord.ToCharArray();
            for (int i = 0; i < randomWord.Length; i++) // с 
            {
                charFromString[i] = '*';
            }
            Console.WriteLine(charFromString);
            List<char> correctGuesses = new List<char>(); // съсдава се нов лист който ще се пълни чрез метода КоректУърд.
            int lives = 10; 
            while (true) // цикъла се върти докато в него висчко е вярно
            {
                Console.WriteLine("Write a char"); // изписва се 
                char input = Input(); // въвежда се инпут от потребителя

                lives = Lives(randomWord, input, lives); // тази променлива взима стойостта от изпълнения метод и я пази .
                if (correctGuesses.Contains(input)) // ако инпута на потребителя се съдържа в листа да изпише че вече е опитал това.
                {
                    Console.WriteLine("You've already tried '{0}', and it was correct!", input);
                    continue;
                }
                correctGuesses = CorrectWord(correctGuesses, randomWord, input); // това е променливата лист която съдържа метода КорректУърд и се пълни спрямо това как се изпълнява метода.
                if (lives == 0) // ако животите са равни на 0 програмата спира и изписва че потребителя губи
                {
                    Console.WriteLine("You lose sorry, try againg next time ");
                    break;
                }
                if (correctGuesses.Count == randomWord.Distinct().Count())// ако бройката в списъка е равна на бройката на думата ,което става чрез дистикт който премахва дубликатите , които не могат да бъдат въведени от потребителя и по този начин се избягва безкрайния цикъл.
                {
                    Console.WriteLine("You won the word is: {0}", randomWord); // изписва че потребителя е победил и прекъсва програмта.
                    break;
                }
            }
        }
    }
}
