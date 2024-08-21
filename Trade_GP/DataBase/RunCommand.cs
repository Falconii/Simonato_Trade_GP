using Npgsql;
using Trade_GP.Util;
using System;

/*
 * Local
 * Usuario postgres
 * Senha S1m10n4t0SQL
 * Porta 5433
 * 
 * Servidor 192.168.0.251 
 * Usuario postgres
 * Senha   S1m10n4t0SQL - S1m10n4t0ACD
 * Porta   49543
 * 
 * Servidor 192.168.0.161 
 * Usuario postgres
 * Senha   S1m10n4t0SQL  - S1m10n4t0ACD
 * Porta   49777
 * 
 * Usuario: Marcos
 * Senha: M4rc0n1PRJ
 * 
 */

namespace Trade_GP.DataBase
{
    public static class RunCommand
    {

        public static String Banco;
        public static String connectionString;


        public static void SetarBanco(string Local)
        {
            if (Local.ToUpper() == "LOCAL")
            {
                Banco = "BANCO: DB_TRADE_GP LOCAL";
                connectionString = String.Format("Server={0}; Port={1}; User Id={2}; Password={3}; Database={4}; CommandTimeout={5};",
                                                 "localhost", 5433, "postgres", "123456", "db_trade_gp_homologacao", 5000);
            }
            else if (Local.ToUpper() == "1002_")
            {
                Banco = "BANCO: DB_1002 LOCAL";
                connectionString = String.Format("Server={0}; Port={1}; User Id={2}; Password={3}; Database={4}; CommandTimeout={5};",
                                                 "localhost", 5433, "postgres", "123456", "db_1002", 5000);
            }
            else if (Local.ToUpper() == "1001")
            {
                Banco = "BANCO: DB_1001 LOCAL";
                connectionString = String.Format("Server={0}; Port={1}; User Id={2}; Password={3}; Database={4}; CommandTimeout={5};",
                                                 "localhost", 5433, "postgres", "123456", "db_1001", 5000);
            }
            else if (Local.ToUpper() == "1002")
            {
                Banco = "BANCO: DB_1002 LOCAL";
                connectionString = String.Format("Server={0}; Port={1}; User Id={2}; Password={3}; Database={4}; CommandTimeout={5};",
                                                 "localhost", 5433, "postgres", "123456", "db_1002", 5000);
            }
            else if (Local.ToUpper() == "1003")
            {
                Banco = "BANCO: DB_1003 LOCAL";
                connectionString = String.Format("Server={0}; Port={1}; User Id={2}; Password={3}; Database={4}; CommandTimeout={5};",
                                                 "localhost", 5433, "postgres", "123456", "db_1003", 5000);
            }
            else if (Local.ToUpper() == "1004")
            {
                Banco = "BANCO: DB_1004 LOCAL";
                connectionString = String.Format("Server={0}; Port={1}; User Id={2}; Password={3}; Database={4}; CommandTimeout={5};",
                                                 "localhost", 5433, "postgres", "123456", "db_1004", 5000);
            }
            else if (Local.ToUpper() == "PRODUCAO")
            {
                Banco = "BANCO: DB_TRADE_GP_PRODUCAO - 192.168.0.161";
                connectionString = String.Format("Server={0}; Port={1}; User Id={2}; Password={3}; Database={4}; CommandTimeout={5};",
                                                 "192.168.0.161", 49777, "postgres", "S1m10n4t0SQL", "db_trade_gp_producao", 5000);
            }
            else if (Local.ToUpper() == "HOMOLOGACAO")
            {
                Banco = "BANCO: db_trade_gp_homologacao - 192.168.0.161";
                connectionString = String.Format("Server={0}; Port={1}; User Id={2}; Password={3}; Database={4}; CommandTimeout={5};",
                                                 "192.168.0.161", 49777, "postgres", "S1m10n4t0SQL", "db_trade_gp_homologacao", 5000);
            }
            else if (Local.ToUpper() == "TESTE")
            {
                Banco = "BANCO: db_trade_gp_homologacao_teste - 192.168.0.161";
                connectionString = String.Format("Server={0}; Port={1}; User Id={2}; Password={3}; Database={4}; CommandTimeout={5};",
                                                 "192.168.0.161", 49777, "postgres", "S1m10n4t0SQL", "db_trade_gp_homologacao_teste", 5000);
            }
            else
            {
                throw new ArgumentException("Parâmetro Local inválido.");
            }
        }

        public static void CreateCommand(string queryString)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand(queryString, connection);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    connection.Dispose();
                }
                catch (Exception e)
                {
                    throw new ExceptionErroImportacao("E","ERRO DO BANCO", queryString, "", "", 0, e.Message);
                }
            }
        }

    }
}