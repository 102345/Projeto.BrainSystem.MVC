using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;

namespace BrainSystem.OS.MVC.ViewModels
{
    public class RetiradaEquipamentosViewModel
    {
        public int Id { get; set; }

        public int IdProdutoFalhado { get; set; }

        [DisplayName("Código")]
        public int IdProduto { get; set; }
        public string Produto { get; set; }

        [DisplayName("Número Série")]
        public string NumeroSerie { get; set; }


        public virtual IEnumerable<SelectListItem> Produtos { get; set; }

    }
}