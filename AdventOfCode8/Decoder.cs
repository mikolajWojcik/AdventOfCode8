using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode8
{
    public class Decoder
    {
        private readonly List<string> _input;
        
        private string[] _numbersArray = new string[10];

        public Decoder(List<string> input)
        {
            _input = input;

            FillDictionary();
        }

        private void FillDictionary()
        {
            _numbersArray[1] = GetOne();
            _numbersArray[4] = GetFour();
            _numbersArray[7] = GetSeven();
            _numbersArray[8] = GetEight();
            _numbersArray[3] = GetThree();
            _numbersArray[9] = GetNine();
            _numbersArray[0] = GetZero();
            _numbersArray[6] = GetSix();
            _numbersArray[5] = GetFive();
            _numbersArray[2] = GetTwo();
        }

        public int ReadOutput(List<string> output)
        {
            return DecodeOutput(output[0]) * 1000 + 
                   DecodeOutput(output[1]) * 100 + 
                   DecodeOutput(output[2]) * 10 + 
                   DecodeOutput(output[3]);
        }

        private int DecodeOutput(string s)
        {
            return s.Length switch
            {
                2 => 1,
                4 => 4,
                3 => 7,
                7 => 8,
                5 => GetStringsForLength(5, s),
                6 => GetStringsForLength(6, s),
                _ => 0
            };
        }

        private int GetStringsForLength(int length, string text)
        {
            for (int i = 0; i < _numbersArray.Length; i++)
            {
                if(_numbersArray[i].Length != length)
                    continue;

                if (HasCharacters(text, _numbersArray[i]))
                    return i;
            }

            return 0;
        }

        private string GetOne() => _input.Single(x => x.Length == 2);
        private string GetFour() => _input.Single(x => x.Length == 4);
        private string GetSeven() => _input.Single(x => x.Length == 3);
        private string GetEight() => _input.Single(x => x.Length == 7);
        private string GetThree() => _input.Where(x => x.Length == 5).Single(x => HasCharacters(_numbersArray[1], x));
        private string GetNine() => _input.Where(x => x.Length == 6).Single(x => HasCharacters(_numbersArray[4], x));
        private string GetZero() => _input.Where(x => x.Length == 6 && HasCharacters(_numbersArray[1], x)).Single(x => !HasCharacters(_numbersArray[9], x));
        private string GetSix() => _input.Where(x => x.Length == 6).Single(x => x != _numbersArray[9] && x != _numbersArray[0]);
        private string GetFive() => _input.Where(x => x.Length == 5).Single(x => HasCharacters(x,_numbersArray[6]));
        private string GetTwo() => _input.Where(x => x.Length == 5).Single(x => x != _numbersArray[3] && x != _numbersArray[5]);
        
        private bool HasCharacters(string text, string test) => text.All(test.Contains);
    }
}