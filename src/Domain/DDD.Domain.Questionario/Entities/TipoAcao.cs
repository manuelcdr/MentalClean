using PGLaw.Domain.Core.Interfaces.Entities;
using System;

namespace PGLaw.Domain.Juridico.Processos.Entitties
{
    public class TipoAcao : IDefaultEntity, ISincronizacaoEntity
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public Guid TipoNaturezaId { get; set; }
        public int NumeroOrdem { get; set; }
        public bool Ativo { get; set; }

        // ISincronizacaoEntity
        public int IdExterno { get; set; }
        // -------------------------------------

        public TipoNatureza Natureza { get; set; }
    }
}
