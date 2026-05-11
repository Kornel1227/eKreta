using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKreta.Models
{
    public class Diak
    {
        public Diak()
        {
        }

        public Diak(string vezNev, string utoNev, string szulDatum, string anyjaNeve, string lakcim)
        {
            VezNev = vezNev;
            UtoNev = utoNev;
            SzulDatum = szulDatum;
            AnyjaNeve = anyjaNeve;
            Lakcim = lakcim;
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string VezNev { get; set; }
        public string UtoNev { get; set; }
        public string SzulDatum { get; set; }
        public string AnyjaNeve { get; set; }
        public string Lakcim {  get; set; }

    }
}
