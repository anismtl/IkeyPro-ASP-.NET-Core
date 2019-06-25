using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IkeyPro.Models
{
    public class Newsletter
    {
        private int id;
        private string courriel;
        private DateTime date_sub;
        private string etat;

        public Newsletter()
        {
        }

        public Newsletter(int id, string courriel, DateTime date_sub, string etat)
        {
            this.id = id;
            this.courriel = courriel;
            this.date_sub = date_sub;
            this.etat = etat;
        }




        public virtual int Id
        {
            get
            {
                return id;
            }
            set
            {
                this.id = value;
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


        public virtual DateTime Date_sub
        {
            get
            {
                return date_sub;
            }
            set
            {
                this.date_sub = value;
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
