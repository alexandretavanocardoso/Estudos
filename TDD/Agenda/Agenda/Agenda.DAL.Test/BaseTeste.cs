using NUnit.Framework;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace Agenda.DAL.Test
{
    [TestFixture]
    public class BaseTeste
    {
        private string _script;
        private string _con;
        private string _catalogTeste;

        public BaseTeste()
        {
            _script = @"Bd_Teste_Create.sql";
            _con = ConfigurationManager.ConnectionStrings["conSetUpTeste"].ConnectionString;
            _catalogTeste = ConfigurationManager.ConnectionStrings["conSetUpTeste"].ProviderName;
        }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            CreateDbTeste();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            DeleteDbTeste();
        }

        private void CreateDbTeste()
        {
            using (var con = new SqlConnection(_con))
            {
               con.Open();
                var scriptSql =
                     File
                     .ReadAllText($@"{AppDomain.CurrentDomain.SetupInformation.ApplicationBase}\{_script}")
                     .Replace("${DefaultDataPath}", $@"{AppDomain.CurrentDomain.SetupInformation.ApplicationBase}")
                     .Replace("${DefaultLogPath}", $@"{AppDomain.CurrentDomain.SetupInformation.ApplicationBase}")
                     .Replace("${DefaultFilePrefix}", _catalogTeste)
                     .Replace("${DatabaseName}", _catalogTeste)
                     .Replace("WITH (DATA_COMPRESSION = PAGE)", string.Empty)
                     .Replace("SET NOEXEC ON", string.Empty)
                     .Replace("GO\r\n", "|");
                ExecuteScriptSql(con, scriptSql); 
            };
        }

        private void ExecuteScriptSql(SqlConnection con, string scriptSql)
        {
            using (var cmd = con.CreateCommand())
            {
                foreach (var sql in scriptSql.Split('|'))
                {
                    cmd.CommandText = sql;
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(sql);
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        private void DeleteDbTeste() 
        {
            using (var con = new SqlConnection(_con))
            {
                con.Open();
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = $@"USE [master];
                                         DECLARE @KILL VARCHAR(100)
                                         SELECT @KILL = @KILL + 'kill ' + CONVERT(varchar(5), session_id) + ';'
                                         FROM sys.dm_exec_sessions
                                         WHERE database_id = db_id('{_catalogTeste}')
                                         EXEC(@KILL);";

                    cmd.ExecuteNonQuery();
                    cmd.CommandText = $"DROP DATABASE {_catalogTeste}";
                    cmd.ExecuteNonQuery();
                }
            }    
        }
    }
}
