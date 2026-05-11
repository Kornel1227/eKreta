using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKreta.Models
{
    public class Tanar
    {
        public Tanar()
        {

        }

        public Tanar(string vezNev, string utoNev, int osztalyId, bool kedvesE)
        {
            VezNev = vezNev;
            UtoNev = utoNev;
            OsztalyId = osztalyId;
            KedvesE = kedvesE;
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string VezNev { get; set; }
        public string UtoNev { get; set; }
        public int OsztalyId { get; set; }
        public bool KedvesE { get; set; }


    }
}
