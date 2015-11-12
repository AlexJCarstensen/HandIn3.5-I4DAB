namespace Adressekartotek.Models
{
    public class PersonDetailDTO
    {
        public long PersonID { get; set; }
        public long CPRNr { get; set; }
        public string Fornavn { get; set; }
        public string Mellemnavn { get; set; }
        public string Efternavn { get; set; }
        public string type { get; set; }
        public long AdresseID { get; set; }
    }
}