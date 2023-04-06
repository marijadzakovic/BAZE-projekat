using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zara.Repository.Models.DB
{
    public class EmployeeModel
    {
        public int ZaposleniID { get; set; }
        public string Ime { get; set; }
        public string Telefon { get; set; }
        public string NazivSektora { get; set; }
    }
}
