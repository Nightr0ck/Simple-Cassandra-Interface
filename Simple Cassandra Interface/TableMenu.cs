using System;
using System.Collections;
using Cassandra;
using static Globals;

public class TableMenu
{
    public static ArrayList tables = new ArrayList();
    public static void Menu(ISession session)
    {
        while (true)
        {
            for (int i = 0; i < tables.Count; i++)
            {
                Console.WriteLine((i + 1).ToString() + ". " + tables[i]);
            }

            Console.WriteLine();
            Console.WriteLine("0. Create new table");
            Console.WriteLine();

            int choice = GetChoice(tables.Count);
            if (choice == 0)
            {
                string statement = "CREATE TABLE IF NOT EXISTS " + KeyspaceName + ".";

                Console.WriteLine("Enter table name");
                string tableName = GetIdentifierName();
                statement += tableName;

                Console.WriteLine("Choose datatyles");
                statement += GetDataTypes();

                session.Execute(statement);
                tables.Add(tableName);
                Console.WriteLine();
                Console.WriteLine("Table " + KeyspaceName + "." + tableName + " successfully created");
                Console.WriteLine();
            }
            else
            {
                CRUDMenu.Menu(tables[choice - 1].ToString());
            }
        }
        


    }
    private static int GetChoice(int highest)
    {
        int choice = -1;

        while (choice == -1)
        {
            Console.Write("> ");
            try
            {
                choice = Convert.ToInt32(Console.ReadLine());

                if (choice < 0 || choice > highest)
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


    public static string GetIdentifierName()
    {
        string idenfitierName = null;

        while (idenfitierName == null)
        {
            Console.Write("> ");
            idenfitierName = Console.ReadLine().Trim();

            if (!IdentifierNamesRegex.IsMatch(idenfitierName))
            {
                idenfitierName = null;
                Console.WriteLine("Invalid table name");
            }
        }

        return idenfitierName.ToLower();
    }

    public static string GetDataTypes()
    {
        string dataTypes = "(";
        bool primaryKey = false;

        while (true)
        {
            for(int i = 0; i < DataTypes.Length; i++)
            {
                Console.WriteLine((i + 1).ToString() + ". " + DataTypes[i]);
            }
            Console.WriteLine("0. Done");

            int choice = GetChoice(DataTypes.Length);
            if (choice == 0)
            {
                if (dataTypes == "(")
                {
                    Console.WriteLine("Select at least 1 datatype");
                }
                else if (!primaryKey)
                {
                    Console.WriteLine("There are no primary keys");
                }
                else
                {
                    return dataTypes.Remove(dataTypes.Length - 1) + ");";
                }
            }
            else
            {
                Console.WriteLine("Column name?");
                dataTypes += GetIdentifierName() + " " + DataTypes[choice - 1];

                Console.WriteLine("Is primary key?");
                Console.WriteLine("1. Yes");
                Console.WriteLine("2. No");

                if (GetChoice(2) == 1)
                {
                    dataTypes += " PRIMARY KEY,";
                    primaryKey = true;
                }
                else
                {
                    dataTypes += ",";
                }

            }
        }
    }
}
