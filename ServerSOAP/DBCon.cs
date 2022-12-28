using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ServerSOAP
{
    public class DBCon
    {
        public static DBCon instance = null;
        public SqlConnection cnx;
        public SqlCommand cmd;
        public DataTable dt;

        public DBCon()
        {
            cnx = new SqlConnection("Data Source=LDR-AA204735\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            cmd = new SqlCommand("", cnx);
            dt = new DataTable();

        }


        public static DBCon GetInstance()
        {
            if (instance == null)
            {
                instance = new DBCon();
            }

            return instance;
        }

        public DataTable ExecuteDataTable(string sqlStatement)
        {
            GetInstance();
            cnx.Open();
            cmd.CommandText = sqlStatement;
            dt.Clear();
            dt.Load(cmd.ExecuteReader());
            cnx.Close();

            return dt.Copy();
        }

        public int ExecuteNonQuery(string sqlStatement) 
        { 
        
            cnx.Open();
            cmd.CommandText = sqlStatement;
            int result = cmd.ExecuteNonQuery();
            cnx.Close();

            return result;
        }

        public object ExecuteScalar(string sqlStatment)
        {
            cnx.Open();
            cmd.CommandText = sqlStatment;
            object obj = cmd.ExecuteScalar();
            cnx.Close();

            return obj;
        }
      
    }
}