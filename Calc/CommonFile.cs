using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Calc
{
    public class CommonFile
    {
        private static IEnumerable<string> ReadAsLines(string filename)
        {
            using (StreamReader reader = new StreamReader(filename))
                while (!reader.EndOfStream)
                    yield return reader.ReadLine();
        }

        public static void ReadData(string filename)
        {
            var reader = ReadAsLines(filename).ToArray();
            foreach (var row in reader)
            {
                // write the row to the output
            }
        }
    }
}
