using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata
{
    public static class KataClass
    {
        public static string HamsterMe(string code, string message)
        {
            Dictionary<char, string> hamsterictionary = CreateHamsterEncryptionDictionary(code);
            StringBuilder result = new StringBuilder();

            foreach (char c in message)
                result.Append(hamsterictionary[c]);

            return result.ToString();
        }

        public static Dictionary<char, string> CreateHamsterEncryptionDictionary(string code)
        {
            string letters = "abcdefghijklmnopqrstuvwxyz";
            List<string> encryptionSets = CreateHamsterEncryptionSets(code, letters);
            Dictionary<char, string> hamsterictionary = new Dictionary<char, string>();

            foreach (char letter in letters)
            {
                string correspondingSet = encryptionSets.First(s => s.Contains(letter));
                hamsterictionary.Add(letter, correspondingSet.First() + (correspondingSet.IndexOf(letter) + 1).ToString());
            }

            return hamsterictionary;
        }

        private static List<string> CreateHamsterEncryptionSets(string code, string letters)
        {

            List<string> encryptionSets = new List<string>();
            List<char> keys = code.Distinct().OrderBy(c => c).ToList();
            int keyLetterIndex = 0;

            for (int i = 1; i < keys.Count; i++)
            {
                int nextKeyLetterIndex = letters.IndexOf(keys[i]);
                keyLetterIndex = letters.IndexOf(keys[i - 1]);
                encryptionSets.Add(letters.Substring(keyLetterIndex, nextKeyLetterIndex - keyLetterIndex));
            }

            keyLetterIndex = letters.IndexOf(keys.Last());
            encryptionSets.Add(letters.Substring(keyLetterIndex, letters.Last() - keys.Last() + 1) + letters.Substring(0, keys.First() - letters.First()));

            return encryptionSets;
        }
    }
}