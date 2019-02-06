$(".cadastrofuncionario").click(function () {
    $("#modCadastroFuncionario").load("/OrdemServico/ExibirCadastroFuncionario", function () {
        $("#modCadastroFuncionario").modal();
    })
});

