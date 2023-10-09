using System;
using System.Data.SQLite;
using DBM.Scripts.Roteiro;
class Program
{
    static void Main(string[] args)
    {
        string databasePath = "../../../DATABASE/database.db";
        string rolloutDirectory = "../../../Scripts/Rollout";
        string rollbackDirectory = "../../../Scripts/Rollback";

        if (!File.Exists(databasePath))
        {
            SQLiteConnection.CreateFile(databasePath);
            Console.WriteLine("Banco de dados SQLite criado com sucesso.");
        }

        Rollout rollout = new Rollout(databasePath, rolloutDirectory);
        Rollback rollback = new Rollback(databasePath, rollbackDirectory);

        while (true)
        {
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1 - Executar Rollout");
            Console.WriteLine("2 - Executar Rollback");
            Console.WriteLine("3 - Sair");
            Console.Write("Opção: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    rollout.ExecuteRollout();
                    break;

                case "2":
                    rollback.ExecuteRollback();
                    break;

                case "3":
                    Console.WriteLine("Saindo...");
                    return; // Sai do programa

                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }
}