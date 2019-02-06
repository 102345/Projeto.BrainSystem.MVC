using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrainSystem.OS.BLL.Interface;
using BrainSystem.OS.Domain.Entities;
using BrainSystem.OS.MVC.Filtro;
using BrainSystem.OS.MVC.ViewModels;

namespace BrainSystem.OS.MVC.Controllers
{
    public class CadastroPecasEqptoController : Controller
    {
        // GET: CadastroPecasEqpto

        //private readonly IPecaAplicadaBusiness _pecaaplicadaBusiness;
        //private readonly IRetiraEquipamentoBusiness _retiraequipamentoBusiness;
        //private readonly ISolicitacaoPecaBusiness _solicitacaopecaBusiness;
        //private readonly IProdutoBusiness _produtoBusiness;


        //public CadastroPecasEqptoController(IPecaAplicadaBusiness pecaplicadaBusiness,
        //                             IRetiraEquipamentoBusiness retiraequipamentoBusiness,
        //                             ISolicitacaoPecaBusiness solicitacaopecaBusiness, IProdutoBusiness produtoBusiness)
        //{

        //    _pecaaplicadaBusiness = pecaplicadaBusiness;
        //    _solicitacaopecaBusiness = solicitacaopecaBusiness;
        //    _retiraequipamentoBusiness = retiraequipamentoBusiness;
        //    _produtoBusiness = produtoBusiness;

        //}



        [FilterInformationOS]
        public ActionResult Index(int id)
        {
            ViewBag.Titulo = "Ordem de Serviço";
            ViewBag.NomeUsuario = "Cláudio";
            ViewBag.Cargo = "Técnico Campo";

            var pecasaplicadasViewModel = new List<PecasAplicadasViewModel>();
            var solicitacoespecasViewModel = new List<SolicitacoesPecasViewModel>();
            var retiradasequipamentosViewModel = new List<RetiradaEquipamentosViewModel>();

            //implementar suas chamadas de seus metodos aqui
            //var pecasaplicadas = _pecasaplicadasBusiness.ListarPecasAplicadas(int IdOrdemServico);
            //var pecasaplicadasViewModel = Mapper.Map<IEnumerable<PecaAplicada>, IEnumerable<PecasAplicadasViewModel>>(pecaaplicadas);

            //var solicitacoespecas = _solicitacaopecaBusiness.ListarSolicitacoesPecas(int IdOrdemServico);
            //var solicitacoespecasViewModel = Mapper.Map<IEnumerable<SolicitacaoPeca>, IEnumerable<SolicitacoesPecasViewModel>>(solicitacoespecas);

            //var retiradasequipamentos = _retiraequipamentoBusiness.ListarPecasAplicadas(int IdOrdemServico);
            //var retiradasequipamentosViewModel = Mapper.Map<IEnumerable<RetiraEquipamento>, IEnumerable<RetiradasEquipamentosViewModel>>(retiradasequipamentos);

            if (Session["pecasaplicadasViewModel"] != null)
            {
                pecasaplicadasViewModel = Session["pecasaplicadasViewModel"] as List<PecasAplicadasViewModel>;
            }
            else
            {
                pecasaplicadasViewModel = ListaPecasAplicadasMockup(id);
            }


            if (Session["solicitacoespecasViewModel"] != null)
            {
                solicitacoespecasViewModel = Session["solicitacoespecasViewModel"] as List<SolicitacoesPecasViewModel>;
            }
            else
            {
                solicitacoespecasViewModel = ListaSolicitacoesPecasMockup(id);
            }

                         //retiradasequipamentosViewModel

            if (Session["retiradasequipamentosViewModel"] != null)
            {
                retiradasequipamentosViewModel = Session["retiradasequipamentosViewModel"] as List<RetiradaEquipamentosViewModel>;
            }
            else
            {
                retiradasequipamentosViewModel = ListaRetiradasEqptosMockup(id);
            }




            Session["IdProdutoFalhado"] = id;

           

            Session["pecasaplicadasViewModel"] = pecasaplicadasViewModel;
            Session["solicitacoespecasViewModel"] = solicitacoespecasViewModel;
            Session["retiradasequipamentosViewModel"] = retiradasequipamentosViewModel;

            RetornarDadosProdutoFalhado(id);

            return View(pecasaplicadasViewModel);
        }

        private void RetornarDadosProdutoFalhado(int idProdutoFalhado)
        {
            var produtosfalhadosViewModel = Session["produtosfalhadosViewModel"] as List<ProdutosFalhadosViewModel>;

            var produtofalhadoViewModel = produtosfalhadosViewModel.Find(a => a.IdProdutoFalhado == idProdutoFalhado);

            ViewBag.IdProdutoFalhado = idProdutoFalhado;
            ViewBag.Produto = produtofalhadoViewModel.Produto;
            ViewBag.NumeroSerie = produtofalhadoViewModel.NumeroSerie;


        }


        public PartialViewResult ExibirCadastroPecaAplicadas()
        {


            var pecasaplicadasViewModel = new PecasAplicadasViewModel();

            //Implementar a chamada de seu método

            pecasaplicadasViewModel.IdProdutoFalhado = Convert.ToInt32(Session["IdProdutoFalhado"]);

            pecasaplicadasViewModel.Produtos = new SelectList(ListaProdutosMockup(), "IdProduto", "Descricao", pecasaplicadasViewModel.IdProduto);

            return PartialView("_CadastroPecaAplicada", pecasaplicadasViewModel);



        }


        public PartialViewResult ExibirCadastroSolicitacaoPeca()
        {

            var solicitacoespecasViewModel = new SolicitacoesPecasViewModel();

            //Implementar a chamada de seu método
            solicitacoespecasViewModel.IdProdutoFalhado = Convert.ToInt32(Session["IdProdutoFalhado"]);

            solicitacoespecasViewModel.Produtos = new SelectList(ListaProdutosMockup(), "IdProduto", "Descricao", solicitacoespecasViewModel.IdProduto);

            return PartialView("_CadastroSolicitacaoPeca", solicitacoespecasViewModel);

        }


        public PartialViewResult ExibirCadastroRetiradaEquipamento()
        {

            var retiradaequipamentoViewModel = new RetiradaEquipamentosViewModel();

            //Implementar a chamada de seu método
            retiradaequipamentoViewModel.IdProdutoFalhado = Convert.ToInt32(Session["IdProdutoFalhado"]);

            retiradaequipamentoViewModel.Produtos = new SelectList(ListaProdutosMockup(), "IdProduto", "Descricao", retiradaequipamentoViewModel.IdProduto);

            return PartialView("_CadastroRetiradaEquipamento", retiradaequipamentoViewModel);

        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GravarPecaAplicada(PecasAplicadasViewModel pecaaplicadaViewModel)
        {

             List<PecasAplicadasViewModel> pecasaplicadasViewModel = Session["pecasaplicadasViewModel"] as List<PecasAplicadasViewModel>;

             //Implementar sua chamada de método
             //var produto = _produtoBusiness.GetById(pecaaplicadaViewModel.IdProduto);

             var produto = ProdutoGetIdMockup(pecaaplicadaViewModel.IdProduto);

             int IdProdutoFalhado = Convert.ToInt32(Session["IdProdutoFalhado"]);

             //Dados de Mockup
             Random rnd = new Random();
             pecaaplicadaViewModel.IdProdutoFalhado = IdProdutoFalhado;
             pecaaplicadaViewModel.Id = rnd.Next(10, 40);
             pecaaplicadaViewModel.Produto = produto.Descricao;

            


             pecasaplicadasViewModel.Add(pecaaplicadaViewModel);

             Session["pecasaplicadasViewModel"] = pecasaplicadasViewModel;

             return RedirectToAction("Index", "CadastroPecasEqpto",new { id = IdProdutoFalhado });


        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GravarSolicitacaoPeca(SolicitacoesPecasViewModel solicitacaopecaViewModel)
        {

            List<SolicitacoesPecasViewModel> solicitacoespecasViewModel = Session["solicitacoespecasViewModel"] as List<SolicitacoesPecasViewModel>;

            //Implementar sua chamada de método
            //var produto = _produtoBusiness.GetById(pecaaplicadaViewModel.IdProduto);

            var produto = ProdutoGetIdMockup(solicitacaopecaViewModel.IdProduto);

            int IdProdutoFalhado = Convert.ToInt32(Session["IdProdutoFalhado"]);

            //Dados de Mockup
            Random rnd = new Random();
            solicitacaopecaViewModel.IdProdutoFalhado = IdProdutoFalhado;
            solicitacaopecaViewModel.Id = rnd.Next(10, 40);
            solicitacaopecaViewModel.Produto = produto.Descricao;




            solicitacoespecasViewModel.Add(solicitacaopecaViewModel);

            Session["solicitacoespecasViewModel"] = solicitacoespecasViewModel;

            return RedirectToAction("Index", "CadastroPecasEqpto", new { id = IdProdutoFalhado });


        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GravarRetiradaEquipamento(RetiradaEquipamentosViewModel retiradaequipamentoViewModel)
        {

            List<RetiradaEquipamentosViewModel> retiradasequipamentosViewModel = Session["retiradasequipamentosViewModel"] as List<RetiradaEquipamentosViewModel>;

            //Implementar sua chamada de método
            //var produto = _produtoBusiness.GetById(pecaaplicadaViewModel.IdProduto);

            var produto = ProdutoGetIdMockup(retiradaequipamentoViewModel.IdProduto);

            int IdProdutoFalhado = Convert.ToInt32(Session["IdProdutoFalhado"]);

            //Dados de Mockup
            Random rnd = new Random();
            retiradaequipamentoViewModel.IdProdutoFalhado = IdProdutoFalhado;
            retiradaequipamentoViewModel.Id = rnd.Next(10, 40);
            retiradaequipamentoViewModel.Produto = produto.Descricao;




            retiradasequipamentosViewModel.Add(retiradaequipamentoViewModel);

            Session["retiradasequipamentosViewModel"] = retiradasequipamentosViewModel;

            return RedirectToAction("Index", "CadastroPecasEqpto", new { id = IdProdutoFalhado });


        }





        // GET: CadastroPecasEqpto/Delete/5
        public ActionResult Delete(int id)
        {

            int IdProdutoFalhado = Convert.ToInt32(Session["IdProdutoFalhado"]);


            var pecaspalicadasViewModel = new List<PecasAplicadasViewModel>();

            if (Session["pecasaplicadasViewModel"] != null)
            {
                pecaspalicadasViewModel = Session["pecasaplicadasViewModel"] as List<PecasAplicadasViewModel>;
            }
            else
            {
                //implementar suas chamadas de seus metodos aqui
                //var pecasaplicadas = _pecasaplicadasBusiness.ListarPecasAplicadas(int IdOrdemServico);
                //pecasaplicadasViewModel = Mapper.Map<IEnumerable<PecaAplicada>, IEnumerable<PecasAplicadasViewModel>>(pecaaplicadas);

                pecaspalicadasViewModel = ListaPecasAplicadasMockup(IdProdutoFalhado);
            }

            var pecaaplicadaViewModel = pecaspalicadasViewModel.Find(a => a.Id == id);

            pecaspalicadasViewModel.Remove(pecaaplicadaViewModel);

            Session["pecasaplicadasViewModel"] = pecaspalicadasViewModel;

            return RedirectToAction("Index", "CadastroPecasEqpto", new { id = IdProdutoFalhado });
        }


        public ActionResult DeleteSolicitacaoPeca(int id)
        {

            int IdProdutoFalhado = Convert.ToInt32(Session["IdProdutoFalhado"]);


            var solicitacoespecasViewModel = new List<SolicitacoesPecasViewModel>();

            if (Session["solicitacoespecasViewModel"] != null)
            {
                solicitacoespecasViewModel = Session["solicitacoespecasViewModel"] as List<SolicitacoesPecasViewModel>;
            }
            else
            {
                //implementar suas chamadas de seus metodos aqui
                //var solicitacoespecas = _retiraequipamentoBusiness.ListarSolicitacoesPecas(int IdOrdemServico);
                //solicitacoespecasViewModel = Mapper.Map<IEnumerable<SolicitacaoPeca>, IEnumerable<SolicitacoesPecasViewModel>>(solicitacoespecas);

                solicitacoespecasViewModel = ListaSolicitacoesPecasMockup(IdProdutoFalhado);
            }

            var solicitacapecaViewModel = solicitacoespecasViewModel.Find(a => a.Id == id);

            solicitacoespecasViewModel.Remove(solicitacapecaViewModel);

            Session["solicitacoespecasViewModel"] = solicitacoespecasViewModel;

            return RedirectToAction("Index", "CadastroPecasEqpto", new { id = IdProdutoFalhado });
        }



        public ActionResult DeleteRetiradaEquipamento(int id)
        {

            int IdProdutoFalhado = Convert.ToInt32(Session["IdProdutoFalhado"]);


            var retiradasequipamentosViewModel = new List<RetiradaEquipamentosViewModel>();

            if (Session["retiradasequipamentosViewModel"] != null)
            {
                retiradasequipamentosViewModel = Session["retiradasequipamentosViewModel"] as List<RetiradaEquipamentosViewModel>;
            }
            else
            {
                //implementar suas chamadas de seus metodos aqui
                //var retiradas = _retiraequipamentoBusiness.ListarRetiradasEquipamentos(int IdOrdemServico);
                //retiradasequipamentosViewModel = Mapper.Map<IEnumerable<RetiraEquipamento>, IEnumerable<RetiradaEquipamentosViewModel>>(retiradas);

                retiradasequipamentosViewModel = ListaRetiradasEqptosMockup(IdProdutoFalhado);
            }

            var retiradaequipamentoViewModel = retiradasequipamentosViewModel.Find(a => a.Id == id);

            retiradasequipamentosViewModel.Remove(retiradaequipamentoViewModel);

            Session["retiradasequipamentosViewModel"] = retiradasequipamentosViewModel;

            return RedirectToAction("Index", "CadastroPecasEqpto", new { id = IdProdutoFalhado });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult EnviarDadosComplementares()
        {

            return RedirectToAction("DadosComplementaresOS", "OrdemServico");


        }


        



        private List<PecasAplicadasViewModel> ListaPecasAplicadasMockup(int IdProdutoFalhado)
        {


            List<PecasAplicadasViewModel> pecasaplicadas = new List<PecasAplicadasViewModel>();

           

            if(IdProdutoFalhado == 1)
            {
                PecasAplicadasViewModel peca1 = new PecasAplicadasViewModel();
                peca1.Id = 1;
                peca1.IdProdutoFalhado = IdProdutoFalhado;
                peca1.IdProduto = 1;
                peca1.Produto = "Produto1";
                peca1.NumeroSerie = "Serie1";
                peca1.Quantidade = 3;

                pecasaplicadas.Add(peca1);


            }
            else
            {
                PecasAplicadasViewModel peca2 = new PecasAplicadasViewModel();

                peca2.Id = 1;
                peca2.IdProdutoFalhado = 2;
                peca2.IdProduto = 2;
                peca2.Produto = "Produto2";
                peca2.NumeroSerie = "Serie2";
                peca2.Quantidade = 5;

                pecasaplicadas.Add(peca2);


            }   

            return pecasaplicadas;

        }



        private List<SolicitacoesPecasViewModel> ListaSolicitacoesPecasMockup(int IdProdutoFalhado)
        {


            List<SolicitacoesPecasViewModel> solicitacoes = new List<SolicitacoesPecasViewModel>();



            if (IdProdutoFalhado == 1)
            {
                SolicitacoesPecasViewModel peca1 = new SolicitacoesPecasViewModel();
                peca1.Id = 1;
                peca1.IdProdutoFalhado = IdProdutoFalhado;
                peca1.IdProduto = 1;
                peca1.Produto = "Produto1";
                peca1.Quantidade = 20;

                solicitacoes.Add(peca1);


            }
            else
            {
                SolicitacoesPecasViewModel peca2 = new SolicitacoesPecasViewModel();

                peca2.Id = 1;
                peca2.IdProdutoFalhado = 2;
                peca2.IdProduto = 2;
                peca2.Produto = "Produto2";
                peca2.Quantidade = 30;

                solicitacoes.Add(peca2);


            }

            return solicitacoes;

        }


        private List<RetiradaEquipamentosViewModel> ListaRetiradasEqptosMockup(int IdProdutoFalhado)
        {


            List<RetiradaEquipamentosViewModel> retiradas = new List<RetiradaEquipamentosViewModel>();



            if (IdProdutoFalhado == 1)
            {
                RetiradaEquipamentosViewModel retirada1 = new RetiradaEquipamentosViewModel();
                retirada1.Id = 1;
                retirada1.IdProdutoFalhado = IdProdutoFalhado;
                retirada1.IdProduto = 1;
                retirada1.Produto = "Produto1";
                retirada1.NumeroSerie = "Serie1";

                retiradas.Add(retirada1);


            }
            else
            {
                RetiradaEquipamentosViewModel retirada2 = new RetiradaEquipamentosViewModel();

                retirada2.Id = 1;
                retirada2.IdProdutoFalhado = 2;
                retirada2.IdProduto = 2;
                retirada2.Produto = "Produto2";
                retirada2.NumeroSerie = "Serie2";

                retiradas.Add(retirada2);


            }

            return retiradas;

        }



        private List<Produto> ListaProdutosMockup()
        {
            List<Produto> produtos = new List<Produto>();

            Produto produto1 = new Produto();

            produto1.IdProduto = 1;
            produto1.Descricao = "Produto1";

            produtos.Add(produto1);

            Produto produto2 = new Produto();

            produto2.IdProduto = 2;
            produto2.Descricao = "Produto2";

            produtos.Add(produto2);

            return produtos;
        }


        private Produto ProdutoGetIdMockup(int id)
        {
            Produto produto = new Produto();

            if (id == 1)
            {

                produto.IdProduto = 1;
                produto.Descricao = "Produto1";
            }

            if (id == 2)
            {

                produto.IdProduto = 2;
                produto.Descricao = "Produto2";
            }


            return produto;
        }



    }
}
