using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsulinResistanceApp.Shared
{
    public class ZmianaHasla
    {
        public string StareHaslo { get; set; } = string.Empty;
        [Required, StringLength(100), MinLength(8)]
        public string Haslo { get; set; } = string.Empty;
        [Compare("Haslo", ErrorMessage = "Hasła nie są identyczne")]
        public string PotwierdzenieHaslo { get; set; } = string.Empty;
    }
}
