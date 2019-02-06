using BrainSystem.OS.Domain.Entities;

namespace BrainSystem.OS.BLL.Interface
{
    public interface IClienteBusiness : IBaseBusiness<Cliente>
    {
        Cliente BuscarClienteOrdemServico(int IdOrdemServico);
        
    }
}
