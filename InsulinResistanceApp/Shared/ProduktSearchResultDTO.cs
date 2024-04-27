using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsulinResistanceApp.Shared
{
    public class ProductSearchResultDTO
    {
        public List<Produkt> Produkty { get; set; } = new List<Produkt>();
        public int Strony { get; set; }
        public int ObecnaStrona { get; set; }
    }
}
