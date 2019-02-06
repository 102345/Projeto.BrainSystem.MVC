namespace BrainSystem.OS.Domain.Entities
{
    public class SolucaoAdotada
    {
        public int IdSolucaoAdotada { get; set; }

        public string Descricao { get; set; }

        public int IdProduto { get; set; }

        public virtual Produto  Produto { get; set; }
    }
}
