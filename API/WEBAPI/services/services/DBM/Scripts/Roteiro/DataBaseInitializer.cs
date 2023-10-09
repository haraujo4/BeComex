using System.Data.SQLite;

namespace DBM.Scripts.Roteiro;

public class DatabaseInitializer
{
    private string databasePath;

    public DatabaseInitializer(string databasePath)
    {
        this.databasePath = databasePath;
    }

    public void InitializeDatabase()
    {
        if (!File.Exists(databasePath))
        {
            SQLiteConnection.CreateFile(databasePath);
            Console.WriteLine("Banco de dados criado com sucesso.");
        }
    }
}