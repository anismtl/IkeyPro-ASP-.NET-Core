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
            /* 
            CREATE PROCEDURE [dbo].[GetListeLegereProduitByCategorie]
            @idCategorie nvarchar
            AS
	            SELECT CODE_PRODUIT, PRODUIT, PRIX,
                       ID_EDITEUR, IMAGE, DISPONIBILITE
	            FROM PRODUITS
                WHERE ID_CATEGORIE =:@idCategorie
	            ORDER BY PRODUIT DESC;
            RETURN 0;
            */
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
            /* 
            CREATE PROCEDURE [dbo].[GetListeDesProduits]
            AS
                SELECT P.CODE_PRODUIT, P.PRODUIT,   P.DATE_RELEASE, P.PRIX, 
                       P.PLATEFORME,   EUR.EDITEUR, ID_EDITEUR,     EON.EDITION,
                       ID_EDITION,     P.LANGUE,    P.IMAGE,        P.DISPONIBILITE, 
                       P.NBCONSULT 
                FROM PRODUIT P
                INNER JOIN EDITEUR EUR ON P.ID_EDITEUR = EUR.ID_EDITEUR
                INNER JOIN EDITION EON ON P.ID_EDITION = EON.ID_EDITION
                ORDER BY NBCONSULT DESC;
            RETURN 0;
            */
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
            /* 
            CREATE PROCEDURE [dbo].[GetListeDesProduitsByName]
            @name nvarchar
            AS
                SELECT  P.CODE_PRODUIT, P.PRODUIT,      P.DATE_RELEASE,  P.PRIX,       P.PLATEFORME, 
                        EUR.EDITEUR,    P.ID_EDITEUR,   EON.EDITION,     P.ID_EDITION, 
                        P.LANGUE,       P.IMAGE,        P.DISPONIBILITE, P.NBCONSULT 
                FROM PRODUIT P 
                INNER JOIN EDITEUR EUR ON P.ID_EDITEUR = EUR.ID_EDITEUR 
                INNER JOIN EDITION EON ON P.ID_EDITION = EON.ID_EDITION 
                INNER JOIN CATEGORIE C ON P.ID_CATEGORIE = C.ID_CATEGORIE 
                WHERE LOWER(P.PRODUIT)    LIKE %@name% OR 
                      LOWER(EUR.EDITEUR)  LIKE %@name% OR 
                      LOWER(EON.EDITION)  LIKE %@name% OR 
                      LOWER(P.PLATEFORME) LIKE %@name% OR 
                      LOWER(C.CATEGORIE)  LIKE %@name%;
            RETURN 0;
            */
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

            /* 
            CREATE PROCEDURE [dbo].[GetListeDistinctEditeurByCat]
            @idCategorie nvarchar
            AS
                SELECT  DISTINCT(P.ID_EDITEUR), EUR.EDITEUR
                FROM PRODUIT P 
                INNER JOIN EDITEUR EUR ON P.ID_EDITEUR = EUR.ID_EDITEUR 
                WHERE P.ID_CATEGORIE=:@idCategorie;
            RETURN 0;
            */
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

            /* 
            CREATE PROCEDURE [dbo].[GetListeDistinctEditionByCat]
            @idCategorie nvarchar,
            @idEditeur nvarchar
            AS
                SELECT  DISTINCT(P.ID_EDITION), EUR.EDITION
                FROM PRODUIT P 
                INNER JOIN EDITION EUR ON P.ID_EDITION = EUR.ID_EDITION 
                WHERE P.ID_CATEGORIE=:@idCategorie AND
                      P.ID_EDITEUR  =:@idEditeur;
            RETURN 0;
            */
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

            /* 
            CREATE PROCEDURE [dbo].[GetListeDistinctLangue]
            @idCategorie nvarchar,
            @idEditeur nvarchar,
            @idEdition nvarchar
            AS
                SELECT  DISTINCT(P.LANGUE) LANGUE
                FROM PRODUIT P 
                INNER JOIN EDITEUR EUR ON P.ID_EDITEUR = EUR.ID_EDITEUR 
                INNER JOIN EDITION EON ON P.ID_EDITION = EON.ID_EDITION 
                INNER JOIN CATEGORIE C ON P.ID_CATEGORIE = C.ID_CATEGORIE 
                WHERE C.CATEGORIE  =:@idCategorie AND
                      EUR.EDITEUR  =:@idEditeur AND
                      EON.EDITION  =:@idEdition;
            RETURN 0;
            */
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
            /* 
            CREATE PROCEDURE [dbo].[GetListeMostViewedProduit]
            AS
                SELECT P.CODE_PRODUIT, P.PRODUIT,   P.DATE_RELEASE, P.PRIX, 
                       P.PLATEFORME,   EUR.EDITEUR, ID_EDITEUR,     EON.EDITION,
                       ID_EDITION,     P.LANGUE,    P.IMAGE,        P.DISPONIBILITE, 
                       P.NBCONSULT 
                FROM PRODUIT P
                INNER JOIN EDITEUR EUR ON P.ID_EDITEUR = EUR.ID_EDITEUR
                INNER JOIN EDITION EON ON P.ID_EDITION = EON.ID_EDITION
                ORDER BY NBCONSULT DESC
                FETCH FIRST 6 ROWS ONLY;
            RETURN 0;
            */
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

            /* 
            CREATE PROCEDURE [dbo].[RechercheProduits]
            @idCategorie nvarchar,
            @idEditeur nvarchar,
            @idEdition nvarchar
            AS
                SELECT P.CODE_PRODUIT, P.PRODUIT,   P.DATE_RELEASE, P.PRIX, 
                       P.PLATEFORME,   EUR.EDITEUR, ID_EDITEUR,     EON.EDITION,
                       ID_EDITION,     P.LANGUE,    P.IMAGE,        P.DISPONIBILITE, 
                       P.NBCONSULT 
                FROM PRODUIT P
                WHERE C.CATEGORIE  =:@idCategorie AND
                      EUR.EDITEUR  =:@idEditeur AND
                      EON.EDITION  =:@idEdition;
            RETURN 0;
            */
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
            /* 
            CREATE PROCEDURE [dbo].[GetListeFullProduitByCategorie]
            @idCategorie nvarchar
            AS
	            SELECT P.CODE_PRODUIT,  P.PRODUIT,   P.DATE_RELEASE, P.PRIX, 
                      P.PLATEFORME,     EUR.EDITEUR, ID_EDITEUR,     EON.EDITION,
                      ID_EDITION,       P.LANGUE,    P.IMAGE,        P.DISPONIBILITE, P.NBCONSULT
	            FROM PRODUITS P
                INNER JOIN EDITEUR EUR ON P.ID_EDITEUR = EUR.ID_EDITEUR 
                INNER JOIN EDITION EON ON P.ID_EDITION = EON.ID_EDITION 
                WHERE ID_CATEGORIE =:@idCategorie;
            RETURN 0;
            */
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
            /* 
            CREATE PROCEDURE [dbo].[GetListeFullProduitByEditeur]
            @idEditeur nvarchar
            AS
	            SELECT P.CODE_PRODUIT,  P.PRODUIT,   P.DATE_RELEASE, P.PRIX, 
                      P.PLATEFORME,     EUR.EDITEUR, ID_EDITEUR,     EON.EDITION,
                      ID_EDITION,       P.LANGUE,    P.IMAGE,        P.DISPONIBILITE, P.NBCONSULT
	            FROM PRODUITS P
                INNER JOIN EDITEUR EUR ON P.ID_EDITEUR = EUR.ID_EDITEUR 
                INNER JOIN EDITION EON ON P.ID_EDITION = EON.ID_EDITION 
                WHERE P.ID_EDITEUR =:@idEditeur;
            RETURN 0;
            */
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
            /* 
            CREATE PROCEDURE [dbo].[GetListeFullProduitByPublicite]
            AS
	            SELECT P.CODE_PRODUIT,  P.PRODUIT,   P.DATE_RELEASE, P.PRIX, 
                      P.PLATEFORME,     EUR.EDITEUR, ID_EDITEUR,     EON.EDITION,
                      ID_EDITION,       P.LANGUE,    P.IMAGE,        P.DISPONIBILITE, P.NBCONSULT
	            FROM PRODUITS P
                INNER JOIN EDITEUR EUR ON P.ID_EDITEUR = EUR.ID_EDITEUR 
                INNER JOIN EDITION EON ON P.ID_EDITION = EON.ID_EDITION 
                WHERE P.PUBLICITE =2
                ORDER BY P.PUBLICITE ASC;
            RETURN 0;
            */
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
            /* 
            CREATE PROCEDURE [dbo].[GetListeFullProduitByEdition]
            @idEdition nvarchar
            AS
	            SELECT P.CODE_PRODUIT,  P.PRODUIT,   P.DATE_RELEASE, P.PRIX, 
                      P.PLATEFORME,     EUR.EDITEUR, ID_EDITEUR,     EON.EDITION,
                      ID_EDITION,       P.LANGUE,    P.IMAGE,        P.DISPONIBILITE, P.NBCONSULT
	            FROM PRODUITS P
                INNER JOIN EDITEUR EUR ON P.ID_EDITEUR = EUR.ID_EDITEUR 
                INNER JOIN EDITION EON ON P.ID_EDITION = EON.ID_EDITION 
                WHERE ID_EDITION =:@idEdition;
            RETURN 0;
            */
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
            /* 
            CREATE PROCEDURE [dbo].[GetListeFullProduitByDispo]
            AS
	            SELECT P.CODE_PRODUIT,  P.PRODUIT,   P.DATE_RELEASE, P.PRIX, 
                      P.PLATEFORME,     EUR.EDITEUR, ID_EDITEUR,     EON.EDITION,
                      ID_EDITION,       P.LANGUE,    P.IMAGE,        P.DISPONIBILITE, P.NBCONSULT
	            FROM PRODUIT P
                INNER JOIN EDITEUR EUR ON P.ID_EDITEUR = EUR.ID_EDITEUR 
                INNER JOIN EDITION EON ON P.ID_EDITION = EON.ID_EDITION 
                WHERE P.DISPONIBILITE = 1;
            RETURN 0;
            */
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
            /* 
            CREATE PROCEDURE [dbo].[GetListeFullProduitByDispo]
            @idProduit nvarchar
            AS
	            SELECT P.CODE_PRODUIT,  P.PRODUIT,   P.DATE_RELEASE, P.PRIX, 
                      P.PLATEFORME,     EUR.EDITEUR, ID_EDITEUR,     EON.EDITION,
                      ID_EDITION,       P.LANGUE,    P.IMAGE,        P.DISPONIBILITE, P.NBCONSULT
	            FROM PRODUITS P
                INNER JOIN EDITEUR EUR ON P.ID_EDITEUR = EUR.ID_EDITEUR 
                INNER JOIN EDITION EON ON P.ID_EDITION = EON.ID_EDITION 
                WHERE P.CODE_PRODUIT =:@idProduit;
            RETURN 0;
            */
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
            /* 
            CREATE PROCEDURE [dbo].[GetProduitVedette]
            AS
	            SELECT P.CODE_PRODUIT,  P.PRODUIT,   P.DATE_RELEASE, P.PRIX, 
                      P.PLATEFORME,     EUR.EDITEUR, ID_EDITEUR,     EON.EDITION,
                      ID_EDITION,       P.LANGUE,    P.IMAGE,        P.DISPONIBILITE, P.NBCONSULT
	            FROM PRODUITS P
                INNER JOIN EDITEUR EUR ON P.ID_EDITEUR = EUR.ID_EDITEUR 
                INNER JOIN EDITION EON ON P.ID_EDITION = EON.ID_EDITION 
                WHERE P.PUBLICITE =1;
            RETURN 0;
            */
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


            /*CREATE PROCEDURE [dbo].[UpdateNbConsult]
             @idProduit NVARCHAR(50)
             @newNbConsul NVARCHAR(50)

             AS
              
             DECLARE @resultat int
              
             IF (SELECT count(CODE_PRODUIT) FROM Produit WHERE CODE_PRODUIT = @idProduit) = 0
              BEGIN
                  UPDATE PRODUIT SET NBCONSULT=:@newNbConsul;
                  set @resultat = 1
             END
             ELSE
                set @resultat = -1	
            return @resultat*/
        }
    }
}