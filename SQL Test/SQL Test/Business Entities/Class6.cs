using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCP
{
    class Class6
    {
        private string description;
        private int qty;

        public string Reason { get => description; set => description = value; }
        public int QtyFailed { get => qty; set => qty = value; }

        public Class6(string description, int qty)
        {
            this.description = description;
            this.qty = qty;
        }
    }
}
