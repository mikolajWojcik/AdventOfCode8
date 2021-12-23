using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode8
{
    public class TextProcessor
    {
        private List<int> _numbers = new List<int>();

        public void ReadLine(string line)
        {
            if (!line.Contains("|"))
                return;
            
            var parts = line.Split(" | ");
            var input = parts[0].Split(" ").ToList();
            var output = parts[1].Split(" ").ToList();

            var decoder = new Decoder(input);
            var decodedNumber = decoder.ReadOutput(output);

            _numbers.Add(decodedNumber);
        }

        public int CountResult() => _numbers.Sum();
    }
}