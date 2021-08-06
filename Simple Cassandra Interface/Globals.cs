using System.Text.RegularExpressions;

public static class Globals
{
    public const string KeyspaceName = "test_keyspace";
    public static readonly Regex IdentifierNamesRegex = new Regex("^[a-zA-Z]{1}[a-zA-Z0-9_]*$");
    public static readonly string[] DataTypes = new string[] { "int", "double", "decimal", "text", "boolean" };
    
}
