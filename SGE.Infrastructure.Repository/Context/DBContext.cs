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

        public DBContext() { }
        
        private static SQLiteConnection connection;
        private static SQLiteConnection Connection() 
        {
            connection = new SQLiteConnection("Data Source= C:\\Users\\Yuri\\source\\repos\\WebApplicationTest\\BancoDeDados\\BancoSGE.db");
            connection.Open();
            return connection;
        }

        //public static DataTable  ListarProdutos() 
        //{
        //    SQLiteDataAdapter da = null;
        //    DataTable dt = new DataTable();
        //    try {
        //        using (var cmd = Connection().CreateCommand()) {
        //            cmd.CommandText = "SELECT * FROM TBProduto";
        //            da = new SQLiteDataAdapter(cmd.CommandText, Connection());
        //            da.Fill(dt);
        //            Connection().Close();
        //            return dt;
        //        }
        //    } catch (Exception ex) {
        //        throw ex;
        //    }
        //}

        public DataTable Consulta(string sql)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = Connection().CreateCommand())
                {
                    cmd.CommandText = sql;
                    da = new SQLiteDataAdapter(cmd.CommandText, Connection());
                    da.Fill(dt);
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
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = Connection().CreateCommand())
                {
                    cmd.CommandText = sql;
                    da = new SQLiteDataAdapter(cmd.CommandText, Connection());
                    da.Fill(dt);
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
