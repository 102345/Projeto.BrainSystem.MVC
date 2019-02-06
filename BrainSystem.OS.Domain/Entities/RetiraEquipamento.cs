namespace BrainSystem.OS.Domain.Entities
{
    public class RetiraEquipamento
    {
        public int Id { get; set; }

        public int IdProdutoFalhado { get; set; }

        public string NumeroSerie { get; set; }

        public virtual ProdutoFalhado ProdutoFalhado { get; set; }

    }
}
