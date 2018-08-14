using DDD.Infra.Cross.Common.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace DDD.Infra.Base.Data.EF
{
    public abstract class DbContextBase : DbContext
    {
        public string ConnectionString { get; }

        public ModelBuilder ModelBuilder { get; set; }

        public DbContextBase() { }

        public DbContextBase(string connectionString)
        {
            ConnectionString = connectionString;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ModelBuilder = modelBuilder;
            base.OnModelCreating(modelBuilder);
            ConfigurarNomesDasTabelas();
            ConfigurarChavesPrimarias();
            ConfigurarTamanhoMaximoCampos();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString(ConnectionString ?? "DefaultConnection"));
        }

        protected void ConfigurarNomesDasTabelas()
        {
            foreach (var entity in ModelBuilder.Model.GetEntityTypes())
            {
                // retira a convenção de plularização dos nomes das tabelas
                entity.Relational().TableName = entity.DisplayName();
            }
        }

        protected void ConfigurarChavesPrimarias()
        {
            foreach (var entity in ModelBuilder.Model.GetEntityTypes())
            {
                foreach (var prop in entity.GetDeclaredProperties())
                {
                    if (prop.Name.ToLower() == "id")
                    {
                        prop.ValueGenerated = ValueGenerated.Never;
                    }
                }
            }
        }

        protected void ConfigurarTamanhoMaximoCampos()
        {
            foreach (var entity in ModelBuilder.Model.GetEntityTypes())
            {
                foreach (var prop in entity.GetDeclaredProperties())
                {
                    if (prop.ClrType == typeof(string))
                    {
                        prop.SetMaxLength(ParametrosDeConfiguracao.MaxLenght);
                    }
                }
            }
        }
    }
}
