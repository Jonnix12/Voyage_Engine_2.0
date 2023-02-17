
// namespace Voyage_Engine.Console
// {
//     public static class Debug
//     {
//         public static void Log(object message,bool printStackTrace = false)
//         {
//             if (printStackTrace)
//             {
//                 System.Diagnostics.StackTrace t = new System.Diagnostics.StackTrace();
//                 System.Console.WriteLine($"[{DateTime.Now}] Log: {message}\nStackTrace:\n[\n{t}\n]\n"); 
//             }
//             else
//                 System.Console.WriteLine($"[{DateTime.Now}] Log: {message}\n");
//         }
//         
//         public static void LogWarning(object message)
//         {
//             System.Console.ForegroundColor = ConsoleColor.Yellow;
//             System.Console.WriteLine($"[{DateTime.Now}] LogWarning: {message}\n"); 
//             System.Console.ResetColor();
//         }
//         
//         public static void LogError(object message)
//         {
//             System.Console.ForegroundColor = ConsoleColor.Red;
//             System.Console.WriteLine($"[{DateTime.Now}] LogError: {message}\n");
//             System.Console.ResetColor();
//         }
//     }
// }