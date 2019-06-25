using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IkeyPro.Models
{
    public class LigneCommande
    {
        private int id_Ligne;
        private int id_Commande;
        private string codeProduit;
        private int qte;

        public LigneCommande()
        {
        }

        public LigneCommande(int id_Ligne, int id_Commande, string codeProduit, int qte)
        {
            this.id_Ligne = id_Ligne;
            this.id_Commande = id_Commande;
            this.codeProduit = codeProduit;
            this.qte = qte;
        }

        public virtual int Id_Ligne
        {
            get
            {
                return id_Ligne;
            }
            set
            {
                this.id_Ligne = value;
            }
        }


        public virtual int Id_Commande
        {
            get
            {
                return id_Commande;
            }
            set
            {
                this.id_Commande = value;
            }
        }


        public virtual string CodeProduit
        {
            get
            {
                return codeProduit;
            }
            set
            {
                this.codeProduit = value;
            }
        }


        public virtual int Qte
        {
            get
            {
                return qte;
            }
            set
            {
                this.qte = value;
            }
        }


    }
}
