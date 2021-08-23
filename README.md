# Fullbar
Teste de processo seletivo

## Como Usar
Faça o clone deste projeto em seu computador.

Pelo terminal, entre na pasta /Fullbar/Fullbar e de o seguinte comando.
```terminal
dotnet ef database update
```
após terminar a execução, abra o postman e acesse a seguinte url:

*Estudantes: 
  * Listar todos: api/student -> Http Get
  * Listar um estudante: api/student/{id} -> Http Get
  * Filtrar um estudante: api/student/search?name=nome&course=computação&ra=ra -> Http Get
  * deletar: api/student/{id} -> Http Delete
  * Atualizar: api/student/{id} -> Http Update
  * Criar: api/student -> Http Post

Para criar ou atualizar um estudante, no body da requisição envie um objeto json como no exemplo a seguir:
```json
{
    "name": "nome_estudante",
    "RA": "ra",
    "Period": "periodo",
    "Picture": "pic.png",
    "CourseId": id_do_curso:long
}
```

*Nota do estudante em determinada disciplina: 
  * Criar: api/grade -> Http Post
  * Atualizar: api/grade -> Http Update

Para criar a nota do estudante em uma disciplina, no body da requisição envie um objeto json como no exemplo a seguir:
```json
{
    "StudentID": id_do_estudante:long,
    "DisciplineID" : id_da_disciplina:long,
    "StudantGrade": nota:double
}
```


## Contribuição
Marco Bagdal

## Licença
[MIT](https://choosealicense.com/licenses/mit/)
