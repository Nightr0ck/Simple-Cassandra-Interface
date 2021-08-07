using System.Text.RegularExpressions;
using System;
public static class Globals
{
    public const string KeyspaceName = "accounts";
    public const string TableName = "social_media";
    public static readonly string[] Platforms = new string[] { "Facebook", "LinkedIn", "Reddit", "YouTube" };
    public static readonly Regex IdentifierNamesRegex = new Regex("^[a-zA-Z]{1}[a-zA-Z0-9_]*$");
    public static readonly string[] DataTypes = new string[] { "int", "double", "decimal", "text", "boolean" };

    public static int GetChoice(int highest)
    {
        int choice = -1;

        while (choice == -1)
        {
            Console.Write("> ");
            try
            {
                choice = Convert.ToInt32(Console.ReadLine());

                if (choice < 1 || choice > highest)
                {
                    choice = -1;
                    Console.WriteLine("Invalid input");
                }
            }
            catch
            {
                Console.WriteLine("Invalid input");
                Console.WriteLine();
            }
        }

        return choice;
    }

    public static string GetName()
    {
        Console.WriteLine("Enter person's name");
        Console.Write("> ");
        string name = Console.ReadLine();
        Console.WriteLine();
        return name;
    }

    public static string GetPlatform()
    {
        Console.WriteLine("Select platform");
        for (int i = 0; i < Platforms.Length; i++)
        {
            Console.WriteLine("{0}. {1}", i + 1, Platforms[i]);
        }
        string platform = Platforms[GetChoice(Platforms.Length) - 1];
        Console.WriteLine();
        return platform;
    }

    public static string GetURL()
    {
        Console.WriteLine("Enter profile URL");
        Console.Write("> ");
        string url = Console.ReadLine();
        Console.WriteLine();
        return url;
    }

}
