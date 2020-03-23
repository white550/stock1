using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stock1.Model
{
   public  class DepotModel
    {
        private int id;
        private string ckm;
        private string phone;

        public int Id { get => id; set => id = value; }
        public string Ckm { get => ckm; set => ckm = value; }
        public string Phone { get => phone; set => phone = value; }
    }
}
