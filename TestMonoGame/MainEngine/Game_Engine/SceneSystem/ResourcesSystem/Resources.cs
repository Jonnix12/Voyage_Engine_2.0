using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;

namespace Voyage_Engine.Game_Engine.ResourcesSystem;

public sealed class Resources //not implemented
{
    private static string ResourcesPath;
    private static FileStream _fileStream;
    private static readonly BinaryFormatter _formatter = new();

    public Resources()
    {
        var cache = Application.StartupPath;

        var stringBuilder = new StringBuilder(cache);

        stringBuilder = stringBuilder.Remove(cache.Length - 10, 10);
        stringBuilder.Append("/Resources/");
        cache = stringBuilder.ToString();
        ResourcesPath = cache;
    }

    public static T Load<T>(string path)
    {
        _fileStream = new FileStream(ResourcesPath + path, FileMode.Open, FileAccess.Read);

        return (T) _formatter.Deserialize(_fileStream);
    }

    public static List<T> LoadAll<T>(string path)
    {
        var output = new List<T>();

        _fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);

        return (List<T>) _formatter.Deserialize(_fileStream);
    }

    public static Image LoadImage(string imagePath)
    {
        return Image.FromFile(ResourcesPath + imagePath);
    }
}