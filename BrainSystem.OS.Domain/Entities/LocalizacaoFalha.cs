using System.Collections.Generic;

namespace BrainSystem.OS.Domain.Entities
{
    public class LocalizacaoFalha
    {
        public int IdLocalizacao { get; set; }

        public string Descricao { get; set; }

        public int IdProduto { get; set; }

        public virtual Produto Produto { get; set; }

        public virtual IEnumerable<DetalhamentoFalha> DetalhamentosFalhas { get; set; }
    }
}
