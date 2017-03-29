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
        static Dictionary<char, string> ConvertDictionary = new Dictionary<char, string>();
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
            var rv = string.Empty;
            foreach (char Letter in input)
            {
                if (ConvertDictionary.ContainsKey(Letter)) //Letter is the key
                {
                    ConvertDictionary.TryGetValue(Letter, out string valueLetter);
                    rv += valueLetter;
                    Console.WriteLine(valueLetter); //You need to display that string back to the user in Morse Code
                }
            }
            return rv; 
        }


        //Save the users input to a CSV as both the original string and encoded.
       static void SaveInputToCSV(string translation)
        {
            using (var input = new StreamWriter(userPath))
            {                
                    input.WriteLine(translation);  /// hi,......
                
            }

        }


        static void Main(string[] args)
        {
            ConvertDictionary = ReadMorseCodeFromFile();
            UserInput();
            var translation =  TranslateCodeToMorseCode();  //named my TranslateCode Method as a variable to then feed into another method
            SaveInputToCSV(translation); //feed translation variable into SaveInputToCSV Method

        }

        
 
        
    }
}
