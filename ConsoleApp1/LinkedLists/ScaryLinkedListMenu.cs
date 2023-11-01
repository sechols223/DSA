using DSA.Common;
using Console = System.Console;

namespace DSA.LinkedLists;

public class ScaryLinkedListMenu
{

    private LinkedList<string> list = new();
    
    public void Start()
    {
        CreateList();
        PrintOptions();
    }

    private void CreateList()
    {
        string path = "Data/names.txt";
        FileReader fileReader = new(path);

        string[] lines = fileReader.ReadLines();

        foreach(string line in lines )
        {
            list.InsertOrdered(line);
        }
    }
    
    private void PrintOptions()
    {
        Console.WriteLine("-----Options-----");
        Console.WriteLine("1.) Display the list");
        Console.WriteLine("2.) Get the length of the list");
        Console.WriteLine("3.) Get the length of a section of the list.");
        Console.WriteLine("4.) Print a section of the list");
        Console.WriteLine();
        Console.Write("Please select your choice: ");

        if (int.TryParse(Console.In.ReadLine(), out int option))
        {
            SelectOption(option);
        }
    }

    private void SelectOption(int option)
    {
        switch (option)
        {
            case 1: 
                DisplayList();
                break;
            case 2:
                GetListLength();
                break;
            case 3:
                GetSectionLength();
                break;
            case 4:
                DisplaySection();
                break;
        }
        PrintOptions();
    }

    private void DisplayList()
    {
        Console.WriteLine("-----List-----");
        list.PrintList();
        Console.WriteLine("\n--------------");

    }

    private void GetListLength()
    {
        Console.WriteLine($"List Length: {list.Length}");
    }

    private void DisplaySection()
    {
        Console.WriteLine("What Section would you like to display?");
        char section = Console.In.ReadLine()![0];
        
        Console.WriteLine("-----Section-----");
        list.PrintSection(section);
        Console.WriteLine("\n--------------");
    }

    private void GetSectionLength()
    {
        Console.WriteLine("What Section's length would you like to display?");
        char section = Console.In.ReadLine()![0];
        if (char.IsLetter(section))
        {
            Console.WriteLine($"Length: {list.GetSectionLength(section)}");
        }
        else
        {
            Console.WriteLine("Unable to read section. Please try again");
            GetSectionLength();
        }
    }
}