using IkeyPro.ADO;
using IkeyPro.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace IkeyPro.DAO
{
    public class EditionDAO
    {
        public static List<Edition> GetListeEditeur()
        {
            SqlConnection sqlConnection = DataManager.Get();
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "GetListEdition",
                CommandType = System.Data.CommandType.StoredProcedure,
                Connection = sqlConnection
            };

            sqlConnection.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            List<Edition> result = new List<Edition>();

            while (reader.Read())
            {
                Edition item = new Edition()
                {
                    Id_Edition = reader["ID_EDITION"].ToString(),
                    Edition_Designation = reader["EDITION"].ToString()
                };
                result.Add(item);
            }

            sqlConnection.Close();
            return result;

            /* 
            CREATE PROCEDURE [dbo].[GetListEdition]
            @id int
            AS
                  SELECT ID_EDITION, EDITION FROM EDITION
                  ORDER BY NBPRODUIT DESC
                  FETCH FIRST 6 ROWS ONLY
            RETURN 0;
            */
        }





    }
}
