using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stock1.Model
{
   public class CustomerModel
    {
        private int Id;
        private string CName;
        private string Address;
        private string Phone;

        public int Id1
        {
            get
            {
                return Id;
            }

            set
            {
                Id = value;
            }
        }

        public string CName1
        {
            get
            {
                return CName;
            }

            set
            {
                CName = value;
            }
        }

        public string Address1
        {
            get
            {
                return Address;
            }

            set
            {
                Address = value;
            }
        }

        public string Phone1
        {
            get
            {
                return Phone;
            }

            set
            {
                Phone = value;
            }
        }
    }
}
