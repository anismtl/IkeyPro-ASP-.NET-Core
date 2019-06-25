using IkeyPro.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace IkeyPro.ADO
{
    public class CategorieADO
    {

        public static List<Categorie> GetListCategorie()
        {
            //string chaine = "Data Source=aniss.ca;Initial Catalog=intraDB;Persist Security Info=True;User ID=anis;Password=SAM123";
            SqlConnection sqlConnection1 = DataManager.Get();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            cmd.CommandText = "getListCategorie";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = sqlConnection1;
            sqlConnection1.Open();
            reader = cmd.ExecuteReader();

            List<Categorie> result = new List<Categorie>();
            while (reader.Read())
            {
                Categorie item = new Categorie()
                {
                    //Id_activite = int.Parse(reader["Id_activite"].ToString()),
                    IdCategorie = reader["ID_CATEGORIE"].ToString(),
                    Categorie_Designation = reader["CATEGORIE"].ToString()


                };

                result.Add(item);
            }
            sqlConnection1.Close();
            return result;
        }
    }
}
