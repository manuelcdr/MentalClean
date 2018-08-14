using PGLaw.Domain.Core.Interfaces.Entities;
using System;

namespace PGLaw.Domain.Juridico.Processos.Entitties
{
    public class ProcessoCusta : IDefaultEntity, IAuditoriaEntity, ISincronizacaoEntity
    {
        public Guid Id { get; set; }

        public int ProcessoId { get; set; }
        public Guid TipoId { get; set; }
        public DateTime DataPrazo { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }

        // IAuditoriaEntity
        public DateTime DataInclusao { get; set; }
        public Guid UsuarioInclusaoId { get; set; }
        public string UsuarioInclusao { get; set; }        
        // ISincronizacaoEntity
        public int IdExterno { get; set; }


        public TipoCusta Tipo { get; set; }
    }
}
