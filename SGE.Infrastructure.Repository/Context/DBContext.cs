using Microsoft.EntityFrameworkCore;
using SGE.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;
using System.Threading.Tasks;

namespace SGE.Infrastructure.Repository.Context
{
    public class DBContext 
    {
        SQLiteDataAdapter _da = null;
        public DBContext() { }
        
        private static SQLiteConnection connection;
        private static SQLiteConnection Connection() 
        {
            connection = new SQLiteConnection("Data Source=..\\BancoDeDados\\BancoSGE.db");
            connection.Open();
            return connection;
        }

        public DataTable Consulta(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = Connection().CreateCommand())
                {
                    cmd.CommandText = sql;
                    _da = new SQLiteDataAdapter(cmd.CommandText, Connection());
                    _da.Fill(dt);
                    Connection().Close();
                    return dt;
                }
            }
            catch (Exception ex)
            {

                Connection().Close();
                throw ex;
            }
        }
        public void Alterar(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = Connection().CreateCommand())
                {
                    cmd.CommandText = sql;
                    _da = new SQLiteDataAdapter(cmd.CommandText, Connection());
                    _da.Fill(dt);
                    Connection().Close();
                }
            }
            catch (Exception ex)
            {

                Connection().Close();
                throw ex;
            }
        }

    }
}
