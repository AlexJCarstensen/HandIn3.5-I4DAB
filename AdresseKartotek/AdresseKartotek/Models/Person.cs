namespace AdresseKartotek.Models
{
    public class Person
    {
        public int Id { get; set; }
        public int CPRNr { get; set; }
        public string Fornavn { get; set; }
        public string Mellemnavn { get; set; }
        public string Efternavn { get; set; }
        public string type { get; set; }

        public int AdresseId { get; set; }
        public Adresse Adresse { get; set; }  
    }
}