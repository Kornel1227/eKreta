using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKreta.Models
{
    public class Osztaly
    {
        public Osztaly()
        {

        }

        public Osztaly(string osztalyNev, int teremId)
        {
            OsztalyNev = osztalyNev;
            TeremId = teremId;
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string OsztalyNev { get; set; }
        public int TeremId { get; set; }

    }
}
