using DSA.Common;

namespace DSA.HashTables;

public class HashTable
{

   private string?[] table = Array.Empty<string>();
   private readonly string[] data;
   private int collisions;
   public HashTable(string[] data)
   {
       int length = 500;
       this.data = data;
       ValidateData();
       InitTable(length);
       CreateTable();
   }

   public void PrintTable()
   {
       ConsoleHelper.SetHeader("Hash Table");
       ConsoleHelper.PrintDivider();
       for (int i = 0; i < table.Length; i++)
       {
           string? str = table[i];
           if (str != null)
           {
               Console.WriteLine(str);

           }
       }
       Console.WriteLine();
       Console.ForegroundColor = ConsoleColor.Cyan;
       Console.WriteLine($"Collisions: {collisions}");
       ConsoleHelper.PrintDivider();

   }
   
   private void InitTable(int length)
   {
       table = new string?[length];
       for (int i = 0; i < length; i++)
       {
           table[i] = null;
       }
   }
   
   private void CreateTable()
   {
       collisions = 0;
       for (int i = 0; i < data.Length; i++)
       {
           Add(data[i]);
       }
   }

   private void Add(string str)
   {
       int hash = GetHash(str);
       if (table[hash] != null)
       {
           collisions++;
           FindPlace(hash, str);
       }
       else
       {
           table[hash] = str;
       }
   }

   private int GetHash(string str)
   {
       int hash = 17;
       int n = 31;
       for (int i = 0; i < 3; i++)
       {
           char c = str[i];
           int ascii = c - 'a';
           hash = hash * n + ascii;
       }

       return hash % table.Length;
   }

   private void FindPlace(int hash, string str)
   {
       int start = hash;
       hash = (hash + 1) % table.Length;
       while (hash != start)
       {
           if (table[hash] == null)
           {
               table[hash] = str;
               return;
           }
           hash = (hash + 1) % table.Length;
       }
       Rehash();
       Add(str);
   }

   private void Rehash()
   {
       string?[] prev = table;
       int length = table.Length * 2;
       InitTable(length);

       for (int i = 0; i < table.Length; i++)
       {
           if (prev[i] != null)
           {
               table[i] = prev[i];
           }
       }
   }
   
   private void ValidateData()
   {
       foreach (string str in data)
       {
           if (str.Length < 3)
           {
               throw new InvalidDataException("All strings in the data set must have a length of at least 3.");
           }
       } 
   }
}