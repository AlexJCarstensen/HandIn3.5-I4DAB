using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdresseKartotek.Models
{
    public class Adresse
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string VejNavn { get; set; }
        [Required]
        public int HusNummer { get; set; }
        [Required]
        public int PostNummer { get; set; }
        [Required]
        public string City { get; set; }
   }
}
