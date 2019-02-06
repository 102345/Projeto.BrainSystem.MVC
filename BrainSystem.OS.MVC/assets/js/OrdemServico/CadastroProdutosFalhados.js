

$(".cadastroprodfalhado").click(function () {
    $("#modCadastroProdutosFalhados").load("/FluxoAtendimento/ExibirCadastroProdutosFalhados", function () {
        $("#modCadastroProdutosFalhados").modal();
    })
});

//$(".remove").click(function () {
//    var id = $(this).attr("data-id");
//    $(document).load("/FluxoAtendimento/Delete?id=" + id);


//});

//Abre nova pagina de acordo com escolha de linha da Grid 
//$(document).ready(function ($) {
//    $(".table-row").click(function () {
//        window.document.location = $(this).data("href");
//    });
//});

function FiltrarLocalizacaoFalha(pIdProduto) {

    document.getElementById("divComboLocalizacaoFalha").style.display = "block";
    document.getElementById("divComboDetalhamentoFalha").style.display = "block";
    document.getElementById("divComboAcaoCorretiva").style.display = "block";
    document.getElementById("divComboSolucaoAdotada").style.display = "block";


    var retorno = false;


    if (pIdProduto.val() == '') {
        retorno = true;
    }

    if (retorno)
        return;

    vURL = "/FluxoAtendimento/ExibirListaLocalizacaoFalha";


    $.ajax({
        url: vURL,
        data: {
            'idProduto': $(pIdProduto).val()
        },
        type: 'POST',
        cache: false,
        success: function (data) {

            $("#divComboLocalizacaoFalha").html(data);

        },
        error: function (request, status, error) {
            //alert(request.status); //alert(error);

        }
    });

    //alert('entrei dois');

    vURL1 = "/FluxoAtendimento/ExibirListaDelhamentoFalha";


    $.ajax({
        url: vURL1,
        data: {
            'idProduto': $(pIdProduto).val()
        },
        type: 'POST',
        cache: false,
        success: function (data) {

            $("#divComboDetalhamentoFalha").html(data);

        },
        error: function (request, status, error) {
            //alert(request.status); //alert(error);

        }
    });


    vURL2 = "/FluxoAtendimento/ExibirListaAcoesCorretivas";


    $.ajax({
        url: vURL2,
        data: {
            'idProduto': $(pIdProduto).val()
        },
        type: 'POST',
        cache: false,
        success: function (data) {

            $("#divComboAcaoCorretiva").html(data);

        },
        error: function (request, status, error) {
            //alert(request.status); //alert(error);

        }
    });


    vURL3 = "/FluxoAtendimento/ExibirListaSolucoesAdotadas";


    $.ajax({
        url: vURL3,
        data: {
            'idProduto': $(pIdProduto).val()
        },
        type: 'POST',
        cache: false,
        success: function (data) {

            $("#divComboSolucaoAdotada").html(data);

        },
        error: function (request, status, error) {
            //alert(request.status); //alert(error);

        }
    });



}