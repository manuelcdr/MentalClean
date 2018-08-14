using PGLaw.Domain.Core.Interfaces.Entities;
using PGLaw.Domain.Juridico.Processos.ValueObjects;
using System;

namespace PGLaw.Domain.Juridico.Processos.Entitties
{
    public class ProcessoAndamento : IDefaultEntity, IAuditoriaEntity, ISincronizacaoEntity
    {
        public Guid Id { get; set; }

        public int ProcessoId { get; set; }
        public Guid TipoId { get; set; }

        public DateTime DataAndamento { get; set; }
        public string Descricao { get; set; }        
        public string FolhaProcesso { get; set; }


        public Guid? OrigemId { get; set; }
        public Origem Origem { get; set; }

        public int? TLegalId { get; set; }


        public int? TentativaSolucaoId { get; set; }
        public int? DeliberacaoId { get; set; }

        // IAuditoriaEntity
        public DateTime DataInclusao { get; set; }
        public Guid UsuarioInclusaoId { get; set; }
        public string UsuarioInclusao { get; set; }
        // ISincronizacaoEntity
        public int IdExterno { get; set; }


        //public string Explicacao { get; set; }
        //public int? ProcessoPrazoId { get; set; }
        //public int? ProcessoCumprimentoId { get; set; }
        //public int? ProcessoCustasId { get; set; }
        //public int? ProcessoProvidenciaId { get; set; }

        //public string Status { get; set; }

        //public void CopiarDescricaoParaExplicacao()
        //{
        //    Explicacao = Descricao;
        //}

        public ProcessoAndamento()
        {
        }

        public ProcessoAndamento(int processoId, Guid tipoId, DateTime dataAndamento, string descricao, Guid usuarioInclusaoId, string usuarioInclusao)
        {
            ProcessoId = processoId;
            TipoId = tipoId;
            DataAndamento = dataAndamento;
            Descricao = descricao;

            UsuarioInclusaoId = usuarioInclusaoId;
            UsuarioInclusao = usuarioInclusao;
            DataInclusao = DateTime.Now;
        }

        public ProcessoAndamento(int processoId, Guid tipoId, DateTime dataAndamento, string descricao, Guid usuarioInclusaoId, string usuarioInclusao, Guid origemId, Origem origem)
        {
            ProcessoId = processoId;
            TipoId = tipoId;
            DataAndamento = dataAndamento;
            Descricao = descricao;

            UsuarioInclusaoId = usuarioInclusaoId;
            UsuarioInclusao = usuarioInclusao;
            DataInclusao = DateTime.Now;

            OrigemId = origemId;
            origem = Origem;
        }

        public ProcessoAndamento(int processoId, Guid tipoId, DateTime dataAndamento, string descricao, Guid usuarioInclusaoId, string usuarioInclusao, int tLegalId)
        {
            ProcessoId = processoId;
            TipoId = tipoId;
            DataAndamento = dataAndamento;
            Descricao = descricao;

            UsuarioInclusaoId = usuarioInclusaoId;
            UsuarioInclusao = usuarioInclusao;
            DataInclusao = DateTime.Now;

            TLegalId = tLegalId;
        }

        public void DataAndamentoIgualaDataDeInclusao()
        {
            DataAndamento = DataInclusao;
        }
    }
}
