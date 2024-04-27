using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsulinResistanceApp.Shared
{
    public class ZapomnianeHaslo
    {
        [Required]
        public string Email { get; set; } = string.Empty;
    }
}
