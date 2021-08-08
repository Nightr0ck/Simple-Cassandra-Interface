using System;
using Cassandra;
using static Globals;

public class Program
{
    public static void Main(string[] args)
    {
        Cluster cluster = Cluster.Builder().AddContactPoints("127.0.0.1").Build();
        ISession session = cluster.Connect(KeyspaceName);

        int choice = 0;
        
        while (choice != 5)
        {
            Console.WriteLine("1. Create");
            Console.WriteLine("2. Read");
            Console.WriteLine("3. Update");
            Console.WriteLine("4. Delete");
            Console.WriteLine("5. Exit");
            
            choice = GetChoice(5);
            switch (choice)
            {
                case 1: Create.InsertRow(session); break;
                case 2: Read.ReadMenu(session); break;
                case 3: Update.UpdateURL(session); break;
                case 4: Delete.DeleteRow(session); break;
            }
        }
    }
}