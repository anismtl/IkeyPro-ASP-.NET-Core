using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace IkeyPro.ADO
{
    public class DataManager
    {

        private static SqlConnection Connection { get; set; }

        public static SqlConnection Get()
        {
            string cs = "Data Source=aniss.ca;Initial Catalog=ikeypro;User ID=anis;Password=SAM123";
            if (Connection == null)
            {
                Connection = new SqlConnection(cs);
            }

            return Connection;
        }
    }

}
