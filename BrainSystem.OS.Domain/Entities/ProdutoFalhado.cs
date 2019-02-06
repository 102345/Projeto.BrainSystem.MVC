using System.Collections.Generic;

namespace BrainSystem.OS.Domain.Entities
{
    public class ProdutoFalhado
    {
        public decimal IdProdutoFalhado { get; set; }

        public int IdProduto { get; set; }

        public int IdOrdemServico { get; set; }

        public int IdLocalizacacao { get; set; }

        public string NumeroSerie { get; set; }

        public int IdDetalhamentoFalha { get; set; }

        public int IdAcaoCorretiva { get; set; }

        public int IdSolucaoAdotada { get; set; }

        public int StatusFuncionamento { get; set; }

        public virtual OrdemServico OrdemServico { get; set; }

        public virtual IEnumerable<Produto> Produtos { get; set; }

        public virtual IEnumerable<LocalizacaoFalha> LocalizacoesFalhas { get; set; }

        public virtual IEnumerable<RetiraEquipamento> RetiraEquipamentos { get; set; }

        public virtual  IEnumerable<PecaAplicada> PecasAplicadas { get; set; }

    }
}
