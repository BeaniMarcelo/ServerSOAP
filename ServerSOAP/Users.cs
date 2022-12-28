using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ServerSOAP
{
    public class Users
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string CardNumber { get; set; }

        public bool Save()
        {
            return true;
        }
    }
}