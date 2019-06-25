using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IkeyPro.Models
{
    public class Categorie
    {
        private string idCategorie;
        private string categorie_Designation;

        public Categorie()
        {
        }

        public Categorie(string idCategorie, string categorie)
        {
            this.idCategorie = idCategorie;
            this.Categorie_Designation = categorie;
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

        public string Categorie_Designation { get => categorie_Designation; set => categorie_Designation = value; }
    }
}
