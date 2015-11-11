namespace AdresseKartotek.Models
{
    public class Telefon
    {
        public int Id { get; set; }
        public int TelefonNr { get; set; }
        public string Type { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}