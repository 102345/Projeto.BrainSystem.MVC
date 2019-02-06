namespace BrainSystem.OS.Domain.Entities
{
    public class SolicitacaoPeca
    {
        public int Id { get; set; }

        public int Quantidade { get; set; }

        public int IdProdutoFalhado { get; set; }

        public virtual  ProdutoFalhado ProdutoFalhado { get; set; }
    }
}
