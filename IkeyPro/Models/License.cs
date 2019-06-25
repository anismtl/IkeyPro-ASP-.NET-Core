using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IkeyPro.Models
{
    public class License
    {
        private int idLicense;
        private string license;
        private string codeProduit;
        private string etat;

        public License(int idLicense, string license, string codeProduit, string etat)
        {
            this.idLicense = idLicense;
            this.license = license;
            this.codeProduit = codeProduit;
            this.etat = etat;
        }

        public virtual int IdLicense
        {
            get
            {
                return idLicense;
            }
            set
            {
                this.idLicense = value;
            }
        }


        public virtual string getLicense()
        {
            return license;
        }

        public virtual void setLicense(string license)
        {
            this.license = license;
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


        public virtual string Etat
        {
            get
            {
                return etat;
            }
            set
            {
                this.etat = value;
            }
        }
    }
}
