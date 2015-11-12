using System.Collections;
using System.Collections.Generic;

namespace Adressekartotek.Models
{
    public class AdresseDetailDTO
    {
        public long AdresseID { get; set; }
        public string Type { get; set; }
        public string VejNavn { get; set; }
        public long HusNummer { get; set; }
        public long PostNummer { get; set; }
        public string City { get; set; }
    }
}