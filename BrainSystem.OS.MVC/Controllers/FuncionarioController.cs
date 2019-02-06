using BrainSystem.OS.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrainSystem.OS.Domain.Entities;
using AutoMapper;

namespace BrainSystem.OS.MVC.Controllers
{
    public class FuncionarioController : Controller
    {

        //private readonly IClienteBusiness _clienteBusiness;
        //private readonly IFuncionarioBusiness _funcionarioBusiness;


        //public ClienteController(IClienteBusiness clienteBusiness,IFuncionarioBusiness funcionarioBusiness)
        //{
        //    _clienteBusiness = clienteBusiness;
        //    _funcionarioBusiness = funcionarioBusiness;
        //}


        // GET: Funcionario
        public ActionResult Index()
        {
            //var teste = ViewBag.OrdemServico;



            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GravarFuncionario(FuncionarioViewModel funcionarioViewModel)
        {
            var cliente = Session["cliente"] as Cliente;
            var ordemservicoViewModelOrigem = Session["ordemservicoViewModel"] as OrdemServicoViewModel;


            var funcionario = Mapper.Map<FuncionarioViewModel,Funcionario>(funcionarioViewModel);


            funcionario.IdCliente = cliente.IdCliente;

            Random rnd = new Random();
            //Dado Mockup
            //Implementar seu identificador de objeto 
            funcionario.IdFuncionario = rnd.Next(10, 40);

            List<Funcionario> funcionarios = cliente.Funcionarios.ToList();

            funcionarios.Add(funcionario);

            cliente.Funcionarios = funcionarios;

            Session["cliente"] = cliente;

            ordemservicoViewModelOrigem.IdFuncionario = funcionario.IdFuncionario;

            Session["ordemservicoViewModel"] = ordemservicoViewModelOrigem;


            return RedirectToAction("ClienteResponsavel","OrdemServico");
            

        }




        private List<FuncionarioViewModel> ListaFuncionariosMockup()
        {


            List<FuncionarioViewModel> funcionarios = new List<FuncionarioViewModel>();


            FuncionarioViewModel funcionario1 = new FuncionarioViewModel();
            funcionario1.IdCliente = 1;
            funcionario1.Nome = "Funcionario1 da Silva";
            funcionario1.RG = "999999-99";
            funcionario1.Cargo = "Cargo1";
            funcionario1.Telefone = "(99)9999-9999";

            funcionarios.Add(funcionario1);



            FuncionarioViewModel funcionario2 = new FuncionarioViewModel();

            funcionario2.IdCliente = 1;
            funcionario2.Nome = "Funcionario2 da Silva";
            funcionario2.RG = "999999-99";
            funcionario2.Cargo = "Cargo2";
            funcionario2.Telefone = "(99)9999-9999";

            funcionarios.Add(funcionario2);



            return funcionarios;

        }



    }
}
