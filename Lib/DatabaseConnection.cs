namespace Lib;

public sealed class DatabaseConnection
{
    private DatabaseConnection()
    {
    }

    public static DatabaseConnection Create()
    {
        return new DatabaseConnection();
    }
}