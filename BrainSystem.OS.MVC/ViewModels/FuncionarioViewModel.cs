

using System.ComponentModel;

namespace BrainSystem.OS.MVC.ViewModels
{
    public class FuncionarioViewModel
    {

        public int IdFuncionario { get; set; }

        public int IdCliente { get; set; }

        [DisplayName("Nome")]
        public string Nome { get; set; }

        [DisplayName("Telefone")]
        public string Telefone { get; set; }

        [DisplayName("E-mail")]
        public string Email { get; set; }

        [DisplayName("Cargo")]
        public string Cargo { get; set; }

        [DisplayName("RG")]
        public string RG { get; set; }



    }
}