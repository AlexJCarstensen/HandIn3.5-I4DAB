namespace Adressekartotek.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AdressekartotekContext : DbContext
    {
        public AdressekartotekContext()
            : base("name=AdressekartotekContext")
        {
        }

        public virtual DbSet<Adresse> Adresse { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Telefon> Telefon { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adresse>()
                .HasMany(e => e.Person)
                .WithRequired(e => e.Adresse)
                .HasForeignKey(e => e.AdresseID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Adresse1)
                .WithMany(e => e.Person1)
                .Map(m => m.ToTable("bor").MapLeftKey("PersonID").MapRightKey("AdresseID"));
        }
    }
}
