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
        Dictionary<char, string> ConvertDictionary = new Dictionary<char, string>();

        //Add Elements to Dictionary
        public static Dictionary<char, string> ReadMorseCodeFromFile()
        {
            var rv = new Dictionary<char, string>();
            using (var reader = new StreamReader(path))
            {
                while (reader.Peek() > -1)
                {
                    var line = reader.ReadLine().Split(',') ; // ["A",".-."]
                    rv.Add(char.Parse(line[0]),line[1]);
                }
            }
            return rv;
        }

        static void Main(string[] args)
        {
          
        }

        
 
        
    }
}
