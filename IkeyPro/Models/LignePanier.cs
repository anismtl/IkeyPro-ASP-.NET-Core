using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IkeyPro.Models
{
    public class LignePanier
    {
        private string codeProduit;
        private string produit;
        private int qte;
        private float prix;
        private string image;

        public LignePanier()
        {
        }

        public LignePanier(string codeProduit, string produit, int qte, float prix, string image)
        {
            this.codeProduit = codeProduit;
            this.produit = produit;
            this.qte = qte;
            this.prix = prix;
            this.image = image;
        }

        public virtual string Produit
        {
            get
            {
                return produit;
            }
            set
            {
                this.produit = value;
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


        public virtual float Prix
        {
            get
            {
                return prix;
            }
            set
            {
                this.prix = value;
            }
        }


        public virtual string Image
        {
            get
            {
                return image;
            }
            set
            {
                this.image = value;
            }
        }

    }
}
