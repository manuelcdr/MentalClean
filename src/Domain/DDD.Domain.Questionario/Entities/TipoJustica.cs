using PGLaw.Domain.Core.Interfaces.Entities;
using System;


namespace PGLaw.Domain.Juridico.Processos.Entitties
{
    public class TipoJustica : IDefaultEntity, ISincronizacaoEntity
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }

        // ISincronizacaoEntity
        public int IdExterno { get; set; }
        // -------------------------------------
    }
}
