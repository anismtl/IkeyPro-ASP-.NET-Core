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
        public static List<Produit> GetListeLegereProduitByCategorie(string idCategorie)
        {

            SqlConnection sqlConnection = DataManager.Get();
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "GetListeLegereProduitByCategorie",
                CommandType = System.Data.CommandType.StoredProcedure,
                Connection = sqlConnection
            };

            sqlConnection.Open();

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idCategorie", idCategorie));

            SqlDataReader reader = cmd.ExecuteReader();

            List<Produit> result = new List<Produit>();

            while (reader.Read())
            {
                Produit item = new Produit()
                {
                    CodeProduit = reader["CODE_PRODUIT"].ToString(),
                    Designtion_produit = reader["PRODUIT"].ToString(),
                    //DateRelease = reader["DATE_RELEASE"].ToString(),
                    Prix = float.Parse(reader["PRIX"].ToString()),
                    //Plateforme = reader["PLATEFORME"].ToString(),
                    Editeur = reader["ID_EDITEUR"].ToString(),
                    //Edition = reader["ID_EDITION"].ToString(),
                    //Langue = reader["LANGUE"].ToString(),
                    Image = reader["IMAGE"].ToString(),
                    Disponibilite = short.Parse(reader["DISPONIBILITE"].ToString()),
                    //Nbconsulte = int.Parse(reader["NBCONSULT"].ToString())
                };
                result.Add(item);
            }

            sqlConnection.Close();
            return result;
        }
        public static List<Produit> GetListeDesProduits()
        {

            SqlConnection sqlConnection = DataManager.Get();
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "GetListeDesProduits",
                CommandType = System.Data.CommandType.StoredProcedure,
                Connection = sqlConnection
            };

            sqlConnection.Open();

            SqlDataReader reader = cmd.ExecuteReader();

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
                    NbConsulte = int.Parse(reader["NBCONSULT"].ToString())
                };

                result.Add(item);
            }

            sqlConnection.Close();
            return result;
        }
        public static List<Produit> GetListeDesProduitsByName(string name)
        {

            SqlConnection sqlConnection = DataManager.Get();
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "GetListeDesProduitsByName",
                CommandType = System.Data.CommandType.StoredProcedure,
                Connection = sqlConnection
            };

            sqlConnection.Open();

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@name", name));

            SqlDataReader reader = cmd.ExecuteReader();

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
                    NbConsulte = int.Parse(reader["NBCONSULT"].ToString())
                };
                result.Add(item);
            }

            sqlConnection.Close();
            return result;
        }
        public static List<Editeur> GetListeDistinctEditeurByCat(string idCategorie)
        {
            SqlConnection sqlConnection = DataManager.Get();

            SqlCommand cmd = new SqlCommand
            {
                CommandText = "GetListeDistinctEditeurByCat",
                CommandType = System.Data.CommandType.StoredProcedure,
                Connection = sqlConnection
            };

            sqlConnection.Open();

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idCategorie", idCategorie));

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
        }
        public static List<Edition> GetListeDistinctEditionByCat(string idCategorie, string idEditeur)
        {
            SqlConnection sqlConnection = DataManager.Get();

            SqlCommand cmd = new SqlCommand
            {
                CommandText = "GetListeDistinctEditionByCat",
                CommandType = System.Data.CommandType.StoredProcedure,
                Connection = sqlConnection
            };

            sqlConnection.Open();

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idCategorie", idCategorie));
            cmd.Parameters.Add(new SqlParameter("@idEditeur", idEditeur));

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
        }
        public static List<string> GetListeDistinctLangue(string idCategorie, string idEditeur, string idEdition)
        {
            SqlConnection sqlConnection = DataManager.Get();

            SqlCommand cmd = new SqlCommand
            {
                CommandText = "GetListeDistinctLangue",
                CommandType = System.Data.CommandType.StoredProcedure,
                Connection = sqlConnection
            };

            sqlConnection.Open();

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idCategorie", idCategorie));
            cmd.Parameters.Add(new SqlParameter("@idEditeur", idEditeur));
            cmd.Parameters.Add(new SqlParameter("@idEdition", idEdition));

            SqlDataReader reader = cmd.ExecuteReader();

            List<string> result = new List<string>();

            while (reader.Read())
            {
                result.Add(reader["LANGUE"].ToString());
            }

            sqlConnection.Close();
            return result;
        }
        public static List<Produit> GetListeMostViewedProduit()
        {

            SqlConnection sqlConnection = DataManager.Get();
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "GetListeMostViewedProduit",
                CommandType = System.Data.CommandType.StoredProcedure,
                Connection = sqlConnection
            };

            sqlConnection.Open();

            SqlDataReader reader = cmd.ExecuteReader();

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
                    NbConsulte = int.Parse(reader["NBCONSULT"].ToString())
                };

                result.Add(item);
            }

            sqlConnection.Close();
            return result;
        }
        public static List<Produit> RechercheProduits(string idCategorie, string idEditeur, string idEdition)
        {
            SqlConnection sqlConnection = DataManager.Get();

            SqlCommand cmd = new SqlCommand
            {
                CommandText = "RechercheProduits",
                CommandType = System.Data.CommandType.StoredProcedure,
                Connection = sqlConnection
            };

            sqlConnection.Open();

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idCategorie", idCategorie));
            cmd.Parameters.Add(new SqlParameter("@idEditeur", idEditeur));
            cmd.Parameters.Add(new SqlParameter("@idEdition", idEdition));

            SqlDataReader reader = cmd.ExecuteReader();

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
                    NbConsulte = int.Parse(reader["NBCONSULT"].ToString())
                };

                result.Add(item);
            }

            sqlConnection.Close();
            return result;
        }
        public static List<Produit> GetListeFullProduitByCategorie(string idCategorie)
        {

            SqlConnection sqlConnection = DataManager.Get();
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "GetListeFullProduitByCategorie",
                CommandType = System.Data.CommandType.StoredProcedure,
                Connection = sqlConnection
            };

            sqlConnection.Open();

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idCategorie", idCategorie));

            SqlDataReader reader = cmd.ExecuteReader();

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
                    NbConsulte = int.Parse(reader["NBCONSULT"].ToString())
                };
                result.Add(item);
            }

            sqlConnection.Close();
            return result;
        }
        public static List<Produit> GetListeFullProduitByEditeur(string idEditeur)
        {

            SqlConnection sqlConnection = DataManager.Get();
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "GetListeFullProduitByEditeur",
                CommandType = System.Data.CommandType.StoredProcedure,
                Connection = sqlConnection
            };

            sqlConnection.Open();

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idEditeur", idEditeur));

            SqlDataReader reader = cmd.ExecuteReader();

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
                    Editeur = reader["EDITEUR"].ToString(),
                    Edition = reader["EDITION"].ToString(),
                    Langue = reader["LANGUE"].ToString(),
                    Image = reader["IMAGE"].ToString(),
                    Disponibilite = short.Parse(reader["DISPONIBILITE"].ToString()),
                    NbConsulte = int.Parse(reader["NBCONSULT"].ToString())
                };
                result.Add(item);
            }

            sqlConnection.Close();
            return result;
        }
        public static List<Produit> GetListeFullProduitByPublicite()
        {
            SqlConnection sqlConnection = DataManager.Get();
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "GetListeFullProduitByPublicite",
                CommandType = System.Data.CommandType.StoredProcedure,
                Connection = sqlConnection
            };

            sqlConnection.Open();

            SqlDataReader reader = cmd.ExecuteReader();

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
                    NbConsulte = int.Parse(reader["NBCONSULT"].ToString())
                };
                result.Add(item);
            }

            sqlConnection.Close();
            return result;
        }
        public static List<Produit> GetListeFullProduitByEdition(string idEdition)
        {

            SqlConnection sqlConnection = DataManager.Get();
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "GetListeFullProduitByEdition",
                CommandType = System.Data.CommandType.StoredProcedure,
                Connection = sqlConnection
            };

            sqlConnection.Open();

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idEdition", idEdition));

            SqlDataReader reader = cmd.ExecuteReader();

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
                    NbConsulte = int.Parse(reader["NBCONSULT"].ToString())
                };
                result.Add(item);
            }

            sqlConnection.Close();
            return result;
        }
        public static List<Produit> GetListeFullProduitByDispo()
        {
            SqlConnection sqlConnection = DataManager.Get();
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "GetListeFullProduitByDispo",
                CommandType = System.Data.CommandType.StoredProcedure,
                Connection = sqlConnection
            };

            sqlConnection.Open();

            SqlDataReader reader = cmd.ExecuteReader();

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
                    NbConsulte = int.Parse(reader["NBCONSULT"].ToString())
                };
                result.Add(item);
            }

            sqlConnection.Close();
            return result;
        }
        public static Produit GetProduit(string idProduit) {
            SqlConnection sqlConnection = DataManager.Get();
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "GetProduit",
                CommandType = System.Data.CommandType.StoredProcedure,
                Connection = sqlConnection
            };

            sqlConnection.Open();            

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idProduit", idProduit));

            SqlDataReader reader = cmd.ExecuteReader();

            reader.Read();

                Produit result = new Produit()
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
                    NbConsulte = int.Parse(reader["NBCONSULT"].ToString())
                };

            sqlConnection.Close();
            return result;
        }
        public static Produit GetProduitVedette()
        {
            SqlConnection sqlConnection = DataManager.Get();
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "GetProduitVedette",
                CommandType = System.Data.CommandType.StoredProcedure,
                Connection = sqlConnection
            };

            sqlConnection.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            reader.Read();

            Produit result = new Produit()
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
                NbConsulte = int.Parse(reader["NBCONSULT"].ToString())
            };

            sqlConnection.Close();
            return result;
        }
        public static int UpdateNbConsult(string idProduit)
        {
            int newNbConsul = GetProduit(idProduit).NbConsulte++;

            SqlConnection sqlConnection = DataManager.Get();

            SqlCommand cmd = new SqlCommand
            {
                CommandText = "UpdateNbConsult",
                CommandType = System.Data.CommandType.StoredProcedure,
                Connection = sqlConnection
            };

            cmd.Parameters.Add(new SqlParameter("@idProduit", idProduit));
            cmd.Parameters.Add(new SqlParameter("@newNbConsul", newNbConsul));

            int result = cmd.ExecuteNonQuery();

            sqlConnection.Close();

            return result;
        }
    }
}