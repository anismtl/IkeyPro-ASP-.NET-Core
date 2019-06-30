using IkeyPro.ADO;
using IkeyPro.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace IkeyPro.DAO
{
    public class ProduitDAO
    {

        public static List<Produit> GetListeMostViwedProduit()
        {

            SqlConnection sqlConnection1 = DataManager.Get();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            cmd.CommandText = "getMostViwedProduct";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();


            reader = cmd.ExecuteReader();

            List<Produit> result = new List<Produit>();
            while (reader.Read())
            {
                Produit item = new Produit()
                {


                    CodeProduit = reader["CODE_PRODUIT"].ToString(),
                    Designtion_produit = reader["PRODUIT"].ToString(),
                    DateRelease = reader["DATE_RELEASE"].ToString(),
                    Prix = float.Parse(reader["PRIX"].ToString()),
                    Plateforme = reader["PLATEFORME"].ToString(),
                    Editeur = reader["ID_EDITEUR"].ToString(),
                    Edition = reader["ID_EDITION"].ToString(),
                    Langue = reader["LANGUE"].ToString(),
                    Image = reader["IMAGE"].ToString(),
                    Disponibilite = short.Parse(reader["DISPONIBILITE"].ToString()),
                    Nbconsulte = int.Parse(reader["NBCONSULT"].ToString())


                };

                result.Add(item);
            }
            sqlConnection1.Close();
            return result;
        }




    }
}
