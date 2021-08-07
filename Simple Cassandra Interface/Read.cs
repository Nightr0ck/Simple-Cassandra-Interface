using System;
using Cassandra;
using static Globals;

public class Read
{
    public static void ReadMenu(ISession session)
    {
        Console.WriteLine("1. Read all rows");
        Console.WriteLine("2. Read rows by name");
        Console.WriteLine("3. Read rows by name and platform");

        switch (GetChoice(3))
        {
            case 1: ReadAll(session); break;
            case 2: ReadByName(session); break;
            case 3: ReadByNameAndPlatform(session); break;
        }
    }

    private static void ReadAll(ISession session)
    {
        RowSet rowset = session.Execute("SELECT * FROM " + KeyspaceName + "." + TableName + ";");
        DisplayRows(rowset);
    }

    private static void ReadByName(ISession session)
    {
        string name = GetName();
        RowSet rowset = session.Execute("SELECT * FROM " + KeyspaceName + "." + TableName +
                                        " WHERE name = '" + name + "';");
        DisplayRows(rowset);
    }

    private static void ReadByNameAndPlatform(ISession session)
    {
        string name = GetName();
        string platform = GetPlatform();
        RowSet rowset = session.Execute("SELECT * FROM " + KeyspaceName + "." + TableName +
                                        " WHERE name = '" + name + "' AND platform = '" + platform + "';");
        DisplayRows(rowset);
    }

    /*
    private static void ReadByNamePlatformAndURL(ISession session)
    {
        string name = GetName();
        string platform = GetPlatform();
        string url = GetURL();
        RowSet rowset = session.Execute("SELECT * FROM " + KeyspaceName + "." + TableName +
                                        " WHERE name = '" + name + "' AND platform = '" + platform + "' AND url = '" + url + "';");
        DisplayRows(rowset);
    }
    */

    private static void DisplayRows(RowSet rowset)
    {
        Console.WriteLine(" {0,-15} | {1,-12} | {2,-22} | {3,-30}", "Name", "Platform", "Time Created", "URL");
        Console.WriteLine("-----------------------------------------------------------------------------------------");
        foreach (Row row in rowset)
        {
            string name = row.GetValue<string>(0);
            string platform = row.GetValue<string>(1);
            DateTime timeCreated = row.GetValue<DateTime>(2);
            string url = row.GetValue<string>(3);
            
            Console.WriteLine(" {0,15} | {1,12} | {2,22} | {3,30}", name, platform, timeCreated, url);
        }
    }
}

