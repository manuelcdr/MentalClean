using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Linq.Expressions;

namespace DDD.Infra.Base.Data.EF
{
    public class EntityConfigBase<T> : IEntityTypeConfiguration<T> where T : class
    {

        public EntityConfigBase(){ }

        protected EntityTypeBuilder<T> Builder { get; set; }

        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            Builder = builder;
            ConfigurarAutoValidador();
            ConfigurarChavePrimaria();
        }

        protected void ConfigurarAutoValidador()
        {
            Ignore("ValidationResult");
            Ignore("CascadeMode");
        }

        protected void ConfigurarChavePrimaria()
        {
            foreach (var prop in typeof(T).GetProperties())
            {
                if (prop.Name == "Id")
                {
                    Builder.HasKey("Id");

                    Builder.Property("Id")
                        .ValueGeneratedNever();
                }
            }

        }

        protected PropertyBuilder<TProperty> IsRequired<TProperty>(Expression<Func<T,TProperty>> propertyExpression)
        {
            return Builder.Property(propertyExpression).IsRequired();
        }

        protected EntityTypeBuilder<T> Ignore(string propertyName)
        {
            return Builder.Ignore(propertyName);
        }

        protected EntityTypeBuilder<T> Ignore<TProperty>(Expression<Func<T, object>> propertyExpression)
        {
            return Builder.Ignore(propertyExpression);
        }

        protected void ConfigurarAutoValidador<TRelatedEntity>(ReferenceOwnershipBuilder<T, TRelatedEntity> referenceOwnershipBuilder)
            where TRelatedEntity : class
        {
            referenceOwnershipBuilder.Ignore("ValidationResult");
            referenceOwnershipBuilder.Ignore("CascadeMode");
        }

        /// <summary>
        /// Configura as chaves primarias (caso seja somente 2) e os relacionamentos
        /// </summary>
        protected void ManyToManyAndKeys<TPrincipal, TSecundary>()
        {
            ManyToManyKeys<TPrincipal, TSecundary>();
            ManyToMany<TPrincipal, TSecundary>();
        }

        /// <summary>
        /// Configura os relacionamentos
        /// </summary>
        protected void ManyToMany<TPrincipal, TSecundary>()
        {
            var nomePrincipal = typeof(TPrincipal).Name;
            var nomeSecundario = typeof(TSecundary).Name;
            var chavePrincipal = $"{nomePrincipal}Id";
            var chaveSecundaria = $"{nomeSecundario}Id";
            var classeRelacionadora = typeof(T).Name;

            Builder.HasOne(typeof(TPrincipal), nomePrincipal)
                .WithMany(classeRelacionadora)
                .HasForeignKey(chavePrincipal)
                .OnDelete(DeleteBehavior.Restrict);

            Builder.HasOne(typeof(TSecundary), nomeSecundario)
                .WithMany(classeRelacionadora)
                .HasForeignKey(chaveSecundaria)
                .OnDelete(DeleteBehavior.Restrict);
        }

        /// <summary>
        /// Configura as chaves primarias (caso seja somente 2)
        /// </summary>
        protected KeyBuilder ManyToManyKeys<TPrincipal, TSecundary>()
        {
            var nomePrincipal = typeof(TPrincipal).Name;
            var nomeSecundario = typeof(TSecundary).Name;
            var chavePrincipal = $"{nomePrincipal}Id";
            var chaveSecundaria = $"{nomeSecundario}Id";
            var classeRelacionadora = typeof(T).Name;

            return Builder.HasKey(chavePrincipal, chaveSecundaria);
        }

        protected ReferenceCollectionBuilder HasOne<TEntity>(string nomeCampo = null, string nomeCampoChave = null)
        {
            nomeCampo = nomeCampo ?? typeof(TEntity).Name;
            nomeCampoChave = nomeCampoChave ?? $"{nomeCampo}Id";

            return Builder.HasOne(typeof(TEntity), nomeCampo)
                .WithMany()
                .HasForeignKey(nomeCampoChave)
                .OnDelete(DeleteBehavior.Restrict);
        }

        protected ReferenceCollectionBuilder HasOneWithMany<TEntity>(string nomeCampo = null, string nomeCollection = null, string nomeCampoChave = null)
        {
            nomeCampo = nomeCampo ?? typeof(TEntity).Name;
            nomeCollection = nomeCollection ?? $"{typeof(T).Name}s";
            nomeCampoChave = nomeCampoChave ?? $"{nomeCampo}Id";

            return Builder.HasOne(typeof(TEntity), nomeCampo)
                .WithMany(nomeCollection)
                .HasForeignKey(nomeCampoChave)
                .OnDelete(DeleteBehavior.Restrict);
        }

        protected ReferenceCollectionBuilder HasOneWithManyCascade<TEntity>(string nomeCampo = null, string nomeCollection = null, string nomeCampoChave = null)
        {
            nomeCampo = nomeCampo ?? typeof(TEntity).Name;
            nomeCollection = nomeCollection ?? $"{typeof(T).Name}s";
            nomeCampoChave = nomeCampoChave ?? $"{nomeCampo}Id";

            return Builder.HasOne(typeof(TEntity), nomeCampo)
                .WithMany(nomeCollection)
                .HasForeignKey(nomeCampoChave)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
