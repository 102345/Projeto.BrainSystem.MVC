
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BrainSystem.OS.Domain.Entities;

namespace BrainSystem.OS.MVC.ViewModels
{
    public class OrdemServicoViewModel
    {
        [DisplayName("Ordem servico Nr")]
        public double IdOrdemServico { get; set; }

        [DisplayName("Protocolo chamado")]
        public int NumeroChamado { get; set; }

        [DisplayName("Registrado em")]
        public DateTime DataChamado { get; set; }

        public int IdCliente { get; set; }

        [DisplayName("Técnico Atendimento")]
        public string NomeTecnico { get; set; }

        [DisplayName("Data Preenchimento")]
        public DateTime? DataPreenchimento { get; set; }

        [DisplayName("Chegada")]
        //[Required(ErrorMessage = "Preencha a hora de chegada")]
        public string HoraChegada { get; set; }

        [DisplayName("Inicio")]
        //[Required(ErrorMessage = "Preencha a hora de início")]
        public string HoraInicio { get; set; }

        [DisplayName("Término")]
        //[Required(ErrorMessage = "Preencha a hora de término")]
        public string HoraTermino { get; set; }

        [DisplayName("Saída")]
        //[Required(ErrorMessage = "Preencha a hora de saída")]
        public string HoraSaida { get; set; }

        public string Observacoes { get; set; }

        public int IdFuncionario { get; set; }

        public string Assinatura { get; set; }

        public int IdAnexo { get; set; }

        public IEnumerable<Anexo> Anexos { get; set; }


        public string EstadoControles { get; set; }

        //public virtual Cliente Cliente { get; set; }

        //public virtual IEnumerable<AnexoViewModel> Anexos { get; set; }

        //public virtual IEnumerable<ProdutosFalhadosViewModel> ProdutosFalhados { get; set; }
    }
}