using PGLaw.Domain.Core.Interfaces.Entities;
using System;

namespace PGLaw.Domain.Juridico.Processos.Entitties
{
    public class TipoDocumento : IDefaultEntity, ISincronizacaoEntity
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public bool MostrarClientes { get; set; }
        public bool MostrarPortalColigados { get; set; }
        public bool Trabalhista { get; set; }
        

        // ISincronizacaoEntity
        public int IdExterno { get; set; }
        // -------------------------------------


        public TipoDocumento()
        {
            Id = Guid.NewGuid();
        }
    }
}
