using Microsoft.EntityFrameworkCore;
using DDD.Domain.Test.Processos.Entities;
using DDD.Infra.Base.Data.EF;
using DDD.Data.EF.EntityConfigs;

namespace DDD.Data.EF.Context
{
    public class DefaultContext : DbContextBase
    {
        public DefaultContext() : base("DefaultConnection") { }

        public DbSet<Fruta> Frutas { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Animal> Animais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ModelBuilder.ApplyConfiguration(new FrutaConfig());
            ModelBuilder.ApplyConfiguration(new PessoaConfig());
            ModelBuilder.ApplyConfiguration(new AnimalConfig());
        }

    }
}
