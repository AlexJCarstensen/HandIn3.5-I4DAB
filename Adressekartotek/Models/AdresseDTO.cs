using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Adressekartotek.Models
{
    public class AdresseDTO
    {
        public long AdresseID { get; set; }
        public long PostNummer { get; set; }
        public string City { get; set; }
    }
}