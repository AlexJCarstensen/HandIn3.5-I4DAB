namespace AdresseKartotek.Models
{
    public class Bor
    {
         public int PersonId { get; set; }
         public Person Person { get; set; }
         public int AdresseId { get; set; }
         public Adresse Adresse { get; set; }
    }
}