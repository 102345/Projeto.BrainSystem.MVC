using System.Collections.Generic;

namespace BrainSystem.OS.Domain.Entities
{
    public class Grupo
    {
        public int IdGrupo { get; set; }

        public string Descricao { get; set; }

        public virtual IEnumerable<Cliente> Clientes { get; set; }
    }
}
