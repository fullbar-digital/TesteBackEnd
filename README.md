Criar uma aplicação web para cadastrar e gerenciar alunos.

## Cadastro de Alunos

### Criar um cadastro de alunos com os seguintes campos:
- Nome
- RA (Registro acadêmico)
- Período
- Curso
- Status
- Foto

### Criar um cadastro do Curso com os seguintes campos:
- Nome do Curso
- Diciplinas do Curso

### Criar um cadastro de Diciplinas com os seguintes campos:
- Nome do Diciplinas
- Nota Minima Aporvação

#### Regra de Negocio 
- Um curso pode ter varias diciplinas
- O Aluno precisa ter notas em cada diciplina que o curso contempla
- Ao listar os alunos o status do Aluno deverá ser aprovado ou reprovado na diciplina X, o que irá determinar seu status será a nota sendo maior que 7.0.
- O status não poderá ser editavel 

#### Listar alunos: 
- Trazer todas as informação relacionada ao aluno.

#### Filtrar alunos: 
- Criar filtro com Nome, RA,Curso e Status.

#### Alterar dados do aluno: 
- Somente o campo Status não será editavel os demais sim.

#### Excluir aluno:
- Excluir o aluno selecionado

#### Requisitos:
- Microsoft .Net c#
- ORM EntityFramework e banco SQL server
- No caso de escolher arquitetura API, não é necessario criar o frontend da aplicação, iremos testar via Postman

#### O nivel de conhecimento será avalido com a utilização das seguintes tecnologias:
- Teste Unitario 
- Ioc Container - Ninject
- WebAPi .NetCore 
- ORM

### O que esperamos de você ?
- Crie uma aplicação testável
- Crie um código organizado
- Crie um código de fácil manutenção

#### Submissão
Criar um fork desse projeto e entregar via pull request.
Prazo de Entrega em até 4 dias.


Boa Sorte!
