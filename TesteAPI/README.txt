============ PONTOS DE ATENÇÃO ============

Existem alguns pontos de falha os quais eu precisaria de mais tempo para correção, entre eles estão:

1 - Autenticação via JWTBearer, foi configurado, porém apresentou falha em métodos de Authorize em outros controllers que não fossem o que foi realizado a criação do Token.

2 - Melhor tratativa dos dados e a criação de uma BLL específica para isso, para tratar todos os dados obrigatórios e retornar o respectivo código HTTP em tela.

3 - AutoMapper com injeção de dependência enquanto outros que poderiam utilizar não possuem.

4 - O RA é utilizado como filtro para quase todos os métodos de aluno e ele pode ser editável, o que pode acarretar em uma grande inconsistência no dia a dia.



Também existem alguns pontos considerados redundantes, porém foram inseridos com a finalidade de demonstrar o conhecimento em diferentes formatos de programação.

1 - Criar VO com JsonProperty, pois pode ser feito direto na classe.



============ ORIENTAÇÕES ============

O banco foi estruturado em SQL SERVER, deixei o script de criaçao das tabelas junto com os drops na pasta "Documentos" chamado "Estrutura.SQL"



============ TESTE - CAMINHO FELIZ ============
Jsons de Exemplo


1) Cadastro de Curso:
url: https://localhost:44392/api/v1/Curso/Create
Json:
{
  "nome": "Ensino Medio",
  "disciplinas": [
    {
      "nome": "Matematica",
      "nota_Aprovacao": 6
    },
	{
      "nome": "Portugues",
      "nota_Aprovacao": 5
    },
	{
      "nome": "Proerd",
      "nota_Aprovacao": 7
    }
  ]
}



2) Utilizando o endpoint de Cadastro de Aluno:
url: https://localhost:44392/api/v1/Aluno/Create

Json:

{
  "nome": "Gabriel Lima",
  "registro_Academico": "789456",
  "periodo": "Manhã",
  "nome_Curso": "Ensino Medio",
  "status": "",  
  "notas": [    
  ]
}



3) Cadastrando notas
Url: https://localhost:44392/api/v1/AlunoNota/Create
Json:
{
  "raAluno": "789456",
  "notas": [
    {
      "disciplina_Nome": "Matematica",
      "nota": 6
    },
	{
      "disciplina_Nome": "Portugues",
      "nota": 7
    },
	{
      "disciplina_Nome": "Proerd",
      "nota": 8
    }
  ]
}

4) Consultando Alunos:
url: https://localhost:44392/api/v1/Aluno/GetAll


