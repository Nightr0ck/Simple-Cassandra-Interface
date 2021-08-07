using System;
using Cassandra;
using static Globals;

public class Create
{
    public static void InsertRow(ISession session)
    {
        string name, platform, url;

        name = GetName();
        platform = GetPlatform();
        url = GetURL();

        session.Execute("INSERT INTO " + KeyspaceName + "." + TableName +
                        "(name, platform, url, time_created)" + 
                        String.Format("VALUES ('{0}', '{1}', '{2}', toTimeStamp(now()));", name, platform, url));
    }
}
