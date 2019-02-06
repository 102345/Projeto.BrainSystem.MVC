using System.Web.Mvc;
using AutoMapper;
using BrainSystem.OS.Domain.Entities;
using BrainSystem.OS.MVC.ViewModels;
using BrainSystem.OS.BLL.Interface;
using System;
using System.Linq;
using BrainSystem.OS.MVC.Filtro;
using System.Collections.Generic;
using BrainSystem.Framework.Utils;

namespace BrainSystem.OS.MVC.Controllers
{
    public class OrdemServicoController : Controller
    {
        //private IOrdemServicoBusiness _ordemservicoBusiness;
        //private IClienteBusiness _clienteBusiness;
        //private IEnderecoBusiness _enderecoBusiness;
        //private IFuncionarioBusiness _funcionarioBusiness;
        //private IGrupoBusiness _grupoBusiness;


        //public OrdemServicoController(IOrdemServicoBusiness ordemservicoBusiness, IClienteBusiness clienteBusiness,
        //                             IEnderecoBusiness enderecoBusiness, IFuncionarioBusiness funcionarioBusiness,
        //                             IGrupoBusiness grupoBusiness)
        //{
        //    _ordemservicoBusiness = ordemservicoBusiness;
        //    _clienteBusiness = clienteBusiness;
        //    _enderecoBusiness = enderecoBusiness;
        //    _funcionarioBusiness = funcionarioBusiness;
        //    _grupoBusiness = grupoBusiness;


        //}

        public ActionResult Index()
        {
            ViewBag.Titulo = "Ordem de Serviço";
            ViewBag.NomeUsuario = "Cláudio";
            ViewBag.Cargo = "Técnico Campo";

            //implementar seus metodos
            //var idOrdemServico = 0;
            //var ordemservico = _ordemservicoBusiness.GetById(idOrdemServico);
            //var cliente = _clienteBusiness.BuscarClienteOrdemServico(idOrdemServico);
            //var endereco = _enderecoBusiness.BuscarEnderecoCliente(cliente.IdCliente);
            //var grupo = _grupoBusiness.GetById(cliente.IdGrupo);
            //var funcionario = _funcionarioBusiness.GetById(ordemservico.IdResponsavel);

            var ordemservico = RetornarOrdemServicoMockup();
            var cliente = RetornarClienteMockup();
            var funcionario = RetornarFuncionarioMockup();
            var grupo = RetornarGrupoMockup();
            var endereco = RetornarEnderecoMockup();

            var ordemServicoViewModel = Mapper.Map<OrdemServico, OrdemServicoViewModel>(ordemservico);

            if(Session["ordemservicoViewModel"] != null)
            {
                ordemServicoViewModel = Session["ordemservicoViewModel"] as OrdemServicoViewModel;
               
            }

            Session["ordemservicoViewModel"] = ordemServicoViewModel;

            Session["cliente"] = cliente;
            Session["grupo"] = grupo;
            Session["endereco"] = endereco;
            Session["responsavel"] = funcionario;

            //Fechamento de OS 
            Session["fechamentoOS"] = ordemServicoViewModel.EstadoControles;

            //Viewbag.Desabilitado = Convert.ToString(Session["fechamentoOS"]); 
            ordemServicoViewModel.DataPreenchimento = DateTime.Now;
            ordemServicoViewModel.EstadoControles = Convert.ToString(Session["fechamentoOS"]);


            return View(ordemServicoViewModel);


        }


        public ActionResult SimulaOSFechada()
        {
            var ordemservico = RetornarOrdemServicoMockup();

            var ordemServicoViewModel = Mapper.Map<OrdemServico, OrdemServicoViewModel>(ordemservico);

            if (Session["ordemservicoViewModel"] != null)
            {

                ordemServicoViewModel = Session["ordemservicoViewModel"] as OrdemServicoViewModel;

            }

            return View(ordemServicoViewModel);
        }

        public ActionResult GravarOpcaoSimulacao(string id)
        {
            var ordemservico = RetornarOrdemServicoMockup();

            var ordemServicoViewModel = Mapper.Map<OrdemServico, OrdemServicoViewModel>(ordemservico);

            if (Session["ordemservicoViewModel"] != null){

                ordemServicoViewModel = Session["ordemservicoViewModel"] as OrdemServicoViewModel;

            }

            ordemServicoViewModel.EstadoControles = id;

            //return RedirectToAction("Index", "OrdemServico");
            return RedirectToAction("SimulaOSFechada", "OrdemServico");

        }



        // POST: OrdemServico/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [FilterInformationOS]
        public ActionResult EnviarPasso2(OrdemServicoViewModel ordemServicoViewModel)
        {
            try
            {
                //if (!ModelState.IsValid) return RedirectToAction("Index", "OrdemServico", ordemServicoViewModel);

                //Session["ordemservicoViewModel"] = ordemServicoViewModel;

                //if (!ValidarEntradaHorasAtendimento(ordemServicoViewModel))
                //{

                //return RedirectToAction("Index", "OrdemServico");

                //}

                var cliente = Session["cliente"] as Cliente;

                ordemServicoViewModel.IdCliente = cliente.IdCliente;

                Session["ordemservicoViewModel"] = ordemServicoViewModel;

                return RedirectToAction("Index", "FluxoAtendimento");
            }
            catch
            {
                return View();
            }
        }


        [FilterInformationOS]
        public ActionResult DadosComplementaresOS()
        {
            ViewBag.Titulo = "Ordem de Serviço";
            ViewBag.NomeUsuario = "Cláudio";
            ViewBag.Cargo = "Técnico Campo";

            return View();


        }

        [FilterInformationOS]
        public ActionResult DadosFinalizacaoOS(OrdemServicoViewModel ordemServicoViewModel)
        {


            return View();


        }


        [FilterInformationOS]
        public ActionResult ClienteResponsavel()
        {
            ViewBag.Titulo = "Ordem de Serviço";
            ViewBag.NomeUsuario = "Cláudio";
            ViewBag.Cargo = "Técnico Campo";


            var ordemservicoViewModel = Session["ordemservicoViewModel"] as OrdemServicoViewModel;

            // Implementar a chamada de seu método de listagem de funcionarios
            //var funcionarios = _clienteBusiness.ListarFuncionarios(int IdCliente);



            var cliente = Session["cliente"] as Cliente;


            ViewData["Funcionarios"] = new SelectList(cliente.Funcionarios, "IdFuncionario", "Nome");


            

            if(ordemservicoViewModel.IdFuncionario > 0)
            {
                List<Funcionario> funcionarios = cliente.Funcionarios.ToList();

                var funcionario = funcionarios.Find(a => a.IdFuncionario == ordemservicoViewModel.IdFuncionario && a.IdCliente == cliente.IdCliente);
                ViewBag.NomeFuncionario = funcionario.Nome;
                ViewBag.CargoFuncionario = funcionario.Cargo;
                ViewBag.RG = funcionario.RG;
                ViewBag.Email = funcionario.Email;
                ViewBag.Telefone = funcionario.Telefone;

            }
            



            return View(ordemservicoViewModel);
            
        }




        //[HttpPost]
        public JsonResult BuscarDadosResponsavel(string idResponsavel)
        {

            // Implementar a chamada de seu método de listagem de funcionarios
            //var funcionarios = _clienteBusiness.ListarFuncionarios(int IdCliente);

            var cliente = Session["cliente"] as Cliente;


            List<Funcionario> funcionarios = cliente.Funcionarios.ToList();


            var funcionario = funcionarios.Find(a => a.IdFuncionario == Convert.ToInt32(idResponsavel) && a.IdCliente == cliente.IdCliente);

           

            return Json(funcionario);
        }


        public PartialViewResult ExibirCadastroFuncionario()
        {

            var funcionarioViewModel = new FuncionarioViewModel();

            var cliente = Session["cliente"] as Cliente;

            funcionarioViewModel.IdCliente = cliente.IdCliente;
         
            return PartialView("_CadastroClienteResponsavel", funcionarioViewModel);

        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GravarAtendimento(OrdemServicoViewModel ordemServicoViewModel)
        {
            var ordemservicoViewModelOrigem = Session["ordemservicoViewModel"] as OrdemServicoViewModel;

            ordemservicoViewModelOrigem.IdFuncionario = ordemServicoViewModel.IdFuncionario;
            ordemservicoViewModelOrigem.Assinatura = ordemServicoViewModel.Assinatura;
            ordemservicoViewModelOrigem.HoraInicio = ordemServicoViewModel.HoraInicio;
            ordemservicoViewModelOrigem.HoraChegada = ordemServicoViewModel.HoraChegada;
            ordemservicoViewModelOrigem.HoraTermino = ordemServicoViewModel.HoraTermino;
            ordemservicoViewModelOrigem.HoraSaida = ordemServicoViewModel.HoraSaida;
            ordemservicoViewModelOrigem.DataPreenchimento = ordemServicoViewModel.DataPreenchimento;


            Session["ordeservicoViewModel"] = ordemservicoViewModelOrigem;

            TempData["success"] = "Gravado com sucesso a ordem de serviço.";

            return RedirectToAction("ClienteResponsavel", "OrdemServico");
        }


        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EnviarDadosFinalizacao(OrdemServicoViewModel ordemServicoViewModel)
        {
            var ordemservicoViewModelOrigem = Session["ordemservicoViewModel"] as OrdemServicoViewModel;

            ordemservicoViewModelOrigem.Observacoes = ordemServicoViewModel.Observacoes;

            //Implementar seu metodo de geração de identificador de anexo a OS.
            ordemServicoViewModel.IdAnexo = 1;
            int a = 1;
            //--------------------------------------------------------------------

            ordemservicoViewModelOrigem.IdAnexo = ordemServicoViewModel.IdAnexo;

            var conta = Request.Files.Count;

            List<Anexo> anexos = new List<Anexo>();


            for (int i = 0; i < Request.Files.Count; i++)
            {
                var arquivo = Request.Files[i];
               

                if (arquivo.ContentLength != 0)
                {


                    var anexo = new Anexo();

                    anexo.Id = a++; // Exemplo modificar para um identificador unico do objeto 
                    anexo.IdAnexo = ordemservicoViewModelOrigem.IdAnexo;

                    //Use este metodo de conversao para binario caso o arquivo seja tipo imagem (jpeg, png, entre outros)
                    // anexo.Arquivo = Imagem.ConverterHttpImagem(arquivo);

                    //Exemplo de recebimento de dados de arquivo anexo (Mockup)
                    anexo.Arquivo = arquivo.FileName;

                    anexos.Add(anexo);

                }


            }

            ordemservicoViewModelOrigem.Anexos = anexos;
           

            Session["ordemservicoViewModel"] = ordemservicoViewModelOrigem;



            return RedirectToAction("ClienteResponsavel","OrdemServico");
        }


        public FileStreamResult RetornarRelatorio()
        {
            Service.PdfResultService service = new Service.PdfResultService();

            var pathFisico = Server.MapPath("assets/images/apple-touch-icon-57-precomposed.png");

            service.PathLogo = pathFisico.Replace("\\OrdemServico", "");

            service.SessionCliente = Session["cliente"];
            service.SessionGrupo = Session["grupo"];
            service.SessionOrdemServico = Session["ordemservicoViewModel"];
            service.SessionEndereco = Session["endereco"];
            service.SessionResponsavel = Session["responsavel"];

            service.SessionProdutosFalhados = Session["produtosfalhadosViewModel"];
            service.SessionPecasAplicadas = Session["pecasaplicadasViewModel"];
            service.SessionSolicitacoesPecas = Session["solicitacoespecasViewModel"];
            service.SessionRetiradaEquipamentos = Session["retiradasequipamentosViewModel"];


            return service.GerarRelatorioOSPdf();

            
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="ordemServicoViewModel"></param>
        /// <returns></returns>
        public bool ValidarEntradaHorasAtendimento(OrdemServicoViewModel ordemServicoViewModel)
        {

            if (ordemServicoViewModel.DataPreenchimento.ToString() =="01/01/0001 00:00:00" )
            {
                TempData["warning"] = "Verifique o lançamento da data preenchimento.";
                return false;

            }

            DateTime data = Convert.ToDateTime(ordemServicoViewModel.HoraChegada);

            if (Convert.ToDateTime(ordemServicoViewModel.HoraChegada) >= Convert.ToDateTime(ordemServicoViewModel.HoraSaida))
            {
                TempData["warning"] = "Verifique os lançamentos de horas.";
                return false;

            }

            if (Convert.ToDateTime(ordemServicoViewModel.HoraChegada) >= Convert.ToDateTime(ordemServicoViewModel.HoraInicio))
            {
                TempData["warning"] = "Verifique os lançamentos de horas.";
                return false;

            }


            if (Convert.ToDateTime(ordemServicoViewModel.HoraChegada) >= Convert.ToDateTime(ordemServicoViewModel.HoraTermino))
            {
                TempData["warning"] = "Verifique os lançamentos de horas.";
                return false;

            }

            if (Convert.ToDateTime(ordemServicoViewModel.HoraChegada) >= Convert.ToDateTime(ordemServicoViewModel.HoraSaida))
            {
                TempData["warning"] = "Verifique os lançamentos de horas.";
                return false;

            }

            if (Convert.ToDateTime(ordemServicoViewModel.HoraInicio) >= Convert.ToDateTime(ordemServicoViewModel.HoraTermino))
            {
                TempData["warning"] = "Verifique os lançamentos de horas.";
                return false;

            }

            if (Convert.ToDateTime((ordemServicoViewModel.HoraInicio)) >= Convert.ToDateTime(ordemServicoViewModel.HoraSaida))
            {
                TempData["warning"] = "Verifique os lançamentos de horas.";
                return false;

            }


            if (Convert.ToDateTime(ordemServicoViewModel.HoraTermino) >= Convert.ToDateTime(ordemServicoViewModel.HoraSaida))
            {
                TempData["warning"] = "Verifique os lançamentos de horas.";
                return false;

            }





            return true;

        }


        #region Dados Mockup

        private OrdemServico RetornarOrdemServicoMockup()
        {

            var ordemservico = new OrdemServico();

            ordemservico.IdOrdemServico = 512870;
            ordemservico.DataChamado = System.DateTime.Now;
            ordemservico.NumeroChamado = 974552;
            ordemservico.NomeTecnico = "Claudio dos Santos";
            ordemservico.IdCliente = 1;
           

            return ordemservico;
        }

        private Cliente RetornarClienteMockup()
        {
            var cliente = new Cliente();

            cliente.IdCliente = 1;
            cliente.NomeFantasia = "LASA";
            cliente.RazaoSocial = "LOJAS AMERICANAS LTDA";
            cliente.CNPJ = "99.999.999/9999-99";
            cliente.Funcionarios = ListaFuncionariosMockup();
            

            return cliente;

        }

        private Endereco RetornarEnderecoMockup()
        {
            var endereco = new Endereco();

            endereco.IdCliente = 1;
            endereco.Logradouro = "AV. TESTE";
            endereco.Numero = "123";
            endereco.Bairro = "Bairro";
            endereco.Cidade = "São Paulo";
            endereco.UF = "SP";
            endereco.CEP = "9999-999";

            return endereco;
        }

        private Grupo RetornarGrupoMockup()
        {
            var grupo = new Grupo();
            grupo.IdGrupo = 1;
            grupo.Descricao = "Grupo LASA";

            return grupo;
        }


        private Funcionario RetornarFuncionarioMockup()
        {
            var funcionario = new Funcionario();

            funcionario.IdFuncionario = 1;
            funcionario.Nome = "Raphel Murcia";
            funcionario.Telefone = "(99)9999-9999";
            funcionario.Email = "raphael.murcia@lasa.com.br";

            return funcionario;
        }



        private List<Funcionario> ListaFuncionariosMockup()
        {

            var funcionarios = new List<Funcionario>();

            var funcionario0 = new Funcionario();

            funcionario0.IdCliente = 1;
            funcionario0.IdFuncionario = 0;
            funcionario0.Nome = "";
          

            funcionarios.Add(funcionario0);



            var funcionario = new Funcionario();

            funcionario.IdCliente = 1;
            funcionario.IdFuncionario = 1;
            funcionario.Nome = "Paulo de Almeida";
            funcionario.Cargo = "Gerente de Produção";
            funcionario.Telefone = "(99)9999-9999";
            funcionario.Email = "paulo@lasa.com.br";
            funcionario.RG = "44444444";

            funcionarios.Add(funcionario);


            var funcionario2 = new Funcionario();

            funcionario2.IdCliente = 1;
            funcionario2.IdFuncionario = 2;
            funcionario2.Nome = "Daniela de Souza";
            funcionario2.Cargo = "Analista de Materiais";
            funcionario2.Telefone = "(99)9999-9999";
            funcionario2.Email = "daniela@lasa.com.br";
            funcionario2.RG = "11111111";

            funcionarios.Add(funcionario2);

            return funcionarios;
        }





        #endregion

    }
}
