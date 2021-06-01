
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/01/2021 00:18:02
-- Generated from EDMX file: C:\Users\Vitoria\source\repos\faculdade2\faculdade2\Model\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DBFacul];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Aluno'
CREATE TABLE [dbo].[Aluno] (
    [IdAluno] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [RA] nvarchar(max)  NOT NULL,
    [Período] nvarchar(max)  NOT NULL,
    [Curso] nvarchar(max)  NOT NULL,
    [Status] nvarchar(max)  NOT NULL,
    [Foto] nvarchar(max)  NOT NULL,
    [IdCurso] int  NOT NULL
);
GO

-- Creating table 'Curso'
CREATE TABLE [dbo].[Curso] (
    [IdCurso] int IDENTITY(1,1) NOT NULL,
    [NomeCurso] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Disciplina'
CREATE TABLE [dbo].[Disciplina] (
    [IdDisciplina] int IDENTITY(1,1) NOT NULL,
    [NomeDisciplina] nvarchar(max)  NOT NULL,
    [NotaMinima] float  NOT NULL,
    [IdCurso] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdAluno] in table 'Aluno'
ALTER TABLE [dbo].[Aluno]
ADD CONSTRAINT [PK_Aluno]
    PRIMARY KEY CLUSTERED ([IdAluno] ASC);
GO

-- Creating primary key on [IdCurso] in table 'Curso'
ALTER TABLE [dbo].[Curso]
ADD CONSTRAINT [PK_Curso]
    PRIMARY KEY CLUSTERED ([IdCurso] ASC);
GO

-- Creating primary key on [IdDisciplina] in table 'Disciplina'
ALTER TABLE [dbo].[Disciplina]
ADD CONSTRAINT [PK_Disciplina]
    PRIMARY KEY CLUSTERED ([IdDisciplina] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [IdCurso] in table 'Disciplina'
ALTER TABLE [dbo].[Disciplina]
ADD CONSTRAINT [FK_DisciplinaCurso]
    FOREIGN KEY ([IdCurso])
    REFERENCES [dbo].[Curso]
        ([IdCurso])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DisciplinaCurso'
CREATE INDEX [IX_FK_DisciplinaCurso]
ON [dbo].[Disciplina]
    ([IdCurso]);
GO

-- Creating foreign key on [IdCurso] in table 'Aluno'
ALTER TABLE [dbo].[Aluno]
ADD CONSTRAINT [FK_AlunoCurso]
    FOREIGN KEY ([IdCurso])
    REFERENCES [dbo].[Curso]
        ([IdCurso])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AlunoCurso'
CREATE INDEX [IX_FK_AlunoCurso]
ON [dbo].[Aluno]
    ([IdCurso]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------