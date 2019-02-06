using BrainSystem.OS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BrainSystem.OS.MVC.ViewModels
{
    public class ClienteViewModel
    {
        public int IdCliente { get; set; }

        public string NomeFantasia { get; set; }

        public string RazaoSocial { get; set; }

        public string CNPJ { get; set; }

        public int IdGrupo { get; set; }

        public Funcionario Funcionario {get;set;}

        public Endereco Endereco { get; set; }


        public virtual IEnumerable<SelectListItem> Funcionarios { get; set; }

    }
}