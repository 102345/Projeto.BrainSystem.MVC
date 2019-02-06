using System;
using System.Collections.Generic;

namespace BrainSystem.OS.Domain.Entities
{
    public class OrdemServico
    {
        public double IdOrdemServico { get; set; }

        public int NumeroChamado { get; set; }

        public DateTime DataChamado { get; set; }

        public int IdCliente { get; set; }

        public string NomeTecnico { get; set; }

        public DateTime? DataPreenchimento { get; set; }

        public DateTime? HoraChegada { get; set; }

        public DateTime? HoraInicio { get; set; }

        public DateTime? HoraTermino { get; set; }

        public DateTime? HoraSaida { get; set; }

        public string Observacoes { get; set; }

        public int IdFuncionario { get; set; }

        public string Assinatura { get; set; }

        public int IdAnexo { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual IEnumerable<Anexo> Anexos { get; set; }

        public virtual IEnumerable<ProdutoFalhado> ProdutosFalhados { get; set; }

    }
}
