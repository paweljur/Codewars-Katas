namespace Kata
{
    public class KataClass
    {
        public static char FindMissingLetter(char[] array)
        {
            for (int i = 1; i < array.Length; i++)
                if (array[i] - array[i - 1] > 1)
                    return (char)(array[i] - 1);
            return ' ';
        }
    }
}