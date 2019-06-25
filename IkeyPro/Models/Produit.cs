using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IkeyPro.Models
{
    public class Produit
    {
        private string codeProduit;
        private string categorie;
        private string editeur;
        private string edition;
        private string produit;
        private string plateforme;
        private string dateRelease;
        private double prix;
        private string langue;
        private string image;
        private short disponibilite;
        private int nbconsulte;

        public Produit()
        {
        }

        public Produit(string codeProduit, string produit, double prix, string image, int nbconsulte)
        {
            this.codeProduit = codeProduit;
            this.produit = produit;
            this.prix = prix;
            this.image = image;
            this.nbconsulte = nbconsulte;
        }

        public Produit(string codeProduit, string categorie, string editeur, string edition, string produit, string plateforme, string dateRelease, double prix, string langue, string image, short disponibilite, int nbconsulte)
        {
            this.codeProduit = codeProduit;
            this.categorie = categorie;
            this.editeur = editeur;
            this.edition = edition;
            this.produit = produit;
            this.plateforme = plateforme;
            this.dateRelease = dateRelease;
            this.prix = prix;
            this.langue = langue;
            this.image = image;
            this.disponibilite = disponibilite;
            this.nbconsulte = nbconsulte;
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


        public virtual string Categorie
        {
            get
            {
                return categorie;
            }
            set
            {
                this.categorie = value;
            }
        }


        public virtual string Editeur
        {
            get
            {
                return editeur;
            }
            set
            {
                this.editeur = value;
            }
        }


        public virtual string Edition
        {
            get
            {
                return edition;
            }
            set
            {
                this.edition = value;
            }
        }


        public virtual string getProduit()
        {
            return produit;
        }

        public virtual void setProduit(string produit)
        {
            this.produit = produit;
        }

        public virtual string Plateforme
        {
            get
            {
                return plateforme;
            }
            set
            {
                this.plateforme = value;
            }
        }


        public virtual string DateRelease
        {
            get
            {
                return dateRelease;
            }
            set
            {
                this.dateRelease = value;
            }
        }


        public virtual double Prix
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


        public virtual string Langue
        {
            get
            {
                return langue;
            }
            set
            {
                this.langue = value;
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


        public virtual short Disponibilite
        {
            get
            {
                return disponibilite;
            }
            set
            {
                this.disponibilite = value;
            }
        }


        public virtual int Nbconsulte
        {
            get
            {
                return nbconsulte;
            }
            set
            {
                this.nbconsulte = value;
            }
        }

    }

}
