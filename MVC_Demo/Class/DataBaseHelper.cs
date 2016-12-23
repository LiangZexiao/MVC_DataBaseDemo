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
        public string conStr = @"Data Source=DESKTOP-130IQ5N;Initial Catalog=Test;Integrated Security=True";
        public SqlConnection conn;



        public List<Table_1> GetAllRecords()
        {
            //DataTable result = new DataTable();
            List<Table_1> result = new List<Table_1>();
            conn = new SqlConnection(conStr);
            conn.Open();
            string sql = "select * from Table_1";

            SqlCommand comm = new SqlCommand(sql,conn);
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                Table_1 item = new Table_1();
                item.id = reader.GetInt32(reader.GetOrdinal("id"));
                item.name = reader.GetString(reader.GetOrdinal("name"));
                item.sex = reader.GetString(reader.GetOrdinal("sex"));
                result.Add(item);
            }
            reader.Close();

            //SqlDataAdapter ada = new SqlDataAdapter();
            //ada.SelectCommand = comm;
            //ada.Fill(result);

            conn.Close();


            return result;
        }
    }
}