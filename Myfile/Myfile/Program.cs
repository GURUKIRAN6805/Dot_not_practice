using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myfile
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "D:\\practice\\example.txt"; // Specify the file path (current directory)
            string textToAdd = "This is a new line of text.";

            // Append text to the file
            AppendToFile(filePath, textToAdd);

            Console.WriteLine("Text has been appended to the file.");
            Console.ReadLine();
        }

        static void AppendToFile(string filePath, string textToAdd)
        {
            try
            {
                // Append text to an existing file or create the file if it doesn't exist
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine(textToAdd);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
