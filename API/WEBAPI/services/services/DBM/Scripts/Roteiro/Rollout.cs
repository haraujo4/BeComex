using System.Data.SQLite;

namespace DBM.Scripts.Roteiro;

public class Rollout
{
    private string databasePath;
    private string rolloutDirectory;

    public Rollout(string databasePath, string rolloutDirectory)
    {
        this.databasePath = databasePath;
        this.rolloutDirectory = rolloutDirectory;
    }

    public void ExecuteRollout()
    {
        try
        {
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={databasePath};Version=3;"))
            {
                connection.Open();

                string[] sqlFiles = Directory.GetFiles(rolloutDirectory, "*.SQL").OrderBy(x => x).ToArray();
                

                foreach (string sqlFile in sqlFiles)
                {
                    string script = File.ReadAllText(sqlFile);

                    using (SQLiteCommand command = new SQLiteCommand(script, connection))
                    {
                        command.ExecuteNonQuery();
                        Console.WriteLine($"Script {Path.GetFileName(sqlFile)} executado com sucesso.");
                    }
                }

                Console.WriteLine("Rollout concluído com sucesso.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro durante o Rollout: {ex.Message}");
        }
    }
}