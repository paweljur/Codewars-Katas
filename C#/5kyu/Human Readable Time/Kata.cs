public static class Kata
{
    //v1
    // public static string GetReadableTime(int seconds)
    // {
    //     int remaindSeconds = seconds;
    //     int secondsPerHour = 60 * 60;
    //     int secondsPerMinute = 60;

    //     int hours = remaindSeconds / secondsPerHour;
    //     remaindSeconds = remaindSeconds % secondsPerHour;

    //     int minutes = remaindSeconds / secondsPerMinute;
    //     remaindSeconds = remaindSeconds % secondsPerMinute;

    //     return
    //         $"{hours.ToString("D" + 2)}:{minutes.ToString("D" + 2)}:{remaindSeconds.ToString("D" + 2)}";
    // }

    //v2
    public static string GetReadableTime(int seconds)
    {
        return $"{(seconds / 3600):00}:{((seconds % 3600) / 60):00}:{(seconds % 60):00}";
    }
}