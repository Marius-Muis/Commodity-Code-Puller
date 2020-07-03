using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Test
{
    class Class7
    {
        public string something1 { get; set; }
        public string something2 { get; set; }

        public Class7(string ProductClass, string PCDesc)
        {
            this.something1 = ProductClass;
            this.something2 = PCDesc;
        }

        

    }
}
