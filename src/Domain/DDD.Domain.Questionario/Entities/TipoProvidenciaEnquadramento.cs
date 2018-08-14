using PGLaw.Domain.Core.Interfaces.Entities;
using System;

namespace PGLaw.Domain.Juridico.Processos.Entitties
{
    public class TipoProvidenciaEnquadramento
    {
        public Guid TipoProvidenciaId { get; set; }
        public Guid TipoEnquadramentoId { get; set; }

        public TipoProvidencia TipoProvidencia { get; set; }
        //public TipoEnquadramento TipoEnquadramento { get; set; }
    }
}
