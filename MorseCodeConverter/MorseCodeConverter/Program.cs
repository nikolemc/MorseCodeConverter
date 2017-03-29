using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorseCodeConverter
{

    class Program
    {
        const string path = "morse.csv"; //this is where the Morse Code file lives
        const string userPath = "convertedmorse.csv";
        static Dictionary<char, string> ConvertDictionary = new Dictionary<char, string>(); //this is my dictionary for converting words
        public string Message { get; set; }
        static bool convertingWord;

        //Add Elements to Dictionary
        public static Dictionary<char, string> ReadMorseCodeFromFile()
        {
            var dictonaryConvertor = new Dictionary<char, string>();
            using (var reader = new StreamReader(path))
            {
                while (reader.Peek() > -1)
                {
                    var line = reader.ReadLine().Split(','); // ["A",".-."]
                    dictonaryConvertor.Add(char.Parse(line[0]), line[1]);
                }
            }
            return dictonaryConvertor;
        }

        //ask the user input a string
        static void UserInput()
        {
            Console.WriteLine("Please input a string to get converted to Morse Code");

        }

        //Using the dictionary created above, translate the inputed string into morse code.
        static string TranslateCodeToMorseCode()
        {

            var input = Console.ReadLine().ToUpper();
            convertingWord = input != String.Empty;
            var rv = string.Empty; //the string needs to hold something even if it is empty
            foreach (char Letter in input)
            {
                if (ConvertDictionary.ContainsKey(Letter)) //Letter is the key
                {
                    ConvertDictionary.TryGetValue(Letter, out string valueLetter);
                    rv += valueLetter;
                    Console.WriteLine(valueLetter); //You need to display that string back to the user in Morse Code
                }
            }
            using(var usersInput = File.AppendText(userPath))  //Save the users input to a CSV as both the original string and encoded.
            {

                usersInput.WriteLine(input + ", " + rv);  /// hi,......

            }
            return rv; 
        }


        //Ask the user if they have any more messages that they want to encode
        static void MoreMessagesToConvert()
        {
            do
            {
                Console.WriteLine("Do you want convert another word to Morse code? (Y/N)");
                convertingWord = Console.ReadLine().ToString().ToLower() == "y";

                if (convertingWord)
                {
                    UserInput();
                    TranslateCodeToMorseCode();
                   
                }

            }
            while (convertingWord) ; 
        }


        static void Main(string[] args)
        {
            ConvertDictionary = ReadMorseCodeFromFile();
            UserInput();
            var translation =  TranslateCodeToMorseCode();  //named my TranslateCode Method as a variable to then feed into another method
            MoreMessagesToConvert();

        }

        
 
        
    }
}
