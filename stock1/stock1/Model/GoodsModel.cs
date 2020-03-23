using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stock1.Model
{
    public class GoodsModel
    {
        private int id;
        private string goodsID;
        private string gName;
        private double unitPrice;
        private string manufacture;
        private int categoryId;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string GoodsID
        {
            get
            {
                return goodsID;
            }

            set
            {
                goodsID = value;
            }
        }

        public string GName
        {
            get
            {
                return gName;
            }

            set
            {
                gName = value;
            }
        }

        public double UnitPrice
        {
            get
            {
                return unitPrice;
            }

            set
            {
                unitPrice = value;
            }
        }

        public string Manufacture
        {
            get
            {
                return manufacture;
            }

            set
            {
                manufacture = value;
            }
        }

        public int CategoryId
        {
            get
            {
                return categoryId;
            }

            set
            {
                categoryId = value;
            }
        }
    }
}
