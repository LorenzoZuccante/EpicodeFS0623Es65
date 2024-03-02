using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace PoliziaMunicipaleContext.Data
{
    public class PoliziaMunicipaleContext : DbContext
    {
        public PoliziaMunicipaleContext(DbContextOptions<PoliziaMunicipaleContext> options)
            : base(options)
        {
        }

        public DbSet<Agente> Agente { get; set; }
        public DbSet<Anagrafe> Anagrafe { get; set; }
        public DbSet<Comunicazione> Comunicazione { get; set; }
        public DbSet<Verbale> Verbale { get; set; }
        public DbSet<Violazione> Violazione { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Comunicazione>()
                .HasOne(c => c.Anagrafe)
                .WithMany(a => a.Comunicazioni)
                .HasForeignKey(c => c.IDAnagrafica);

            modelBuilder.Entity<Comunicazione>()
                .HasOne(c => c.Verbale)
                .WithMany(v => v.Comunicazioni)
                .HasForeignKey(c => c.IDVerbale);

            modelBuilder.Entity<Comunicazione>()
                .HasOne(c => c.Violazione)
                .WithMany(v => v.Comunicazioni)
                .HasForeignKey(c => c.IDViolazione);
        }
    }

    public class Agente
    {
        [Key]
        public int IDAgente { get; set; }
        public string NomeAgente { get; set; }
        public string CognomeAgente { get; set; }
        public DateTime DataAssunzione { get; set; }
        public ICollection<Verbale> Verbali { get; set; }
    }

    public class Anagrafe
    {
        [Key]
        public int IdAnagrafica { get; set; }
        public string Cognome { get; set; }
        public string Nome { get; set; }
        public string Indirizzo { get; set; }
        public string Citta { get; set; }
        public string Cod_Fisc { get; set; }
        public ICollection<Comunicazione> Comunicazioni { get; set; }
    }

    public class Comunicazione
    {
        [Key]
        public int ID { get; set; }
        public int IDAnagrafica { get; set; }
        public int IDVerbale { get; set; }
        public int IDViolazione { get; set; }
        public Anagrafe Anagrafe { get; set; }
        public Verbale Verbale { get; set; }
        public Violazione Violazione { get; set; }
    }

    public class Verbale
    {
        [Key]
        public int IDVerbale { get; set; }
        public DateTime DataViolazione { get; set; }
        public string IndirizzoViolazione { get; set; }
        public int IDAgente { get; set; }
        public DateTime DataTrascrizioneVerbale { get; set; }
        public decimal Importo { get; set; }
        public byte DecurtamentoPunti { get; set; }
        public Agente Agente { get; set; }
        public ICollection<Comunicazione> Comunicazioni { get; set; }
    }

    public class Violazione
    {
        [Key]
        public int IDViolazione { get; set; }
        public string Descrizione { get; set; }
        public ICollection<Comunicazione> Comunicazioni { get; set; }
    }
}
