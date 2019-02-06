using System;

namespace BrainSystem.OS.Domain.Entities
{   
    //[Serializable]
    public class Funcionario
    {
        //public int Id { get; set; }

        public int IdFuncionario { get; set; }

        public int IdCliente { get; set; }

        public string Nome { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public string Cargo { get; set; }

        public string RG { get; set; }

        public virtual Cliente Cliente { get; set; }
    }
}
