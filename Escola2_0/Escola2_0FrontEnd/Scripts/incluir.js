const url = "http://localhost:59516/api/Alunos";

//#region IncluirNovoAluno
$(document).ready(function () {
    var $nome = $('#fieldNome');
    var $ra = $('#fieldRA');
    var $periodo = $('#fieldPeriodo');
    var $curso = $('#fieldCurso');
    var $nota = $('#fieldNota');

    $('#btnIncluir').on('click', function () {
        var cadastro = {
            nome: $nome.val(),
            ra: $ra.val(),
            periodo: $periodo.val(),
            curso: $curso.val(),
            nota: $nota.val()
        }
        $.ajax({
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            type: 'POST',
            url,
            data: JSON.stringify(cadastro),
            success: function (result) {
                $("#incluirForm")[0].reset();
                alert("Cadastrado com sucesso");
            },
            error: function () {
                alert("Erro ao incluir Aluno");
            }
        });
    });
});
//#endregion