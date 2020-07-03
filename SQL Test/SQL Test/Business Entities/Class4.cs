using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Test
{
    class Class4
    {
        public DateTime DateEntry { get; set; }
        public string Description { get; set; }
        public int QtyScrapped { get; set; }
        public int QtyCast { get; set; }



        public Class4(DateTime DateEntry, string Description, int QtyScrapped, int QtyCast)
        {
            this.DateEntry = DateEntry;
            this.Description = Description;
            this.QtyScrapped = QtyScrapped;
            this.QtyCast = QtyCast;
        }

    }
}