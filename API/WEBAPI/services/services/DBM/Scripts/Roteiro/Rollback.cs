using System.Data.SQLite;

namespace DBM.Scripts.Roteiro;

public class Rollback
{
    private string databasePath;
    private string rollbackDirectory;

    public Rollback(string databasePath, string rollbackDirectory)
    {
        this.databasePath = databasePath;
        this.rollbackDirectory = rollbackDirectory;
    }

    public void ExecuteRollback()
    {
        try
        {
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={databasePath};Version=3;"))
            {
                connection.Open();

                // Listar todos os arquivos SQL na pasta Rollback
                string[] sqlFiles = Directory.GetFiles(rollbackDirectory, "*.SQL");

                foreach (string sqlFile in sqlFiles)
                {
                    string script = File.ReadAllText(sqlFile);

                    using (SQLiteCommand command = new SQLiteCommand(script, connection))
                    {
                        command.ExecuteNonQuery();
                        Console.WriteLine($"Script {Path.GetFileName(sqlFile)} executado com sucesso.");
                    }
                }

                Console.WriteLine("Rollback concluído com sucesso.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro durante o Rollback: {ex.Message}");
        }
    }
}
