using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stock1.Model
{
   public class CategoryModel
    {
        private int id;
        private string lx;

        public int Id { get => id; set => id = value; }
        public string Lx { get => lx; set => lx = value; }
    }
}
