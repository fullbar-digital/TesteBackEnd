USE TesteBackendFullbarDb
GO

SELECT	Alunos.Ra,
		Alunos.Nome,
		Alunos.Periodo,
		Cursos.Nome as Curso,
		Cursos.Id as [Curso ID],
		CASE Alunos.Status
			WHEN 1 THEN 'Aprovado'
			WHEN 2 THEN 'Reprovado'
			ELSE ''
		END AS [Status no Curso],
		Disciplinas.Nome as [Disciplina],
		Disciplinas.NotaMinimaAprovacao,
		Disciplinas.Id as [Disciplina ID],
		Matriculas.Nota,
		CASE Matriculas.Status
			WHEN 0 THEN 'Reprovado'
			WHEN 1 THEN 'Aprovado'
			ELSE ''
		END AS [Status Disc],
		Matriculas.Status as [MatricStatus],
		Alunos.Foto
FROM	Alunos
		LEFT JOIN Cursos ON Alunos.CursoId = Cursos.Id
		LEFT JOIN Matriculas ON Alunos.Ra = Matriculas.AlunoRa
		LEFT JOIN Disciplinas ON Matriculas.DisciplinaId = Disciplinas.Id
WHERE	Alunos.Ra = 2


SELECT	Cursos.Id,
		Cursos.Nome as Curso,
		Disciplinas.Id AS DisciplinaID,
		Disciplinas.Nome AS Disciplina,
		COUNT(Matriculas.DisciplinaId) AS [Qtd Alunos]
FROM	Cursos
		LEFT JOIN Disciplinas ON Cursos.Id = Disciplinas.CursoId
		LEFT JOIN Matriculas ON Disciplinas.Id = Matriculas.DisciplinaId
WHERE	Cursos.Id = 1
GROUP BY Cursos.Id,
		Cursos.Nome,
		Disciplinas.Id,
		Disciplinas.Nome


SELECT	Cursos.Id,
		Cursos.Nome,
		Count(Disciplinas.Id) as Qtd
FROM	Cursos
		LEFT JOIN Disciplinas ON Cursos.Id = Disciplinas.CursoId
GROUP BY Cursos.Id,
		Cursos.Nome

