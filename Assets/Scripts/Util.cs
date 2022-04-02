using System;
public static class Util
{
    // Formats a float value representing time to MM:SS:ss
    public static string formatTime(float baseTime){
        int minutes = (int)Math.Floor(baseTime/60);
        int seconds = (int)(baseTime-minutes);
        int millis = (int)((baseTime-minutes-seconds)*100);
        string time = String.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, millis);
        return time;
    }
}
