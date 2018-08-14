using PGLaw.Domain.Core.Interfaces.Entities;
using System;

namespace PGLaw.Domain.Juridico.Processos.Entitties
{
    public class TipoCusta : IDefaultEntity, ISincronizacaoEntity
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }

        public int TipoLancamentoClienteId { get; set; } // tipo lançamento cliente do financeiro
        public int IdExterno { get; set; } // será o mesmo valor do campo acima - tipo lançamento cliente do financeiro
    }
}
