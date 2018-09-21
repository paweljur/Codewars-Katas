using System;
using System.Text;

public class Kata
{
    public static string Rot13(string input)
    {
        StringBuilder sr = new StringBuilder();
        foreach (char c in input)
        {
            sr.Append(MoveLetterBy13(c));
        }

        return sr.ToString();
    }

    public static char MoveLetterBy13(char c)
    {
        char result = c;
        if (char.IsLetter(c))
        {
            Tuple<char, char> firstAndLastLetter = char.IsLower(c)
                ? new Tuple<char, char>('a', 'z')
                : new Tuple<char, char>('A', 'Z');


            result = c - firstAndLastLetter.Item1 < 13
                ? (char) (firstAndLastLetter.Item2 - (13 - (c - firstAndLastLetter.Item1 + 1)))
                : (char) (c - 13);
        }

        return result;
    }
}