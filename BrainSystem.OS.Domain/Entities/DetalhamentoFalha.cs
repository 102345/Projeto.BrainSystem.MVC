using System.Collections.Generic;

namespace BrainSystem.OS.Domain.Entities
{
    public class DetalhamentoFalha
    {
        public int IdDetalhamentoFalha { get; set; }

        public string Descricao { get; set; }

        public int IdProduto { get; set; }

        public int IdLocalizacao { get; set; }

        public virtual Produto Produto { get; set; }

        public virtual LocalizacaoFalha LocalizacaoFalha { get; set; }

        public virtual IEnumerable<DetalhamentoFalha> DetalhamentosFalhas { get; set; }





    }
}
