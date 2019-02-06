using System.Web.Mvc;
using AutoMapper;
using BrainSystem.OS.Domain.Entities;
using BrainSystem.OS.MVC.ViewModels;
using BrainSystem.OS.BLL.Interface;
using BrainSystem.OS.MVC.Filtro;
using System.Collections.Generic;
using System;
using System.Linq;

namespace BrainSystem.OS.MVC.Controllers
{
    public class FluxoAtendimentoController : Controller
    {
        // GET: FluxoAtendimento

        //Descomentar esta linhas para integração com DI

        //private readonly IProdutoFalhadoBusiness _produtofalhadoBusiness;
        //private readonly IProdutoBusiness _produtoBusiness;
        //private readonly ILocalizacaoFalhaBusiness _localizacaofalhaBusiness;
        //private readonly IDetalhamentoFalhaBusiness _detalhamentofalhaBusiness;
        //private readonly IAcaoCorretivaBusiness _acaocorretivaBusiness;
        //private readonly ISolucaoAdotadaBusiness _solucaoadotadaBusiness;



        //public FluxoAtendimentoController(IProdutoFalhadoBusiness produtofalhadoBusiness,
        //                                  IProdutoBusiness produtoBusiness, ILocalizacaoFalhaBusiness localizacaofalhaBusiness,
        //                                  IDetalhamentoFalhaBusiness detalhamentofalhaBusiness, IAcaoCorretivaBusiness acaocorretivaBusiness,
        //                                  ISolucaoAdotadaBusiness solucaoadotadaBusiness)
        //{
        //    _produtofalhadoBusiness = produtofalhadoBusiness;
        //    _produtoBusiness = produtoBusiness;
        //    _localizacaofalhaBusiness = localizacaofalhaBusiness;
        //    _detalhamentofalhaBusiness = detalhamentofalhaBusiness;
        //    _acaocorretivaBusiness = acaocorretivaBusiness;
        //    _solucaoadotadaBusiness = solucaoadotadaBusiness;
        //}


        [FilterInformationOS]
        public ActionResult Index()
        {
            ViewBag.Titulo = "Ordem de Serviço";
            ViewBag.NomeUsuario = "Cláudio";
            ViewBag.Cargo = "Técnico Campo";

           

            var produtosfalhadosViewModel = new List<ProdutosFalhadosViewModel>();

            if(Session["produtosfalhadosViewModel"] != null)
            {
                produtosfalhadosViewModel = Session["produtosfalhadosViewModel"] as List<ProdutosFalhadosViewModel>;
            }
            else
            {
                //Implementar seus metodos 
                //var produtosfalhados = _produtofalhadoBusiness.ListarProdutosFalhados(int IdOrdemServico);

                //produtosfalhadosViewModel = Mapper.Map<IEnumerable<ProdutoFalhado>, IEnumerable<ProdutosFalhadosViewModel>>(produtosfalhados);

                produtosfalhadosViewModel = ListaProdutosFalhadosMockup();
            }

            Session["produtosfalhadosViewModel"] = produtosfalhadosViewModel;

            return View(produtosfalhadosViewModel);

        }


        public PartialViewResult ExibirCadastroProdutosFalhados()
        {


            var produtoFalhadoViewModel = new ProdutosFalhadosViewModel();

            //Implementar a chamada de seu método
            //ViewBag.IdProduto = new SelectList(_produtoBusiness.GetAll(), "IdProduto", "Descricao", produtoFalhadoViewModel.IdProduto);

            ViewBag.IdProduto = new SelectList(ListaProdutosMockup(), "IdProduto", "Descricao",produtoFalhadoViewModel.IdProduto);



            return PartialView("_CadastroProdutosFalhados2",produtoFalhadoViewModel);



        }


        public PartialViewResult ExibirListaLocalizacaoFalha(int idProduto)
        {


            var produtoFalhadoViewModel = new ProdutosFalhadosViewModel();

            //Implementar a chamada de seu método

            // produtoFalhadoViewModel.LocalizacoesFalhas = new SelectList(_localizacaofalhaBusiness.ListarLocalizacoesFalhas(idProduto), "IdLocalizacao", "Descricao", produtoFalhadoViewModel.IdLocalizacao);

            produtoFalhadoViewModel.LocalizacoesFalhas = new SelectList(ListaLocalizacaoFalhaMockup(idProduto), "IdLocalizacao", "Descricao", produtoFalhadoViewModel.IdLocalizacao);

            return PartialView("_CadastroProdFalhaLocalizacao", produtoFalhadoViewModel);



        }

        public PartialViewResult ExibirListaDelhamentoFalha(int idProduto)
        {


            var produtoFalhadoViewModel = new ProdutosFalhadosViewModel();

            //Implementar a chamada de seu método

            // produtoFalhadoViewModel.DetalhamentosFalhas = new SelectList(_detalhamentofalhaBusiness.ListarDetalhamentosFalhas(idProduto), "IdDetalhamentoFalha", "Descricao", produtoFalhadoViewModel.IdDetalhamentoFalha);

            produtoFalhadoViewModel.DetalhamentosFalhas = new SelectList(ListaDetalhamentoFalhaMockup(idProduto), "IdDetalhamentoFalha", "Descricao", produtoFalhadoViewModel.IdDetalhamentoFalha);

            return PartialView("_CadastroProdFalhaDetalhamento", produtoFalhadoViewModel);



        }


        public PartialViewResult ExibirListaAcoesCorretivas(int idProduto)
        {


            var produtoFalhadoViewModel = new ProdutosFalhadosViewModel();

            //Implementar a chamada de seu método

            // produtoFalhadoViewModel.AcoesCorretivas = new SelectList(_detalhamentofalhaBusiness.ListarAcoesCorretivas(idProduto), "IdAcaoCorretiva", "Descricao", produtoFalhadoViewModel.IdAcaoCorretiva);

            produtoFalhadoViewModel.AcoesCorretivas = new SelectList(ListaAcoesCorretivasMockup(idProduto), "IdAcaoCorretiva", "Descricao", produtoFalhadoViewModel.IdAcaoCorretiva);

            return PartialView("_CadastroProdFalhaAcaoCorretiva", produtoFalhadoViewModel);



        }


        public PartialViewResult ExibirListaSolucoesAdotadas(int idProduto)
        {


            var produtoFalhadoViewModel = new ProdutosFalhadosViewModel();

            //Implementar a chamada de seu método

            // produtoFalhadoViewModel.SolucoesAdotadas = new SelectList(_detalhamentofalhaBusiness.ListarSolucoesAdotadas(idProduto), "IdSolucaoAdotada", "Descricao", produtoFalhadoViewModel.IdSolucaoAdotada);

            produtoFalhadoViewModel.SolucoesAdotadas = new SelectList(ListaSolucoesAdotadasMockup(idProduto), "IdSolucaoAdotada", "Descricao", produtoFalhadoViewModel.IdSolucaoAdotada);

            return PartialView("_CadastroProdFalhaSolucaoAdotada", produtoFalhadoViewModel);



        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GravarProdutoFalhado(ProdutosFalhadosViewModel produtofalhadoViewModel)
        {

            List<ProdutosFalhadosViewModel> produtosfalhadosViewModel = Session["produtosfalhadosViewModel"] as List<ProdutosFalhadosViewModel>;

            var produto = ProdutoGetIdMockup(produtofalhadoViewModel.IdProduto);
            var acao= AcaoGetIdMockup(produtofalhadoViewModel.IdAcaoCorretiva);
            var solucao = SolucaoAdotadaGetIdMockup(produtofalhadoViewModel.IdSolucaoAdotada);
            var detalhe = DetalhamentoFalhaGetIdMockup(produtofalhadoViewModel.IdDetalhamentoFalha);
            var localizacao = LocalizacaoFalhaGetIdMockup(produtofalhadoViewModel.IdLocalizacao);

            Random rnd = new Random();
            produtofalhadoViewModel.IdProdutoFalhado = rnd.Next(10, 40);
            produtofalhadoViewModel.Produto = produto.Descricao;
            produtofalhadoViewModel.AcaoCorretiva = acao.Descricao;
            produtofalhadoViewModel.Localizacao = localizacao.Descricao;
            produtofalhadoViewModel.DetalhamentoFalha = detalhe.Descricao;
            produtofalhadoViewModel.SolucaoAdotada = solucao.Descricao;


            produtosfalhadosViewModel.Add(produtofalhadoViewModel);

            Session["produtosfalhadosViewModel"] = produtosfalhadosViewModel;

            return RedirectToAction("Index", "FluxoAtendimento");


        }


        // GET: Teste/Delete/5
        public ActionResult Delete(int id)
        {
          
            var produtosfalhadosViewModel = new List<ProdutosFalhadosViewModel>();

            if (Session["produtosfalhadosViewModel"] != null)
            {
                produtosfalhadosViewModel = Session["produtosfalhadosViewModel"] as List<ProdutosFalhadosViewModel>;
            }
            else
            {
                produtosfalhadosViewModel = ListaProdutosFalhadosMockup();
            }

            var produtofalhadoViewModel = produtosfalhadosViewModel.Find(a => a.IdProdutoFalhado == id);

            produtosfalhadosViewModel.Remove(produtofalhadoViewModel);

            Session["produtosfalhadosViewModel"] = produtosfalhadosViewModel;

            return RedirectToAction("Index", "FluxoAtendimento");


        }


        public ActionResult ExibirCadastrosPecasEqpto(int id)
        {
            var produtosfalhadosViewModel = Session["produtosfalhadosViewModel"] as List<ProdutosFalhadosViewModel>;

            var produtofalhadoViewModel = produtosfalhadosViewModel.Find(a => a.IdProdutoFalhado == id);

            Session["produtofalhadoViewModel"] = produtofalhadoViewModel;



            return RedirectToAction("Index", "CadastroPecasEqpto",new { id = produtofalhadoViewModel.IdProdutoFalhado });

        }

        #region Dados Mockup

        private List<LocalizacaoFalha>ListaLocalizacaoFalhaMockup(int IdProduto)
        {
            List<LocalizacaoFalha> localizacoes = new List<LocalizacaoFalha>();

            if(IdProduto == 1)
            {

                LocalizacaoFalha local0 = new LocalizacaoFalha();

                local0.IdProduto = IdProduto;
                local0.IdLocalizacao = 0;
                local0.Descricao = "";

                localizacoes.Add(local0);

                LocalizacaoFalha local1 = new LocalizacaoFalha();

                local1.IdProduto = IdProduto;
                local1.IdLocalizacao = 1;
                local1.Descricao = "Loc1";


                localizacoes.Add(local1);

                LocalizacaoFalha local2 = new LocalizacaoFalha();

                local2.IdProduto = IdProduto;
                local2.IdLocalizacao = 2;
                local2.Descricao = "Loc2";

                localizacoes.Add(local2);

            }
            else
            {

                 
                LocalizacaoFalha local0 = new LocalizacaoFalha();

                local0.IdProduto = IdProduto;
                local0.IdLocalizacao = 0;
                local0.Descricao = "";

                localizacoes.Add(local0);


                LocalizacaoFalha local3 = new LocalizacaoFalha();

                local3.IdProduto = IdProduto;
                local3.IdLocalizacao =3;
                local3.Descricao = "Loc3";

                localizacoes.Add(local3);

                LocalizacaoFalha local4 = new LocalizacaoFalha();

                local4.IdProduto = IdProduto;
                local4.IdLocalizacao = 4;
                local4.Descricao = "Loc4";

                localizacoes.Add(local4);

            }

            return localizacoes;

        }




        private List<DetalhamentoFalha> ListaDetalhamentoFalhaMockup(int IdProduto)
        {
            List<DetalhamentoFalha> detalhes = new List<DetalhamentoFalha>();

            if (IdProduto == 1)
            {

                DetalhamentoFalha local0 = new DetalhamentoFalha();

                local0.IdProduto = IdProduto;
                local0.IdLocalizacao = 0;
                local0.Descricao = "";

                detalhes.Add(local0);

                DetalhamentoFalha local1 = new DetalhamentoFalha();

                local1.IdProduto = IdProduto;
                local1.IdLocalizacao = 1;
                local1.Descricao = "Detalhe1";


                detalhes.Add(local1);

                DetalhamentoFalha local2 = new DetalhamentoFalha();

                local2.IdProduto = IdProduto;
                local2.IdLocalizacao = 2;
                local2.Descricao = "Detalhe2";

                detalhes.Add(local2);

            }
            else
            {


                DetalhamentoFalha local0 = new DetalhamentoFalha();

                local0.IdProduto = IdProduto;
                local0.IdLocalizacao = 0;
                local0.Descricao = "";

                detalhes.Add(local0);


                DetalhamentoFalha local3 = new DetalhamentoFalha();

                local3.IdProduto = IdProduto;
                local3.IdLocalizacao = 3;
                local3.Descricao = "Detalhe3";

                detalhes.Add(local3);

                DetalhamentoFalha local4 = new DetalhamentoFalha();

                local4.IdProduto = IdProduto;
                local4.IdLocalizacao = 4;
                local4.Descricao = "Detalhe4";

                detalhes.Add(local4);

            }

            return detalhes;

        }



        private List<AcaoCorretiva> ListaAcoesCorretivasMockup(int IdProduto)
        {
            List<AcaoCorretiva> acoes = new List<AcaoCorretiva>();

            if (IdProduto == 1)
            {

                AcaoCorretiva acao0 = new AcaoCorretiva();

                acao0.IdProduto = IdProduto;
                acao0.IdAcaoCorretiva = 0;
                acao0.Descricao = "";

                acoes.Add(acao0);

                AcaoCorretiva acao1 = new AcaoCorretiva();

                acao1.IdProduto = IdProduto;
                acao1.IdAcaoCorretiva = 1;
                acao1.Descricao = "Acao1";


                acoes.Add(acao1);

                AcaoCorretiva acao2 = new AcaoCorretiva();

                acao2.IdProduto = IdProduto;
                acao2.IdAcaoCorretiva = 2;
                acao2.Descricao = "Acao2";

                acoes.Add(acao2);

            }
            else
            {


                AcaoCorretiva acao0 = new AcaoCorretiva();

                acao0.IdProduto = IdProduto;
                acao0.IdAcaoCorretiva = 0;
                acao0.Descricao = "";

                acoes.Add(acao0);


                AcaoCorretiva acao3 = new AcaoCorretiva();

                acao3.IdProduto = IdProduto;
                acao3.IdAcaoCorretiva = 3;
                acao3.Descricao = "Acao3";

                acoes.Add(acao3);

                AcaoCorretiva acao4 = new AcaoCorretiva();

                acao4.IdProduto = IdProduto;
                acao4.IdAcaoCorretiva = 4;
                acao4.Descricao = "Acao4";

                acoes.Add(acao4);

            }

            return acoes;

        }


        private List<SolucaoAdotada> ListaSolucoesAdotadasMockup(int IdProduto)
        {
            List<SolucaoAdotada> solucoes = new List<SolucaoAdotada>();

            if (IdProduto == 1)
            {

                SolucaoAdotada solucao0 = new SolucaoAdotada();

                solucao0.IdProduto = IdProduto;
                solucao0.IdSolucaoAdotada = 0;
                solucao0.Descricao = "";

                solucoes.Add(solucao0);

                SolucaoAdotada solucao1 = new SolucaoAdotada();

                solucao1.IdProduto = IdProduto;
                solucao1.IdSolucaoAdotada = 1;
                solucao1.Descricao = "solucao1";


                solucoes.Add(solucao1);

                SolucaoAdotada solucao2 = new SolucaoAdotada();

                solucao2.IdProduto = IdProduto;
                solucao2.IdSolucaoAdotada = 2;
                solucao2.Descricao = "solucao2";

                solucoes.Add(solucao2);

            }
            else
            {


                SolucaoAdotada solucao0 = new SolucaoAdotada();

                solucao0.IdProduto = IdProduto;
                solucao0.IdSolucaoAdotada = 0;
                solucao0.Descricao = "";

                solucoes.Add(solucao0);


                SolucaoAdotada solucao3 = new SolucaoAdotada();

                solucao3.IdProduto = IdProduto;
                solucao3.IdSolucaoAdotada = 3;
                solucao3.Descricao = "solucao3";

                solucoes.Add(solucao3);

                SolucaoAdotada solucao4 = new SolucaoAdotada();

                solucao4.IdProduto = IdProduto;
                solucao4.IdSolucaoAdotada = 4;
                solucao4.Descricao = "solucao4";

                solucoes.Add(solucao4);

            }

            return solucoes;

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


        private AcaoCorretiva AcaoGetIdMockup(int id)
        {
            AcaoCorretiva acao = new AcaoCorretiva();

            if(id == 1)
            {

                acao.IdAcaoCorretiva = 1;
                acao.Descricao = "Acao1";
            }

            if (id == 2)
            {

                acao.IdAcaoCorretiva = 2;
                acao.Descricao = "Acao2";
            }


            if (id == 3)
            {

                acao.IdAcaoCorretiva = 3;
                acao.Descricao = "Acao3";
            }

            if (id == 4)
            {

                acao.IdAcaoCorretiva = 4;
                acao.Descricao = "Acao4";
            }


            return acao;
        }



        private DetalhamentoFalha DetalhamentoFalhaGetIdMockup(int id)
        {
            DetalhamentoFalha detalhe = new DetalhamentoFalha();

            if (id == 1)
            {

                detalhe.IdDetalhamentoFalha = 1;
                detalhe.Descricao = "Acao1";
            }

            if (id == 2)
            {

                detalhe.IdDetalhamentoFalha = 2;
                detalhe.Descricao = "Acao2";
            }


            if (id == 3)
            {

                detalhe.IdDetalhamentoFalha = 3;
                detalhe.Descricao = "Acao3";
            }

            if (id == 4)
            {

                detalhe.IdDetalhamentoFalha = 4;
                detalhe.Descricao = "Acao4";
            }


            return detalhe;
        }


        private LocalizacaoFalha LocalizacaoFalhaGetIdMockup(int id)
        {
            LocalizacaoFalha local = new LocalizacaoFalha();

            if (id == 1)
            {

                local.IdLocalizacao = 1;
                local.Descricao = "Loc1";
            }

            if (id == 2)
            {

                local.IdLocalizacao = 2;
                local.Descricao = "loc2";
            }


            if (id == 3)
            {

                local.IdLocalizacao = 3;
                local.Descricao = "loc3";
            }

            if (id == 4)
            {

                local.IdLocalizacao = 4;
                local.Descricao = "loc4";
            }


            return local;
        }


        private SolucaoAdotada SolucaoAdotadaGetIdMockup(int id)
        {
            SolucaoAdotada solucao = new SolucaoAdotada();

            if (id == 1)
            {

                solucao.IdSolucaoAdotada = 1;
                solucao.Descricao = "solucao1";
            }

            if (id == 2)
            {

                solucao.IdSolucaoAdotada = 1;
                solucao.Descricao = "solucao2";
            }


            if (id == 3)
            {

                solucao.IdSolucaoAdotada = 1;
                solucao.Descricao = "solucao3";
            }

            if (id == 4)
            {

                solucao.IdSolucaoAdotada = 1;
                solucao.Descricao = "solucao4";
            }


            return solucao;
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




        private List<ProdutosFalhadosViewModel> ListaProdutosFalhadosMockup()
        {

            //ordemservico.IdOrdemServico = 512870;
            //ordemservico.DataChamado = System.DateTime.Now;
            //ordemservico.NumeroChamado = 974552;
            //ordemservico.NomeTecnico = "Claudio dos Santos";
            //ordemservico.IdCliente = 1;


            List<ProdutosFalhadosViewModel> produtosfalhados = new List<ProdutosFalhadosViewModel>();

            ProdutosFalhadosViewModel prd1 = new ProdutosFalhadosViewModel();

            prd1.IdProdutoFalhado = 1;
            prd1.IdAcaoCorretiva = 1;
            prd1.IdDetalhamentoFalha = 1;
            prd1.IdLocalizacao = 1;
            prd1.IdOrdemServico = 512870;
            prd1.IdProduto = 1;
            prd1.IdProdutoFalhado = 1;
            prd1.IdSolucaoAdotada = 1;
            prd1.NumeroSerie = "NumeroSerie1";
            prd1.Localizacao = "Localizacao1";
            prd1.Produto = "Produto1";
            prd1.SolucaoAdotada = "Solucao1";
            prd1.StatusFuncionamento = true;
            prd1.DetalhamentoFalha = "Detalhamento1";
            prd1.AcaoCorretiva = "Acao1";

            produtosfalhados.Add(prd1);



            ProdutosFalhadosViewModel prd2 = new ProdutosFalhadosViewModel();

            prd2.IdProdutoFalhado = 2;
            prd2.IdAcaoCorretiva = 1;
            prd2.IdDetalhamentoFalha = 1;
            prd2.IdLocalizacao = 1;
            prd2.IdOrdemServico = 512870;
            prd2.IdProduto = 2;
            prd2.IdProdutoFalhado = 1;
            prd2.IdSolucaoAdotada = 2;
            prd2.NumeroSerie = "NumeroSerie2";
            prd2.Localizacao = "Localizacao1";
            prd2.Produto = "Produto2";
            prd2.SolucaoAdotada = "Solucao2";
            prd2.StatusFuncionamento =false;
            prd2.DetalhamentoFalha = "Detalhamento2";
            prd2.AcaoCorretiva = "Acao2";

            produtosfalhados.Add(prd2);

            return produtosfalhados;

        }

        #endregion

    }
}
