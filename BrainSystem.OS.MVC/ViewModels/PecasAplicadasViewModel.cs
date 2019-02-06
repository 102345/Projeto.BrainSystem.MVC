using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BrainSystem.OS.MVC.ViewModels
{
    public class PecasAplicadasViewModel
    {
       
        public int Id { get; set; }

        public int IdProdutoFalhado { get; set; }

        [DisplayName("Código")]
        public int IdProduto { get; set; }
        public string Produto { get; set; }

        public int Quantidade { get; set; }

        [DisplayName("Número Série")]
        public string NumeroSerie { get; set; }

        public virtual IEnumerable<SelectListItem> Produtos { get; set; }

        //public IEnumerable<SolicitacoesPecasViewModel> SolicitacoesPecasDetalhes;

    }
}