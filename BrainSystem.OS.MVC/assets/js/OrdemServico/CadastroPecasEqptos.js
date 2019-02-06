$(".cadastropecascaplicadas").click(function () {
    $("#modCadastroPecasAplicadas").load("/CadastroPecasEqpto/ExibirCadastroPecaAplicadas", function () {
        $("#modCadastroPecasAplicadas").modal();
    })
});


$(".cadastrosolicitacaopecas").click(function () {
    $("#modCadastroSolicitacoesPecas").load("/CadastroPecasEqpto/ExibirCadastroSolicitacaoPeca", function () {
        $("#modCadastroSolicitacoesPecas").modal();
    })
});

$(".cadastroeqptoretirados").click(function () {
    $("#modCadastroRetiradaEquipamentos").load("/CadastroPecasEqpto/ExibirCadastroRetiradaEquipamento", function () {
        $("#modCadastroRetiradaEquipamentos").modal();
    })
});


function AbrirURLEspecial(url) {


    var id = $("#hdIdProdutoFalhado").val();

    var urlcomposta = url + id;

    $(location).attr('href', urlcomposta);
}
