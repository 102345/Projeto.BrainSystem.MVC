
//$('#DataPreenchimento').datepicker().val('');
//$('#HoraChegada').timepicker().val('');
//$('#HoraInicio').timepicker().val('');
//$('#HoraTermino').timepicker().val('');
//$('#HoraSaida').timepicker().val('');

$(document).ready(function () {
    $('.datepicker').datepicker({
        format: 'dd/mm/yyyy',
        language: 'pt-BR'
    });
});

//$(function () {
//    $('#datetimepicker3').datetimepicker({
//        format: 'HH:mm',
//        language: 'pt-BR'
//    });
//});