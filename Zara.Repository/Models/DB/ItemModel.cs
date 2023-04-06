using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zara.Repository.Models.DB
{
    public class ItemModel
    {
        public int Id { set; get; }
        public int Sifra { get; set; }
        public string Naziv { get; set; }
        public decimal Cijena { get; set; }
        public string OznakaVelicine { get; set; }
        public string NazivSektora { get; set; }
        public string Opis { get; set; }
        public string Boja { get; set; }
    }
}
