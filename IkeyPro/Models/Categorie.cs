using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IkeyPro.Models
{
    public class Categorie
    {
        private string idCategorie;
        private string categorie;

        public Categorie()
        {
        }

        public Categorie(string idCategorie, string categorie)
        {
            this.idCategorie = idCategorie;
            this.categorie = categorie;
        }

        public virtual string IdCategorie
        {
            get
            {
                return idCategorie;
            }
            set
            {
                this.idCategorie = value;
            }
        }


        public virtual string getCategorie()
        {
            return categorie;
        }

        public virtual void setCategorie(string categorie)
        {
            this.categorie = categorie;
        }
    }
}
