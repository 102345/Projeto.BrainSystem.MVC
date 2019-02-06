using System.Collections.Generic;

namespace BrainSystem.OS.Domain.Entities
{
    public class Cliente
    {
        public int IdCliente { get; set; }

        public string NomeFantasia { get; set; }

        public string RazaoSocial { get; set; }

        public string CNPJ { get; set; }

        public int IdGrupo { get; set; }

        public IEnumerable<Funcionario> Funcionarios { get; set; }

        public virtual Grupo Grupo { get; set; }
    }
}
