using System;

public static class Debug
{
    public static void Log(object message,bool printStackTrace = false)
    {
        if (printStackTrace)
        {
            System.Diagnostics.StackTrace t = new System.Diagnostics.StackTrace();
            System.Diagnostics.Debug.WriteLine($"[{DateTime.Now}] Log: {message}\nStackTrace:\n[\n{t}\n]\n"); 
        }
        else
            System.Diagnostics.Debug.WriteLine($"[{DateTime.Now}] Log: {message}\n");
    }
        
    public static void LogWarning(object message)
    {
        //Console.ForegroundColor = ConsoleColor.Yellow;
        System.Diagnostics.Debug.WriteLine($"[{DateTime.Now}] LogWarning: {message}\n"); 
        //Console.ResetColor();
    }
        
    public static void LogError(object message)
    {
        //Console.ForegroundColor = ConsoleColor.Red;
        System.Diagnostics.Debug.WriteLine($"[{DateTime.Now}] LogError: {message}\n");
        //Console.ResetColor();
    }
}