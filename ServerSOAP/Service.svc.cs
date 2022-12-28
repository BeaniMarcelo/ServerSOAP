using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace ServerSOAP
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service.svc or Service.svc.cs at the Solution Explorer and start debugging.
    public class Service : IService
    {


        public List<Users> ListAll()
        {
            try
            {
                DBCon con = new DBCon();
                List<Users> list = new List<Users>();
                var dt = con.ExecuteDataTable("USE [Users] select * from [dbo].[InfoUser]");
                foreach (var user in dt.Rows)
                {
                    //list.Add(dt.TableNewRow.);
                }
                return list;

            }
            catch
            {
                return null;
            }
         

        }

        public bool Save(int ID, string name, string CardNumber)
        {

            try
            {
                DBCon con = new DBCon();

                con.ExecuteNonQuery("USE [Users] INSERT INTO [dbo].[InfoUser] ([ID] ,[Name] ,[CadNumber]) VALUES" + $"({ID}, '{name}', {CardNumber})");
                return true;

            }
            catch
            {
                return false;
            }

        }

    }
}
