using Cassandra;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Cluster cluster = Cluster.Builder().AddContactPoints("127.0.0.1").Build();
        ISession session = cluster.Connect();
        session.CreateKeyspaceIfNotExists("store");
        session.Execute("CREATE TABLE IF NOT EXISTS store.shopping_cart" +
                        "(userid text PRIMARY KEY," +
                        "item_count int," +
                        "last_update_timestamp timestamp" +
                        ");"
                       );

        session.Execute("INSERT INTO store.shopping_cart" +
                        "(userid, item_count, last_update_timestamp)" +
                        "VALUES('9876', 2, toTimeStamp(now()));"
                       );

        session.Execute("INSERT INTO store.shopping_cart" +
                        "(userid, item_count, last_update_timestamp)" +
                        "VALUES('1234', 5, toTimeStamp(now()));"
                       );
        
        RowSet rs = session.Execute("SELECT * FROM store.shopping_cart");

        foreach (Row row in rs)
        {
            string userID = row.GetValue<string>(0);
            int itemCount = row.GetValue<int>(1);

            Console.WriteLine(userID);
            Console.WriteLine(itemCount);
        }
    }
}