Console.WriteLine("d");
while(true){}

public static class Debug
{
    public static void Log(object message,bool printStackTrace = false)
    {
        if (printStackTrace)
        {
            System.Diagnostics.StackTrace t = new System.Diagnostics.StackTrace();
            Console.WriteLine($"[{DateTime.Now}] Log: {message}\nStackTrace:\n[\n{t}\n]\n"); 
        }
        else
            Console.WriteLine($"[{DateTime.Now}] Log: {message}\n");
    }
        
    public static void LogWarning(object message)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"[{DateTime.Now}] LogWarning: {message}\n"); 
        Console.ResetColor();
    }
        
    public static void LogError(object message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"[{DateTime.Now}] LogError: {message}\n");
        Console.ResetColor();
    }
}