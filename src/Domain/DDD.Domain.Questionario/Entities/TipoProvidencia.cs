using PGLaw.Domain.Core.Interfaces.Entities;
using System;

namespace PGLaw.Domain.Juridico.Processos.Entitties
{
    public class TipoProvidencia : IDefaultEntity, ISincronizacaoEntity
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public string Sigla { get; set; }
        public bool Interna { get; set; }
        public bool Correspondente { get; set; }
        public bool ProtocoloPeticao { get; set; }
        public bool Ativo { get; set; }

        // ISincronizacaoEntity
        public int IdExterno { get; set; }
        // -------------------------------------

        //public ICollection<TipoEnquadramento> TiposEnquadramentos { get; set; }

        //public TipoProvidencia()
        //{
        //    Id = new Guid();
        //    TiposEnquadramentos = new List<TipoEnquadramento>();
        //}
    }
}
