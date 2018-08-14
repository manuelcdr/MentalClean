using PGLaw.Domain.Core.Interfaces.Entities;
using PGLaw.Domain.Juridico.Processos.ValueObjects;
using System;

namespace PGLaw.Domain.Juridico.Processos.Entitties
{
    public class ProcessoPrazo : IDefaultEntity, IAuditoriaEntity, ISincronizacaoEntity
    {
        public ProcessoPrazo()
        {
        }


        public Guid Id { get; set; }

        public int ProcessoId { get; set; }
        public Guid TipoId { get; set; }
        public DateTime DataPrazo { get; set; }
        public DateTime DataPrazoFatal { get; set; }
        public string Descricao { get; set; }
        public int StatusPrazoId { get; set; }
        public int NumeroAdiamentos { get; set; }
        

        public string DescricaoBaixa { get; set; }
        public DateTime DataBaixa { get; set; }
        public Guid UsuarioBaixaId { get; set; }
        public string UsuarioBaixa { get; set; }

        public Guid? OrigemId { get; set; }
        public Origem Origem { get; set; }

        // IAuditoriaEntity --------------------
        public DateTime DataInclusao { get; set; }
        public Guid UsuarioInclusaoId { get; set; }
        public string UsuarioInclusao { get; set; }
        // ISincronizacaoEntity
        public int IdExterno { get; set; }
        // -------------------------------------

    }
}
