using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IkeyPro.Models
{
    public class Edition
    {
        private string id_Edition;

        private string Edition_Designation;
        public Edition()
        {
        }

        public Edition(string id_Edition, string Edition)
        {
            this.id_Edition = id_Edition;
            this.Edition_Designation = Edition;
        }

        public virtual string Id_Edition
        {
            get
            {
                return id_Edition;
            }
            set
            {
                this.id_Edition = value;
            }
        }


        public virtual string getEdition()
        {
            return Edition_Designation;
        }

        public virtual void setEdition(string Edition)
        {
            this.Edition_Designation = Edition;
        }

    }


}

