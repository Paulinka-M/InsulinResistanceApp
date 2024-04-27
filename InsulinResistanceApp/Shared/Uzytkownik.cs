using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsulinResistanceApp.Shared
{
    public class Uzytkownik
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public byte[] HashowaneHaslo { get; set; }
        public byte[] Sol { get; set; }
        public DateTime DataUtworzeniaKonta { get; set; } = DateTime.Now;
        public string? resetPasswordToken { get; set; }
        public DateTime? resetTokenNiewazny { get; set; }

    }
}
