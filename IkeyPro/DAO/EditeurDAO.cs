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

            SqlConnection sqlConnection1 = DataManager.Get();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            cmd.CommandText = "getListEditeur";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = sqlConnection1;
            sqlConnection1.Open();
            reader = cmd.ExecuteReader();

            List<Editeur> result = new List<Editeur>();
            while (reader.Read())
            {
                Editeur item = new Editeur()
                {

                    Id_Editeur = reader["ID_EDITEUR"].ToString(),
                    Editeur_Designation1 = reader["EDITEUR"].ToString()
                };

                result.Add(item);
            }
            sqlConnection1.Close();
            return result;
        }




    }
}
