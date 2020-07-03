using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Test
{
    class Class2
    {
        private string incidentID;
        private string type;

        public string IncidentID { get => incidentID; set => incidentID = value; }
        public string Type { get => type; set => type = value; }

        public Class2(string incidentID, string type)
        {
            this.incidentID = incidentID;
            this.type = type;
        }
    }
}
