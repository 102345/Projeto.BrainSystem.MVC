using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;
using BrainSystem.OS.Domain.Entities;

namespace BrainSystem.OS.MVC.ViewModels
{
    public class ProdutosFalhadosViewModel
    {
        public decimal IdProdutoFalhado { get; set; }

        [DisplayName("Código")]
        public int IdProduto { get; set; }

        [DisplayName("Produto")]
        public string Produto { get; set; }

        [DisplayName("Número da Série")]
        public string NumeroSerie { get; set; }


        public int IdOrdemServico { get; set; }

        public int IdLocalizacao { get; set; }

        [DisplayName("Localização da Falha")]
        public string Localizacao { get; set; }

        public int IdDetalhamentoFalha { get; set; }

        [DisplayName("Detalhamento da Falha")]
        public string DetalhamentoFalha { get; set; }

        public int IdAcaoCorretiva { get; set; }

        [DisplayName("Ação Corretiva")]
        public string AcaoCorretiva { get; set; }

        public int IdSolucaoAdotada { get; set; }

        [DisplayName("Solução Adotada")]
        public string SolucaoAdotada { get; set; }

        [DisplayName("Status Funcionamento")]
        public bool StatusFuncionamento { get; set; }

        //public virtual OrdemServico OrdemServico { get; set; }

        public virtual IEnumerable<Produto> Produtos { get; set; }

        public virtual IEnumerable<SelectListItem> LocalizacoesFalhas { get; set; }

        public virtual IEnumerable<SelectListItem> DetalhamentosFalhas { get; set; }

        public virtual IEnumerable<SelectListItem> AcoesCorretivas { get; set; }

        public virtual IEnumerable<SelectListItem> SolucoesAdotadas { get; set; }

        // public virtual IEnumerable<LocalizacaoFalha> LocalizacoesFalhas { get; set; }

        //public virtual IEnumerable<RetiraEquipamento> RetiraEquipamentos { get; set; }

        //public virtual IEnumerable<PecaAplicada> PecasAplicadas { get; set; }
    }
}