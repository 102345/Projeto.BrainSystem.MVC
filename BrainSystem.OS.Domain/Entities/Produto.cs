using System.Collections.Generic;

namespace BrainSystem.OS.Domain.Entities
{
    public class Produto
    {
        public int IdProduto { get; set; }

        public string  Descricao { get; set; }

        public virtual ProdutoFalhado ProdutoFalhado { get; set; }

        public virtual IEnumerable<LocalizacaoFalha> LocalizacoesFalhas { get; set; }

        public virtual IEnumerable<DetalhamentoFalha> DetalhamentosFalhas { get; set; }

        public virtual IEnumerable<SolucaoAdotada> SolucoesAdotadas { get; set; }
    }
}
