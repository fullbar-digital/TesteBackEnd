const url = "http://localhost:59516/api/Alunos";

//#region EditarAluno
$(document).ready(function () {
    var $id = $('#alunoIdEdit');
    var $nome = $('#fieldNomeEdit');
    var $ra = $('#fieldRAEdit');
    var $periodo = $('#fieldPeriodoEdit');
    var $curso = $('#fieldCursoEdit');
    var $nota = $('#fieldNotaEdit');
    $('#btnCadastro').on('click', function () {
        var cadastro = {
            id: $id.val(),
            nome: $nome.val(),
            ra: $ra.val(),
            periodo: $periodo.val(),
            curso: $curso.val(),
            nota: $nota.val()
        }
        $.ajax({
            url: url + '/' + cadastro.id,
            type: 'PUT',
            contentType:
                "application/json;charset=utf-8",
            data: JSON.stringify(cadastro),
            success: function () {
                alert("Atualizado com sucesso")
            },
            error: function (error) {
                alert(error);
            }
        });
    });
});
//#endregion