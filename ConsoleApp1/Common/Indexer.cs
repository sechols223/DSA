using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Common;
public class Indexer
{

    public static int GetCharValue(char c)
    {

        if (c < 'a' || c > 'z')
        {
            return -1;
        }
        int value = c - 'a';
        return value;
    }

    public static int GetStringValue(string str)
    {
        int letter1 = GetCharValue(str[0]) *  (int)Math.Pow(26, 2);
        int letter2 = GetCharValue(str[1]) * (int)Math.Pow(26, 1);
        int letter3 = GetCharValue(str[2]) * (int)Math.Pow(26, 0);

        int value = letter1 + letter2 + letter3;
           
        return value;
    }
}
