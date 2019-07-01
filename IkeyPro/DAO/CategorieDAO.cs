using IkeyPro.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace IkeyPro.ADO
{
    public class CategorieDAO
    {

        public static List<Categorie> GetListCategorie()
        {
            SqlConnection sqlConnection = DataManager.Get();

            SqlCommand cmd = new SqlCommand
            {
                CommandText = "GetListCategorie",
                CommandType = System.Data.CommandType.StoredProcedure,
                Connection = sqlConnection
            };

            sqlConnection.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            List<Categorie> result = new List<Categorie>();

            while (reader.Read())
            {
                Categorie item = new Categorie()
                {

                    IdCategorie = reader["ID_CATEGORIE"].ToString(),
                    Categorie_Designation = reader["CATEGORIE"].ToString()
                };

                result.Add(item);
            }

            sqlConnection.Close();
            return result;
            /* 
            CREATE PROCEDURE [dbo].[GetListCategorie]
            AS
	            SELECT ID_CATEGORIE, CATEGORIE 
	            FROM CATEGORIE
	            ORDER BY CATEGORIE DESC;
            RETURN 0;
            */
        }

        public static string GetCategorie(string id)
        {
            SqlConnection sqlConnection = DataManager.Get();

            SqlCommand cmd = new SqlCommand {            
                CommandText = "GetCategorieById",
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
                result = reader["CATEGORIE"].ToString();
            }


            sqlConnection.Close();
            return result;

            /* 
            CREATE PROCEDURE [dbo].[GetCategorieById]
            @id int
            AS
	            SELECT CATEGORIE 
	            FROM CATEGORIE
                WHERE ID_CATEGORIE =:@id
	            ORDER BY CATEGORIE DESC;
            RETURN 0;
            */
        }
    }
}

