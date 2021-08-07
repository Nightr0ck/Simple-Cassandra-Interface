using System;
using System.Collections.Generic;
using Cassandra;
using static Globals;

public class Update
{
    public static void UpdateURL(ISession session)
    {
        string name = GetName();
        string platform = GetPlatform();
        RowSet rowset = session.Execute("SELECT * FROM " + KeyspaceName + "." + TableName +
                                        " WHERE name = '" + name + "' AND platform = '" + platform + "';");

        if (rowset.IsExhausted())
        {
            Console.WriteLine("No rows found to update");
            return;
        }

        Console.WriteLine("Choose a row to update:");
        List<Row> rows = new List<Row>();
        IEnumerator<Row> enumerator = rowset.GetEnumerator();
        while (enumerator.MoveNext())
        {
            Row r = enumerator.Current;
            rows.Add(r);
            Console.WriteLine("{0}. {1,15} | {2,12} | {3,22} | {4,30}", rows.Count, name, platform, r.GetValue<DateTime>(2), r.GetValue<string>(3));
        }
        Row rowToUpdate = rows[GetChoice(rows.Count) - 1];

        Console.WriteLine("New URL:");
        string url = GetURL();

        session.Execute("UPDATE " + KeyspaceName + "." + TableName +
                        " SET url='" + url + "'" +
                         " WHERE name = '" + name + "' AND platform = '" + platform + "' AND time_created='" + rowToUpdate.GetValue<DateTimeOffset>(2).ToString("O") + "';");
    }
}
