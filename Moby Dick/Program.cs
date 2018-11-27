using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Moby_Dick
{
    public class Program
    {
        // Global Declarations
        public static Dictionary<string,int> WordList;

        public static void Main(string[] args)
        {
            string contents = "";
            string BookURL = "http://www.gutenberg.org/files/2701/2701-0.txt";
            using (var wc = new System.Net.WebClient())
                contents = wc.DownloadString(BookURL);

            ClearString clearString = new ClearString();
            contents = clearString.Method(contents);

            WordList = new Dictionary<string, int>();

            WordCounter(contents);
            WriteToXML("ege");

            Console.WriteLine(contents);
        }

        public static void WriteToXML(string xmlDocName) // Write our word pair list to xml
        {
            XmlWriter xmlWriter = XmlWriter.Create(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+"\\"+xmlDocName+".xml", null);
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("words");

            foreach (KeyValuePair<string, int> entry in WordList)
            {
                xmlWriter.WriteStartElement("word");
                xmlWriter.WriteAttributeString("count", entry.Value + "");
                xmlWriter.WriteAttributeString("text", entry.Key);
                xmlWriter.WriteEndElement();
            }
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
        }

        public static void WordCounter(string input) // Create Word Pair List
        {
            string[] words = input.Split(' ');

            foreach (string word in words)
            {
                if (word.Length > 1) // For avoid brackets or any other pharantesis 
                {
                    if (WordList.ContainsKey(word.ToLower()))
                    {
                        WordList[word.ToLower()] = WordList[word.ToLower()] + 1;
                    }
                    else
                    {
                        WordList.Add(word.ToLower(), 1);
                    }
                }
            }
        }
        
      
    }
}
