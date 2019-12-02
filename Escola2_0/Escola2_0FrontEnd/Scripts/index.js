const url = "http://localhost:59516/api/Alunos";

//#region ValidaStatusNota
function ValidaStatus(nota) {
    if (nota >= 7) {
        return "Aprovado"
    }
    else {
        return "Reprovado"
    }
}
//#endregion

//#region DeleteApi
function DeleteAluno(param) {
    var id = $(param).data("id");
    $.ajax({
        url: url + '/' + id,
        type: 'DELETE',
        success: function (result) {
            $(param).parents("tr").remove();
        }
    });
}
//#endregion


//#region ListAlunos
$(document).ready(function () {
    $('#btn-lista-alunos').click(function () {
        $.ajax({
            url,
            type: 'GET',
            dataType: 'json',
            success: function (response) {
                $('#tabela-alunos td').remove("");
                $('#info p').remove();
                var props = '';
                $.each(response, function (index, val) {
                    props += '<tr>';
                    props += '<td>' + val.id + '</td>';
                    props += '<td>' + val.nome + '</td>';
                    props += '<td>' + val.ra + '</td>';
                    props += '<td>' + val.curso + '</td>';
                    props += '<td>' + val.periodo + '</td>';
                    props += '<td>' + val.nota + '</td>';
                    props += '<td>' + ValidaStatus(val.nota) + '</td>';
                    props += "<td>" +
                        "<button id = 'btnExcluir' type='button' value='Deletar'" +
                        "onclick='DeleteAluno(this);' " +
                        "class='btn btn-default' " +
                        "data-id='" + val.id + "'>" +
                        "<i class='fa fa-close'></i>" +
                        "</button>" +
                        "</td >";
                    props += '</tr>';
                });
                $('#tabela-alunos').append(props);
            },
            error: function () {
                $('#info').html('<p>Ocorreu um erro, verifique a conexão com a api!</p>');
            }
        });
    });
    //Botao Limpar Lista
    $('#btnClear').click(function () {
        $('#tabela-alunos td').remove();
        $('#info p').remove();
    });
});
//#endregion





