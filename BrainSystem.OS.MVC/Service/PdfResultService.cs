using System.IO;
using System.Web.Mvc;
using iTextSharp.text;
using iTextSharp.text.pdf;
using BrainSystem.OS.Domain.Entities;
using BrainSystem.OS.MVC.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System;

namespace BrainSystem.OS.MVC.Service
{
    public class PdfResultService
    {
        public object SessionCliente { get; set; }

        public object SessionGrupo { get; set; }

        public object SessionOrdemServico { get; set; }

        public object SessionEndereco { get; set; }

        public object SessionResponsavel { get; set; }

        public object SessionProdutosFalhados { get; set; }

        public object SessionPecasAplicadas { get; set; }

        public object SessionSolicitacoesPecas { get; set; }

        public object SessionRetiradaEquipamentos { get; set; }

        public string PathLogo { get; set; }

        private Document Documento { get; set; }



        public FileStreamResult GerarRelatorioOSPdf()
        {
            MemoryStream workStream = new MemoryStream();


            Document document = new Document(PageSize.A4,80,10,20,20);

            PdfWriter.GetInstance(document, workStream).CloseStream = false;


           
            document.NewPage();


            var bodyFont = FontFactory.GetFont("Arial", 9, Font.NORMAL);
            var bodyFontSmall = FontFactory.GetFont("Arial", 8, Font.NORMAL);
            var bodyFontSmallBold = FontFactory.GetFont("Arial", 8, Font.BOLD);
            var bodySubTitle = FontFactory.GetFont("Arial", 10, Font.BOLD,BaseColor.WHITE);


            var logo = Image.GetInstance(PathLogo);

            logo.SetAbsolutePosition(490, 785);



            Cliente cliente = SessionCliente as Cliente;
            Grupo grupo = SessionGrupo as Grupo;
            Funcionario responsavel = SessionResponsavel as Funcionario;
            Endereco endereco = SessionEndereco as Endereco;
            OrdemServicoViewModel ordemServico = SessionOrdemServico as OrdemServicoViewModel;

            List<ProdutosFalhadosViewModel> listaProdutosFalhados = SessionProdutosFalhados as List<ProdutosFalhadosViewModel>;
            List<PecasAplicadasViewModel> listaPecasAplicadas = SessionPecasAplicadas as List<PecasAplicadasViewModel>;
            List<SolicitacoesPecasViewModel> listaSolicitacoesPecas = SessionSolicitacoesPecas as List<SolicitacoesPecasViewModel>;
            List<RetiradaEquipamentosViewModel> listaRetiradaEquipamentos = SessionRetiradaEquipamentos as List<RetiradaEquipamentosViewModel>;

            //string descricaoOrdemServico = "Protocolo Chamado nr  " + ordemServico.NumeroChamado;
            //descricaoOrdemServico += " -  Registrado em  " + ordemServico.DataChamado;
            //descricaoOrdemServico += " - Ordem de Servico nr  " + ordemServico.IdOrdemServico.ToString();



            string descricaoPeriodoAtendimento = "Técnico Responsável  " + ordemServico.NomeTecnico + " - Data Atendimento  " + ordemServico.DataPreenchimento;
            string descricaoPeriodoAtendimentoCompl = "Hora chegada  " + ordemServico.HoraChegada + " Hora início  " + ordemServico.HoraInicio;
            descricaoPeriodoAtendimentoCompl += " Hora término  " + ordemServico.HoraTermino + " Hora saída  " + ordemServico.HoraSaida;



            string descricaoCliente = cliente.NomeFantasia + " - " + cliente.RazaoSocial;
            string descricaoClienteCompl = "CNPJ " + cliente.CNPJ + " - " + grupo.Descricao;

            string descricaoEndereco = endereco.Logradouro + " " + endereco.Numero + " " + endereco.Complemento + " " + endereco.Bairro;
            string descricaoEnderecoCompl1 = endereco.Cidade + " " + endereco.UF + "  CEP " + endereco.CEP;

            string descricaoResponsavel = responsavel.Nome + " " + responsavel.Telefone + " " + responsavel.Email;



            document.Open();
            document.Add(logo);
         
            MontarSeccaoOrdemServico(ordemServico, ref document, bodyFont);

            MontarSeccaoPeriodoAtendimento(ordemServico, ref document, bodyFont, bodySubTitle);

            MontarSeccaoSolicitante(cliente, endereco, responsavel, grupo, ref document, bodyFont, bodySubTitle);

            MontarProdutosFalhados(listaProdutosFalhados, listaPecasAplicadas, listaSolicitacoesPecas,
                                    listaRetiradaEquipamentos, ref document, bodySubTitle, bodyFontSmall, bodyFontSmallBold);

            MontarSeccaoObservacoes(ordemServico, ref document, bodyFont, bodySubTitle);

            MontarSeccaoClienteResponsavel(ordemServico, cliente, ref document, bodyFont, bodySubTitle);



            document.Close(); 
            byte[] byteInfo = workStream.ToArray();


            //Font blackFont = FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK);
            //PdfReader reader = new PdfReader(byteInfo);


            //using (PdfStamper stamper = new PdfStamper(reader, workStream))
            //{
            //    int pages = reader.NumberOfPages;
            //    for (int i = 1; i <= pages; i++)
            //    {
            //        ColumnText.ShowTextAligned(stamper.GetUnderContent(i), Element.ALIGN_RIGHT, new Phrase(i.ToString(), blackFont), 568f, 15f, 0);
            //    }
            //}



            //byteInfo = workStream.ToArray();


            workStream.Write(byteInfo, 0, byteInfo.Length);
            workStream.Position = 0;

            return new FileStreamResult(workStream, "application/pdf");
        }


        private void MontarSeccaoObservacoes(OrdemServicoViewModel ordemServico,ref Document documento,Font bodyFont, Font bodySubTitle)
        {

            documento.Add(FormatarSubTituloSeccao("Observações", bodySubTitle));
            documento.Add(new Paragraph(ordemServico.Observacoes, bodyFont));
            documento.Add(new Paragraph(" "));
        }


        private void MontarSeccaoClienteResponsavel(OrdemServicoViewModel ordemServico,Cliente cliente,ref Document documento,Font bodyFont,Font bodySubTitle)
        {

            documento.Add(FormatarSubTituloSeccao("Cliente Responsável", bodySubTitle));


            List<Funcionario> funcionarios = cliente.Funcionarios.ToList();


            var funcionario = funcionarios.Find(a => a.IdFuncionario == ordemServico.IdFuncionario && a.IdCliente == cliente.IdCliente);


            string descricaoClienteResponsavel = funcionario.Nome + "  RG " + funcionario.RG;
            string descricaoClienteResponsavelCompl = funcionario.Cargo + "  " + funcionario.Telefone + "  " + funcionario.Email;


            documento.Add(new Paragraph(descricaoClienteResponsavel, bodyFont));
            documento.Add(new Paragraph(descricaoClienteResponsavelCompl, bodyFont));


        }


        private void MontarSeccaoOrdemServico(OrdemServicoViewModel ordemServico, ref Document documento, Font bodyFont)
        {

            string descricaoOrdemServico = "Protocolo Chamado nr  " + ordemServico.NumeroChamado;
            descricaoOrdemServico += " -  Registrado em  " + ordemServico.DataChamado;
            descricaoOrdemServico += " - Ordem de Servico nr  " + ordemServico.IdOrdemServico.ToString();

            documento.Add(new Paragraph(" "));
            documento.Add(new Paragraph(" "));
            documento.Add(new Paragraph(descricaoOrdemServico, bodyFont));



        }

        private PdfPTable FormatarSubTituloSeccao(string subTitulo, Font bodySubTitle)
        {

            var tituloTable = new PdfPTable(1);
            tituloTable.HorizontalAlignment = 0;
            tituloTable.SpacingBefore = 10;
            tituloTable.SpacingAfter = 10;
            tituloTable.DefaultCell.Border = Rectangle.NO_BORDER;

            float[] widthsTitulo = new float[] { 1000f };
            tituloTable.SetWidths(widthsTitulo);


            PdfPCell cellTitulo = new PdfPCell(new Phrase(subTitulo, bodySubTitle));
            cellTitulo.BackgroundColor = new BaseColor(65, 73, 129);
            cellTitulo.Border = Rectangle.NO_BORDER;
            tituloTable.AddCell(cellTitulo);

            return tituloTable;

        }


        private void MontarSeccaoPeriodoAtendimento(OrdemServicoViewModel ordemServico, ref Document documento, Font bodyFont, Font bodySubTitle)
        {
            string descricaoPeriodoAtendimento = "Técnico Responsável  " + ordemServico.NomeTecnico + " - Data Atendimento  " + ordemServico.DataPreenchimento;
            string descricaoPeriodoAtendimentoCompl = " Hora chegada  " + ordemServico.HoraChegada + "  Hora início  " + ordemServico.HoraInicio;
            descricaoPeriodoAtendimentoCompl += "  Hora término  " + ordemServico.HoraTermino + "  Hora saída  " + ordemServico.HoraSaida;

            documento.Add(new Paragraph(" "));
            documento.Add(FormatarSubTituloSeccao("Período Atendimento",bodySubTitle));
            documento.Add(new Paragraph(descricaoPeriodoAtendimento, bodyFont));
            documento.Add(new Paragraph(descricaoPeriodoAtendimentoCompl, bodyFont));


        }


        private void MontarSeccaoSolicitante(Cliente cliente, Endereco endereco, Funcionario responsavel, Grupo grupo, ref Document documento, Font bodyFont, Font bodySubTitle)
        {

            string descricaoCliente = cliente.NomeFantasia + " - " + cliente.RazaoSocial;
            string descricaoClienteCompl = "CNPJ " + cliente.CNPJ + " - " + grupo.Descricao;

            string descricaoEndereco = endereco.Logradouro + " " + endereco.Numero + " " + endereco.Complemento + " " + endereco.Bairro;
            string descricaoEnderecoCompl1 = endereco.Cidade + " " + endereco.UF + "  CEP " + endereco.CEP;

            string descricaoResponsavel = responsavel.Nome + " " + responsavel.Telefone + " " + responsavel.Email;

            documento.Add(new Paragraph(" "));
            documento.Add(FormatarSubTituloSeccao("Solicitante", bodySubTitle));


            documento.Add(new Paragraph(descricaoCliente, bodyFont));
            documento.Add(new Paragraph(descricaoClienteCompl, bodyFont));

            documento.Add(new Paragraph(descricaoEndereco, bodyFont));
            documento.Add(new Paragraph(descricaoEnderecoCompl1, bodyFont));
            documento.Add(new Paragraph(" "));
            documento.Add(new Paragraph(descricaoResponsavel, bodyFont));
            documento.Add(new Paragraph(" "));
            documento.Add(new Paragraph(" "));


        }


        private void MontarProdutosFalhados(List<ProdutosFalhadosViewModel> listaProdutosFalhados,
                                           List<PecasAplicadasViewModel> listaPecasAplicadas,
                                           List<SolicitacoesPecasViewModel> listaSolicitacoesPecas,
                                           List<RetiradaEquipamentosViewModel> listaRetiradaEquipamentos,
                                           ref Document documento,
                                           Font bodySubTitle,
                                           Font bodyFontSmall,
                                           Font bodyFontSmallBold
                                           )
        {





            documento.Add(FormatarSubTituloSeccao("Produtos Falhados", bodySubTitle));


            foreach (ProdutosFalhadosViewModel produtoFalhado in listaProdutosFalhados)
            {
                //8x1

                var produtoFalhadoTable = new PdfPTable(8);
                produtoFalhadoTable.HorizontalAlignment = 0;
                produtoFalhadoTable.SpacingBefore = 10;
                produtoFalhadoTable.SpacingAfter = 10;
                produtoFalhadoTable.DefaultCell.Border = 0;
                produtoFalhadoTable.DefaultCell.Border = Rectangle.NO_BORDER;

                float[] widths = new float[] { 80f, 200f, 200f, 400f, 400f, 200f, 200f, 400f };
                produtoFalhadoTable.SetWidths(widths);


                var bodyFontHeader = FontFactory.GetFont("Arial", 8, Font.NORMAL,BaseColor.WHITE);


                PdfPCell cellCodigo = new PdfPCell(new Phrase("Código", bodyFontHeader));
                cellCodigo.BackgroundColor = new BaseColor(65, 73,129);
                cellCodigo.Border = Rectangle.NO_BORDER;
                produtoFalhadoTable.AddCell(cellCodigo);

                PdfPCell cellDescricao = new PdfPCell(new Phrase("Descrição", bodyFontHeader));
                cellDescricao.BackgroundColor = new BaseColor(65, 73, 129);
                cellDescricao.Border = Rectangle.NO_BORDER;
                produtoFalhadoTable.AddCell(cellDescricao);

                PdfPCell cellNumeroSerie = new PdfPCell(new Phrase("Número Série", bodyFontHeader));
                cellNumeroSerie.BackgroundColor = new BaseColor(65, 73, 129);
                cellNumeroSerie.Border = Rectangle.NO_BORDER;
                produtoFalhadoTable.AddCell(cellNumeroSerie);


                PdfPCell cellLocalizacaoFalha = new PdfPCell(new Phrase("Localização da Falha", bodyFontHeader));
                cellLocalizacaoFalha.BackgroundColor = new BaseColor(65, 73, 129);
                cellLocalizacaoFalha.Border = Rectangle.NO_BORDER;
                produtoFalhadoTable.AddCell(cellLocalizacaoFalha);

                PdfPCell cellDetalhamentoFalha = new PdfPCell(new Phrase("Detalhamento da Falha", bodyFontHeader));
                cellDetalhamentoFalha.BackgroundColor = new BaseColor(65, 73, 129);
                cellDetalhamentoFalha.Border = Rectangle.NO_BORDER;
                produtoFalhadoTable.AddCell(cellDetalhamentoFalha);

                PdfPCell cellAcaoCorretiva = new PdfPCell(new Phrase("Ação Corretiva", bodyFontHeader));
                cellAcaoCorretiva.BackgroundColor = new BaseColor(65, 73, 129);
                cellAcaoCorretiva.Border = Rectangle.NO_BORDER;
                produtoFalhadoTable.AddCell(cellAcaoCorretiva);

                PdfPCell cellSolucaoAdotada = new PdfPCell(new Phrase("Solução Adotada", bodyFontHeader));
                cellSolucaoAdotada.BackgroundColor = new BaseColor(65, 73, 129);
                cellSolucaoAdotada.Border = Rectangle.NO_BORDER;
                produtoFalhadoTable.AddCell(cellSolucaoAdotada);

                PdfPCell cellStatusFuncionamento = new PdfPCell(new Phrase("Status Funcionamento", bodyFontHeader));
                cellStatusFuncionamento.BackgroundColor = new BaseColor(65, 73, 129);
                cellStatusFuncionamento.Border = Rectangle.NO_BORDER;
                produtoFalhadoTable.AddCell(cellStatusFuncionamento);



                var statusFuncionamento = produtoFalhado.StatusFuncionamento == true ? "Sim" : "Não";



                PdfPCell cellCodigoValor = new PdfPCell(new Phrase(produtoFalhado.IdProduto.ToString(), bodyFontSmall));
                cellCodigoValor.Border = Rectangle.NO_BORDER;
                produtoFalhadoTable.AddCell(cellCodigoValor);

                PdfPCell cellDescricaoValor = new PdfPCell(new Phrase(produtoFalhado.Produto, bodyFontSmall));
                cellDescricaoValor.Border = Rectangle.NO_BORDER;
                produtoFalhadoTable.AddCell(cellDescricaoValor);

                PdfPCell cellNumeroSerieValor = new PdfPCell(new Phrase(produtoFalhado.NumeroSerie, bodyFontSmall));
                cellNumeroSerieValor.Border = Rectangle.NO_BORDER;
                produtoFalhadoTable.AddCell(cellNumeroSerieValor);


                PdfPCell cellLocalizacaoFalhaValor = new PdfPCell(new Phrase(produtoFalhado.Localizacao, bodyFontSmall));
                cellLocalizacaoFalhaValor.Border = Rectangle.NO_BORDER;
                produtoFalhadoTable.AddCell(cellLocalizacaoFalhaValor);

                PdfPCell cellDetalhamentoFalhaValor = new PdfPCell(new Phrase(produtoFalhado.DetalhamentoFalha, bodyFontSmall));
                cellDetalhamentoFalhaValor.Border = Rectangle.NO_BORDER;
                produtoFalhadoTable.AddCell(cellDetalhamentoFalhaValor);

                PdfPCell cellAcaoCorretivaValor = new PdfPCell(new Phrase(produtoFalhado.AcaoCorretiva, bodyFontSmall));
                cellAcaoCorretivaValor.Border = Rectangle.NO_BORDER;
                produtoFalhadoTable.AddCell(cellAcaoCorretivaValor);

                PdfPCell cellSolucaoAdotadaValor = new PdfPCell(new Phrase(produtoFalhado.SolucaoAdotada, bodyFontSmall));
                cellSolucaoAdotadaValor.Border = Rectangle.NO_BORDER;
                produtoFalhadoTable.AddCell(cellSolucaoAdotadaValor);

                PdfPCell cellStatusFuncionamentoValor = new PdfPCell(new Phrase(statusFuncionamento, bodyFontSmall));
                cellStatusFuncionamentoValor.Border = Rectangle.NO_BORDER;
                produtoFalhadoTable.AddCell(cellStatusFuncionamentoValor);


                documento.Add(produtoFalhadoTable);

                documento.Add(new Paragraph(" "));


                List<PecasAplicadasViewModel> listaPecasAplicadasFiltro = listaPecasAplicadas.FindAll(a => a.IdProdutoFalhado == produtoFalhado.IdProdutoFalhado);

                List<SolicitacoesPecasViewModel> listaSolicitacoesPecasFiltro = listaSolicitacoesPecas.FindAll(a => a.IdProdutoFalhado == produtoFalhado.IdProdutoFalhado);

                List<RetiradaEquipamentosViewModel> listaRetiradaEquipamentosFiltro = listaRetiradaEquipamentos.FindAll(a => a.IdProdutoFalhado == produtoFalhado.IdProdutoFalhado);


                if (listaPecasAplicadas.Count > 0)
                {

                    MontarSeccaoPecasAplicadas(listaPecasAplicadasFiltro, ref documento, bodyFontSmallBold, bodyFontSmall);
                  

                }




                if (listaPecasAplicadas.Count > 0)
                {

                 
                    MontarSeccaoSolicitacoesPecas(listaSolicitacoesPecasFiltro, ref documento, bodyFontSmallBold, bodyFontSmall);


                }



                if (listaRetiradaEquipamentos.Count > 0)
                {

                    MontarSeccaoRetiradaEquipamentos(listaRetiradaEquipamentos, ref documento, bodyFontSmallBold, bodyFontSmall);

                }


            }



        }


        private void MontarSeccaoPecasAplicadas(List<PecasAplicadasViewModel> listaPecasAplicadasFiltro, ref Document documento, Font bodyFontSmallBold, Font bodyFontSmall)
        {

            documento.Add(new Paragraph("Peças Aplicadas", bodyFontSmallBold));


            var pecaAplicadaTable = new PdfPTable(4);
            pecaAplicadaTable.HorizontalAlignment = 0;
            pecaAplicadaTable.SpacingBefore = 10;
            pecaAplicadaTable.SpacingAfter = 10;
            pecaAplicadaTable.DefaultCell.Border = Rectangle.NO_BORDER;

            float[] widthsPA = new float[] { 100f, 400f, 200f, 200f };
            pecaAplicadaTable.SetWidths(widthsPA);



            var bodyFontHeader = FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.WHITE);


            PdfPCell cellCodigo = new PdfPCell(new Phrase("Código", bodyFontHeader));
            cellCodigo.BackgroundColor = new BaseColor(189,192,215);
            cellCodigo.Border = Rectangle.NO_BORDER;
            pecaAplicadaTable.AddCell(cellCodigo);

            PdfPCell cellDescricao = new PdfPCell(new Phrase("Descricao", bodyFontHeader));
            cellDescricao.BackgroundColor = new BaseColor(189,192,215);
            cellDescricao.Border = Rectangle.NO_BORDER;
            pecaAplicadaTable.AddCell(cellDescricao);

            PdfPCell cellNumeroSerie = new PdfPCell(new Phrase("Número Série", bodyFontHeader));
            cellNumeroSerie.BackgroundColor = new BaseColor(189,192,215);
            cellNumeroSerie.Border = Rectangle.NO_BORDER;
            pecaAplicadaTable.AddCell(cellNumeroSerie);

            PdfPCell cellQuantidade = new PdfPCell(new Phrase("Quantidade", bodyFontHeader));
            cellQuantidade.BackgroundColor = new BaseColor(189,192,215);
            cellQuantidade.Border = Rectangle.NO_BORDER;
            pecaAplicadaTable.AddCell(cellQuantidade);

            foreach (PecasAplicadasViewModel pecaAplicada in listaPecasAplicadasFiltro)
            {

                PdfPCell[] cellsPA1 = new PdfPCell[] { new PdfPCell(new Phrase(pecaAplicada.IdProduto.ToString(),bodyFontSmall)),
                                    new PdfPCell(new Phrase(pecaAplicada.Produto,bodyFontSmall)),
                                    new PdfPCell(new Phrase(pecaAplicada.NumeroSerie,bodyFontSmall)),
                                    new PdfPCell(new Phrase(pecaAplicada.Quantidade.ToString(),bodyFontSmall))};

                PdfPRow rowPA1 = new PdfPRow(cellsPA1);


                pecaAplicadaTable.Rows.Add(rowPA1);


            }


            documento.Add(pecaAplicadaTable);

            documento.Add(new Paragraph(" "));

        }

        private void MontarSeccaoSolicitacoesPecas(List<SolicitacoesPecasViewModel> listaSolicitacoesPecasFiltro, ref Document documento, Font bodyFontSmallBold, Font bodyFontSmall)
        {

            documento.Add(new Paragraph("Solicitações Peças", bodyFontSmallBold));
            //document.Add(new Paragraph(" "));

            var solicitacaoPecaTable = new PdfPTable(3);
            solicitacaoPecaTable.HorizontalAlignment = 0;
            solicitacaoPecaTable.SpacingBefore = 10;
            solicitacaoPecaTable.SpacingAfter = 10;
            //produtoFalhadoTable.DefaultCell.Border = 0;
            solicitacaoPecaTable.DefaultCell.Border = Rectangle.NO_BORDER;

            float[] widthSP = new float[] { 100f, 400f, 200f };
            solicitacaoPecaTable.SetWidths(widthSP);



            var bodyFontHeader = FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.WHITE);


            PdfPCell cellCodigo = new PdfPCell(new Phrase("Código", bodyFontHeader));
            cellCodigo.BackgroundColor = new BaseColor(189,192, 215);
            cellCodigo.Border = Rectangle.NO_BORDER;
            solicitacaoPecaTable.AddCell(cellCodigo);

            PdfPCell cellDescricao = new PdfPCell(new Phrase("Descrição", bodyFontHeader));
            cellDescricao.BackgroundColor = new BaseColor(189,192,215);
            cellDescricao.Border = Rectangle.NO_BORDER;
            solicitacaoPecaTable.AddCell(cellDescricao);

            PdfPCell cellQuantidade = new PdfPCell(new Phrase("Quantidade", bodyFontHeader));
            cellQuantidade.BackgroundColor = new BaseColor(189,192,215);
            cellQuantidade.Border = Rectangle.NO_BORDER;
            solicitacaoPecaTable.AddCell(cellQuantidade);


            foreach (SolicitacoesPecasViewModel solicitacaoPeca in listaSolicitacoesPecasFiltro)
            {

                PdfPCell[] cellsSP1 = new PdfPCell[] { new PdfPCell(new Phrase(solicitacaoPeca.IdProduto.ToString(),bodyFontSmall)),
                                    new PdfPCell(new Phrase(solicitacaoPeca.Produto,bodyFontSmall)),
                                    new PdfPCell(new Phrase(solicitacaoPeca.Quantidade.ToString(),bodyFontSmall))};

                PdfPRow rowSP1 = new PdfPRow(cellsSP1);


                solicitacaoPecaTable.Rows.Add(rowSP1);


            }


            documento.Add(solicitacaoPecaTable);

            documento.Add(new Paragraph(" "));


        }


        private void MontarSeccaoRetiradaEquipamentos(List<RetiradaEquipamentosViewModel> listaRetiradaEquipamentosFiltro, ref Document documento, Font bodyFontSmallBold, Font bodyFontSmall)
        {

            documento.Add(new Paragraph("Equipamentos Retirados", bodyFontSmallBold));
            //document.Add(new Paragraph(" "));

            var eqptoRetiradoTable = new PdfPTable(3);
            eqptoRetiradoTable.HorizontalAlignment = 0;
            eqptoRetiradoTable.SpacingBefore = 10;
            eqptoRetiradoTable.SpacingAfter = 10;
            //produtoFalhadoTable.DefaultCell.Border = 0;
            eqptoRetiradoTable.DefaultCell.Border = Rectangle.NO_BORDER;

            float[] widthsER = new float[] { 100f, 400f, 200f };
            eqptoRetiradoTable.SetWidths(widthsER);



            var bodyFontHeader = FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.WHITE);


            PdfPCell cellCodigo = new PdfPCell(new Phrase("Código", bodyFontHeader));
            cellCodigo.BackgroundColor = new BaseColor(189,192,215);
            cellCodigo.Border = Rectangle.NO_BORDER;
            eqptoRetiradoTable.AddCell(cellCodigo);

            PdfPCell cellDescricao = new PdfPCell(new Phrase("Descrição", bodyFontHeader));
            cellDescricao.BackgroundColor = new BaseColor(189,192,215);
            cellDescricao.Border = Rectangle.NO_BORDER;
            eqptoRetiradoTable.AddCell(cellDescricao);

            PdfPCell cellNumeroSerie = new PdfPCell(new Phrase("Número Série", bodyFontHeader));
            cellNumeroSerie.BackgroundColor = new BaseColor(189, 192, 215);
            cellNumeroSerie.Border = Rectangle.NO_BORDER;
            eqptoRetiradoTable.AddCell(cellNumeroSerie);



            foreach (RetiradaEquipamentosViewModel eqptoRetirado in listaRetiradaEquipamentosFiltro)
            {

                PdfPCell[] cellsER1 = new PdfPCell[] { new PdfPCell(new Phrase(eqptoRetirado.IdProduto.ToString(),bodyFontSmall)),
                                    new PdfPCell(new Phrase(eqptoRetirado.Produto,bodyFontSmall)),
                                    new PdfPCell(new Phrase(eqptoRetirado.NumeroSerie,bodyFontSmall))};

                PdfPRow rowER1 = new PdfPRow(cellsER1);


                eqptoRetiradoTable.Rows.Add(rowER1);


            }


            documento.Add(eqptoRetiradoTable);

            documento.Add(new Paragraph(" "));

        }


    }
}