using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IkeyPro.Models
{
    public class Commande
    {
        private int id_Commande;
        private int idClient;
        private DateTime date_commande;

        public Commande()
        {
        }

        public Commande(int id_Commande, int idClient, DateTime date_commande)
        {
            this.id_Commande = id_Commande;
            this.idClient = idClient;
            this.date_commande = date_commande;
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


        public virtual int IdClient
        {
            get
            {
                return idClient;
            }
            set
            {
                this.idClient = value;
            }
        }


        public virtual DateTime Date_commande
        {
            get
            {
                return date_commande;
            }
            set
            {
                this.date_commande = value;
            }
        }
    }
}

