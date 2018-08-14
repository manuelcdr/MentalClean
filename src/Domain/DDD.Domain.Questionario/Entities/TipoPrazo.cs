using PGLaw.Domain.Core.Interfaces.Entities;
using System;

namespace PGLaw.Domain.Juridico.Processos.Entitties
{
    public class TipoPrazo : IDefaultEntity, ISincronizacaoEntity
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public bool Audiencia { get; set; }
        public bool BaixaPrazo { get; set; }
        public bool AceitaSelecaoManual { get; set; }

        public int NumeroDiasPrazoColigado { get; set; }

        public bool MostrarHome { get; set; }
        public bool MostrarClientes { get; set; }
        public bool MostrarPortalColigados { get; set; }
                               
        public bool RequerDocumento { get; set; }
        public bool GerarProvidenciaBaixa { get; set; }

        public bool Ativo { get; set; }
        //public bool Administrativo { get; set; }

        // ISincronizacaoEntity
        public int IdExterno { get; set; }
        // -------------------------------------

    }
}
