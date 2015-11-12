namespace Adressekartotek.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Person")]
    public partial class Person
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Person()
        {
            Telefon = new HashSet<Telefon>();
            Adresse1 = new HashSet<Adresse>();
        }

        public long PersonID { get; set; }

        public long CPRNr { get; set; }

        [Required]
        public string Fornavn { get; set; }

        public string Mellemnavn { get; set; }

        [Required]
        public string Efternavn { get; set; }

        [Required]
        public string type { get; set; }

        public long AdresseID { get; set; }

        public virtual Adresse Adresse { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Telefon> Telefon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Adresse> Adresse1 { get; set; }
    }
}
