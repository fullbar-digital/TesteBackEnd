###### Adicionar Aluno -> POST /api/aluno
{
    "nome": "Nome",
    "ra": "000000",
    "periodo": "Perioro",
    "curso":  
        {
            "nome": "Nome",
            "disciplinas": [
                {
                    "nome": "Nome",
                    "NotaMinimaAprovacao": 7
                },
                {
                    "nome": "Nome",
                    "NotaMinimaAprovacao": 7
                },
                {
                    "nome": "Nome",
                    "NotaMinimaAprovacao": 7
                }
            ]
        },
    "status": "Status",
    "foto": "file.png"
}

###### Deletar Aluno ->  DELETE /api/aluno/{id}

###### Atualizar Aluno ->  PUT /api/aluno/{id}
{
    "nome": "Update Nome",
    "ra": "Update RA",
    "periodo": "Update Perioro",
    "foto": "update_foto.png"
}

###### Buscar Todos os Aluno -> GET /api/aluno/all

###### Buscar Aluno Por Nome -> GET /api/aluno/get-by-nome/?nome={nome}

###### Buscar Aluno Por RA -> GET /api/aluno/get-by-ra/?ra={ra}

###### Buscar Aluno Por Curso -> GET /api/aluno/get-by-curso/?cursoId={curso}

###### Buscar Aluno Por Status -> GET /api/aluno/get-by-status/?status={status}
