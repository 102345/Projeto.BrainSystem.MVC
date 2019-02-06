using BrainSystem.OS.MVC.ViewModels;
using System;
using System.Web;
using System.Web.Mvc;

namespace BrainSystem.OS.MVC.Filtro
{
    public class FilterInformationOS : ActionFilterAttribute, IActionFilter
    {

        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {

            filterContext.Controller.ViewBag.OrdemServico = RetornarOrdemServico(filterContext);
            filterContext.Controller.ViewBag.DataChamado  = RetornarDataChamado(filterContext);
            filterContext.Controller.ViewBag.NroChamado= RetornarNroChamado(filterContext);
            filterContext.Controller.ViewBag.EstadoControles = RetornarEstadoControles(filterContext);

        }

        void IActionFilter.OnActionExecuted(ActionExecutedContext filterContext)
        {
            
        }

        private string RetornarEstadoControles(ActionExecutingContext filterContex)
        {
            var estadocontrole = (string)HttpContext.Current.Session["fechamentoOS"];

            return estadocontrole;


        }


        private double RetornarOrdemServico(ActionExecutingContext filterContext)
        {

            var ordemservico = (OrdemServicoViewModel)HttpContext.Current.Session["ordemservicoViewModel"];

            return ordemservico.IdOrdemServico;


        }


        private DateTime RetornarDataChamado(ActionExecutingContext filterContext)
        {

            var ordemservico = (OrdemServicoViewModel)HttpContext.Current.Session["ordemservicoViewModel"];

            return ordemservico.DataChamado;


        }


        private int RetornarNroChamado(ActionExecutingContext filterContext)
        {

            var ordemservico = (OrdemServicoViewModel)HttpContext.Current.Session["ordemservicoViewModel"];

            return ordemservico.NumeroChamado;


        }




    }
}