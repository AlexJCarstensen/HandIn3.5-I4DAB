using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AdresseKartotek.Models
{
    public class AdresseKartotekContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public AdresseKartotekContext() : base("name=AdresseKartotekContext")
        {
        }

        public System.Data.Entity.DbSet<AdresseKartotek.Models.Person> People { get; set; }

        public System.Data.Entity.DbSet<AdresseKartotek.Models.Adresse> Adresses { get; set; }

        public System.Data.Entity.DbSet<AdresseKartotek.Models.Bor> Bors { get; set; }

        public System.Data.Entity.DbSet<AdresseKartotek.Models.Telefon> Telefons { get; set; }
    }
}
