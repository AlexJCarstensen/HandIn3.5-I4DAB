namespace Adressekartotek.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Telefon")]
    public partial class Telefon
    {
        public long TelefonID { get; set; }

        public long PersonID { get; set; }

        public long TelefonNr { get; set; }

        [Required]
        public string Type { get; set; }

        public virtual Person Person { get; set; }
    }
}
