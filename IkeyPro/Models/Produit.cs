using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IkeyPro.Models
{
    public class Produit
    {
        public string CodeProduit { get; set; }
        public string Categorie { get; set; }
        public string Editeur { get; set; }
        public string Edition { get; set; }
        public string Designtion_produit { get; set; }
        public string Plateforme { get; set; }
        public string DateRelease { get; set; }
        public double Prix { get; set; }
        public string Langue { get; set; }
        public string Image { get; set; }
        public short Disponibilite { get; set; }
        public int NbConsulte { get; set; }
    }
}
