using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using MVC_Demo.Models;

namespace MVC_Demo.Class
{
    public class DataBaseHelper
    {
        private SqlConnection conn;
        private SqlCommand comm;
        private List<Table_1> result;

       

        public DataBaseHelper(string ConStr)
        {
            conn = new SqlConnection(ConStr);
        }

        public List<Table_1> GetAllRecord()
        {
            conn.Open();
            string sql = "select * from Table_1";
            comm = new SqlCommand(sql, conn);
            SqlDataReader reader = comm.ExecuteReader();
            result = new List<Table_1>();

            while (reader.Read())
            {
                Table_1 item = new Table_1();
                item.id = reader.GetInt32(reader.GetOrdinal("id"));
                item.name = reader.GetString(reader.GetOrdinal("name"));
                item.sex = reader.GetString(reader.GetOrdinal("sex"));
                result.Add(item);
            }
            reader.Close();
            conn.Close();

            return result;
        }

        public int DeleteRecord(int id)
        {
            conn.Open();
            string sql = "delete from Table_1 where id=" + id;
            comm = new SqlCommand(sql, conn);
            int result = comm.ExecuteNonQuery();
            conn.Close();

            return result;
        }
        public int AddRecord(Table_1 table)
        {

            conn.Open();
            string sql = "insert into Table_1 values('" + table.name + "','" + table.sex + "')";
            comm = new SqlCommand(sql, conn);
            int result = comm.ExecuteNonQuery();

            conn.Close();

            return result;
        }
        public Table_1 SearchRecordByID(int id)
        {
            conn.Open();
            string sql = "select * from Table_1 where(id=" + id + ")";
            comm = new SqlCommand(sql, conn);
            SqlDataReader reader = comm.ExecuteReader();
            Table_1 item = new Table_1();
            if (reader.Read())
            {
                item.id = reader.GetInt32(reader.GetOrdinal("id"));
                item.name = reader.GetString(reader.GetOrdinal("name"));
                item.sex = reader.GetString(reader.GetOrdinal("sex"));
            }
            reader.Close();
            conn.Close();

            return item;
        }
        public int UpdateRecord(Table_1 record)
        {
            string sql = "UPDATE Table_1 SET name = '" + record.name + "',sex='" + record.sex + "' WHERE id = " + record.id + "";

            conn.Open();
            SqlCommand comm = new SqlCommand(sql, conn);
            int result = comm.ExecuteNonQuery();

            conn.Close();
            return result;
        }
    }
}