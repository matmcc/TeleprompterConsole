using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleprompterConsole
{
    class Program
    {
        static IEnumerable<string> ReadFrom(string file)
        {
            string line;
            using (var reader = File.OpenText(file))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    // yield return line;
                    var words = line.Split(' ');
                    foreach (var word in words)
                    { yield return word + " "; }
                    yield return Environment.NewLine;
                }
            }
        }

        static void Main(string[] args)
        {
            var lines = ReadFrom("sampleQuotes.txt");
            foreach (var line in lines)
            {
                // Console.WriteLine(line);
                Console.Write(line);
                if (!string.IsNullOrWhiteSpace(line))
                {
                    var pause = Task.Delay(200);
                    pause.Wait();
                }
            }
        }
    }
}
