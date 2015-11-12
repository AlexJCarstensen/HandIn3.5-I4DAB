namespace Adressekartotek.Models
{
    public class TelefonDetailDTO
    {
        public long TelefonID { get; set; }
        public long TelefonNr { get; set; }
        public string Type { get; set; }
        public long PersonID { get; set; }
        public string Person { get; set; }
    }
}