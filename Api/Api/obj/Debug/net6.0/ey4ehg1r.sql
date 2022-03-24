IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Cursos] (
    [CursoID] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Cursos] PRIMARY KEY ([CursoID])
);
GO

CREATE TABLE [Disciplinas] (
    [DisciplinaID] int NOT NULL IDENTITY,
    [NotaMinimaAprovacao] int NOT NULL,
    CONSTRAINT [PK_Disciplinas] PRIMARY KEY ([DisciplinaID])
);
GO

CREATE TABLE [Alunos] (
    [AlunoID] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    [RA] int NOT NULL,
    [Periodo] nvarchar(max) NOT NULL,
    [CursoID] int NOT NULL,
    [Status] nvarchar(max) NOT NULL,
    [Foto] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Alunos] PRIMARY KEY ([AlunoID]),
    CONSTRAINT [FK_Alunos_Cursos_CursoID] FOREIGN KEY ([CursoID]) REFERENCES [Cursos] ([CursoID]) ON DELETE CASCADE
);
GO

CREATE TABLE [CursoDisciplina] (
    [CursoID] int NOT NULL,
    [DisciplinaID] int NOT NULL,
    CONSTRAINT [PK_CursoDisciplina] PRIMARY KEY ([CursoID], [DisciplinaID]),
    CONSTRAINT [FK_CursoDisciplina_Cursos_CursoID] FOREIGN KEY ([CursoID]) REFERENCES [Cursos] ([CursoID]) ON DELETE CASCADE,
    CONSTRAINT [FK_CursoDisciplina_Disciplinas_DisciplinaID] FOREIGN KEY ([DisciplinaID]) REFERENCES [Disciplinas] ([DisciplinaID]) ON DELETE CASCADE
);
GO

CREATE TABLE [AlunoDisciplina] (
    [AlunoID] int NOT NULL,
    [DisciplinaID] int NOT NULL,
    [Nota] int NOT NULL,
    CONSTRAINT [PK_AlunoDisciplina] PRIMARY KEY ([AlunoID], [DisciplinaID]),
    CONSTRAINT [FK_AlunoDisciplina_Alunos_AlunoID] FOREIGN KEY ([AlunoID]) REFERENCES [Alunos] ([AlunoID]) ON DELETE CASCADE,
    CONSTRAINT [FK_AlunoDisciplina_Disciplinas_DisciplinaID] FOREIGN KEY ([DisciplinaID]) REFERENCES [Disciplinas] ([DisciplinaID]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_AlunoDisciplina_DisciplinaID] ON [AlunoDisciplina] ([DisciplinaID]);
GO

CREATE INDEX [IX_Alunos_CursoID] ON [Alunos] ([CursoID]);
GO

CREATE INDEX [IX_CursoDisciplina_DisciplinaID] ON [CursoDisciplina] ([DisciplinaID]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220319194510_ApiAluno', N'6.0.3');
GO

COMMIT;
GO

