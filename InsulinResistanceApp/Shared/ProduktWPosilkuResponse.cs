using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsulinResistanceApp.Shared
{
    public class ProduktWPosilkuResponse
    {
        public int ProduktId { get; set; }
        public string Nazwa { get; set; } = string.Empty;
        public int kcal { get; set; } //kalorie na 100g
        public int weglowodany { get; set; } //weglowodany na 100g
        public int tluszcze { get; set; } //tluszcze na 100g
        public int bialko { get; set; } //bialko na 100g
        public int indeksglikemiczny { get; set; }
        public int waga { get; set; }
    }
}
