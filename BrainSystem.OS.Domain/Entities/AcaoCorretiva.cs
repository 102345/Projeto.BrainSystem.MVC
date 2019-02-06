namespace BrainSystem.OS.Domain.Entities
{
    public class AcaoCorretiva
    {
        public int IdAcaoCorretiva { get; set; }

        public int IdProduto { get; set; }

        public string Descricao { get; set; }

        public int IdDetalhamentoFalha { get; set; }

        public virtual Produto Produto { get; set; }

        public virtual DetalhamentoFalha DetalhamentoFalha { get; set; }

    }
}
