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
            this.Editeur_Designation1 = Editeur;
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

        public string Editeur_Designation1 { get => Editeur_Designation; set => Editeur_Designation = value; }
    }
}
