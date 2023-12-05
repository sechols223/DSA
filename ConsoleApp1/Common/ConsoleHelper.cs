using System.Text;

namespace DSA.Common;

public class ConsoleHelper
{
    private static string _header = string.Empty;

    public static void SetHeader(string header)
    {
        _header = header;
    }
    
    public static void PrintDivider(char seperator = '#', int length = 15, ConsoleColor color = ConsoleColor.Yellow)
    {
        Console.ForegroundColor = color;
        string divider = GenerateDivider(seperator, length);
        if (!string.IsNullOrEmpty(_header))
        {
            StringBuilder stringBuilder = new();
            
            stringBuilder.Append(divider);
            stringBuilder.AppendLine();
            stringBuilder.Append($"# {_header}");
            stringBuilder.AppendLine();
            stringBuilder.Append(divider);
            
            Console.WriteLine(stringBuilder);
        }
        else
        {
            Console.WriteLine(divider);
        }
        Console.ResetColor();
        _header = string.Empty;
    }

    private static string GenerateDivider(char seperator, int length)
    {
        StringBuilder sb = new();
        for (int i = 0; i < length; i++)
        {
            sb.Append(seperator);
        }

        return sb.ToString();
    }
}