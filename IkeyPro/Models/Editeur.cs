using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IkeyPro.Models
{
    public class Editeur
    {
        private string id_Editeur;

        private string Editeur_Designation;

        public Editeur()
        {
        }

        public Editeur(string id_Editeur, string Editeur)
        {
            this.id_Editeur = id_Editeur;
            this.Editeur_Designation = Editeur;
        }

        public virtual string Id_Editeur
        {
            get
            {
                return id_Editeur;
            }
            set
            {
                this.id_Editeur = value;
            }
        }


        public virtual string getEditeur()
        {
            return Editeur_Designation;
        }

        public virtual void setEditeur(string Editeur)
        {
            this.Editeur_Designation = Editeur;
        }
    }
}
