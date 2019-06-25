using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IkeyPro.Models
{
    public class Client
    {
        private int idClient;
        private string nomClient;
        private string prenomClient;
        private string courriel;
        private string tel;
        private string adresseClient;
        private string motPasse;

        public Client()
        {
        }

        public Client(int idClient, string nomClient, string prenomClient, string courriel, string tel, string adresseClient, string motPasse)
        {
            this.idClient = idClient;
            this.nomClient = nomClient;
            this.prenomClient = prenomClient;
            this.courriel = courriel;
            this.tel = tel;
            this.adresseClient = adresseClient;
            this.motPasse = motPasse;
        }

        public Client(string nomClient, string prenomClient, string courriel, string tel, string adresseClient, string motPasse)
        {
            this.nomClient = nomClient;
            this.prenomClient = prenomClient;
            this.courriel = courriel;
            this.tel = tel;
            this.adresseClient = adresseClient;
            this.motPasse = motPasse;
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


        public virtual string NomClient
        {
            get
            {
                return nomClient;
            }
            set
            {
                this.nomClient = value;
            }
        }


        public virtual string PrenomClient
        {
            get
            {
                return prenomClient;
            }
            set
            {
                this.prenomClient = value;
            }
        }


        public virtual string Courriel
        {
            get
            {
                return courriel;
            }
            set
            {
                this.courriel = value;
            }
        }


        public virtual string Tel
        {
            get
            {
                return tel;
            }
            set
            {
                this.tel = value;
            }
        }


        public virtual string AdresseClient
        {
            get
            {
                return adresseClient;
            }
            set
            {
                this.adresseClient = value;
            }
        }


        public virtual string MotPasse
        {
            get
            {
                return motPasse;
            }
            set
            {
                this.motPasse = value;
            }
        }


        public override string ToString()
        {
            return "Client{" + "idClient=" + idClient + ", nomClient=" + nomClient + ", prenomClient=" + prenomClient + ", courriel=" + courriel + ", tel=" + tel + ", adresseClient=" + adresseClient + ", motPasse=" + motPasse + '}';
        }

    }
}
