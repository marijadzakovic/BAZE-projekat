using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zara.Repository.Models.DB
{
    public class EmployeeFullDetailsModel
    {
        public int ZaposleniID { get; set; }
        public string Ime { get; set; }
        public string Telefon { get; set; }
        public string NazivSektora { get; set; }
        public int Sifra { get; set; }
        public string RadnoMjesto { get; set; }
        public decimal Plata { get; set; }
        public DateTime DatumZaposlenja { get; set; }
        public int BrRadnihSatiUNedelji { get; set; }

    }
}
