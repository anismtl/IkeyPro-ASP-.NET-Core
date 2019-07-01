using IkeyPro.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace IkeyPro.ADO
{
    public class EditeurDAO
    {
        public static List<Editeur> GetListeEditeur()
        {
            SqlConnection sqlConnection = DataManager.Get();
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "GetListEditeur",
                CommandType = System.Data.CommandType.StoredProcedure,
                Connection = sqlConnection
            };

            sqlConnection.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            List<Editeur> result = new List<Editeur>();

            while (reader.Read())
            {
                Editeur item = new Editeur()
                {
                    Id_Editeur = reader["ID_EDITEUR"].ToString(),
                    Editeur_Designation = reader["EDITEUR"].ToString()
                };
                result.Add(item);
            }

            sqlConnection.Close();
            return result;

            /* 
            CREATE PROCEDURE [dbo].[GetListEditeur]
            @id int
            AS
                  SELECT ID_EDITEUR, EDITEUR FROM EDITEUR
                  ORDER BY NBPRODUIT DESC
                  FETCH FIRST 6 ROWS ONLY
            RETURN 0;
            */
        }

        public static string GetEditeur(string id)
        {
            SqlConnection sqlConnection = DataManager.Get();

            SqlCommand cmd = new SqlCommand
            {
                CommandText = "GetEditeurById",
                CommandType = System.Data.CommandType.StoredProcedure,
                Connection = sqlConnection
            };

            sqlConnection.Open();

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", id));

            SqlDataReader reader = cmd.ExecuteReader();

            string result = null;

            while (reader.Read())
            {
                result = reader["EDITEUR"].ToString();
            }


            sqlConnection.Close();
            return result;

            /* 
            CREATE PROCEDURE [dbo].[GetEditeurById]
            @id int
            AS
	            SELECT EDITEUR 
                FROM EDITEUR 
                WHERE ID_EDITEUR = :@id
	            ORDER BY EDITEUR DESC;
            RETURN 0;
            */
        }
    }
}
