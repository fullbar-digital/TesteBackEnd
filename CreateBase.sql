CREATE DATABASE database_aluno;
use database_aluno;
CREATE TABLE Aluno (
    Id int IDENTITY(1,1) PRIMARY KEY,
    Nome varchar(50),
    RA varchar(50),
    Periodo int,
    Curso varchar(255),
    Nota int
);