using AutoMapper;
using BrainSystem.OS.Domain.Entities;
using BrainSystem.OS.MVC.ViewModels;
using BrainSystem.OS.BLL.Interface;
using System.Web.Mvc;
using System.Collections.Generic;

namespace BrainSystem.OS.MVC.Controllers
{
    public class ClienteController : Controller
    {
        //private readonly IClienteBusiness _clienteBusiness;
        //private readonly IFuncionarioBusiness _funcionarioBusiness;
       

        //public ClienteController(IClienteBusiness clienteBusiness,IFuncionarioBusiness funcionarioBusiness)
        //{
        //    _clienteBusiness = clienteBusiness;
        //    _funcionarioBusiness = funcionarioBusiness;
        //}

        // GET: Cliente
        public ActionResult Index()
        {
            var teste = Server.MapPath("MyFirstPDF.pdf");
            return View();
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
