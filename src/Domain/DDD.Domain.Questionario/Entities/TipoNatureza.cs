﻿using PGLaw.Domain.Core.Interfaces.Entities;
using System;

namespace PGLaw.Domain.Juridico.Processos.Entitties
{
    public class TipoNatureza : IDefaultEntity, ISincronizacaoEntity
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public string DescricaoReduzida { get; set; }
        public Guid JusticaId { get; set; }
        public bool Ativo { get; set; }

        // ISincronizacaoEntity
        public int IdExterno { get; set; }
        // -------------------------------------

        public TipoJustica Justica { get; set; }
    }
}
