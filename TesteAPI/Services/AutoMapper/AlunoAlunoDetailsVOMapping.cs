using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace TesteAPI.Services.AutoMapper
{
    public class AlunoAlunoDetailsVOMapping : Profile
    {
        DAL.Repositories.Interfaces.IUnitOfWork _uow;

        public AlunoAlunoDetailsVOMapping(DAL.Repositories.Interfaces.IUnitOfWork uow)
        {
            _uow = uow;

            CreateMap<MLL.ViewObject.AlunoDetailsVO, MLL.Aluno>()
               .ForMember(dest => dest.Nome, ori => ori.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Periodo, ori => ori.MapFrom(src => src.Periodo))
                .ForMember(dest => dest.Status, ori => ori.MapFrom(src => src.Status))
                .ForMember(dest => dest.Registro_Academico, ori => ori.MapFrom(src => src.Registro_Academico))
                .ForMember(dest => dest.Notas, ori => ori.MapFrom(src => GetNotas(src)))
                //.ForMember(dest => dest.Foto, ori => ori.MapFrom(src => src.Foto))               
                ;


            CreateMap<MLL.Aluno, MLL.ViewObject.AlunoDetailsVO>()
                .ForMember(dest => dest.Nome, ori => ori.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Periodo, ori => ori.MapFrom(src => src.Periodo))
                .ForMember(dest => dest.Status, ori => ori.MapFrom(src => src.Status))
                .ForMember(dest => dest.Nome_Curso, ori => ori.MapFrom(src => src.Curso.Nome))
                .ForMember(dest => dest.Registro_Academico, ori => ori.MapFrom(src => src.Registro_Academico))
                .ForMember(dest => dest.Notas, ori => ori.MapFrom(src => GetNotasVO(src)))
                ;
           
        }

        public int GetCurso(string cursoNome)
        {
            return _uow.CursoRepositorio.GetAll(x => x.Nome == cursoNome).FirstOrDefault().Codigo;
        }

        public MLL.Curso GetCursoByID(int cursoCodigo)
        {
            return _uow.CursoRepositorio.GetByID(cursoCodigo);
        }

        public List<MLL.AlunoNota> GetNotas(MLL.ViewObject.AlunoDetailsVO alunoDetailsVO)
        {
            List<MLL.AlunoNota> listaNotas = new List<MLL.AlunoNota>();

            foreach (MLL.ViewObject.AlunoNotaVO nota in alunoDetailsVO.Notas)
            {
                var notaMapeada = new MLL.AlunoNota
                {
                    DisciplinaCodigo = _uow.DisciplinaRepositorio.GetAll(x => x.Curso.Nome == alunoDetailsVO.Nome_Curso && x.Nome == nota.Disciplina_Nome).FirstOrDefault().Codigo,
                    Nota = nota.Nota
                };

                listaNotas.Add(notaMapeada);
            }

            return listaNotas;
        }

        public List<MLL.ViewObject.AlunoNotaVO> GetNotasVO(MLL.Aluno aluno)
        {
            List<MLL.ViewObject.AlunoNotaVO> listaNotas = new List<MLL.ViewObject.AlunoNotaVO>();

            foreach (MLL.AlunoNota nota in aluno.Notas)
            {
                var notaMapeada = new MLL.ViewObject.AlunoNotaVO
                {
                    Disciplina_Nome = nota.Disciplina.Nome,
                    Nota = nota.Nota
                };

                listaNotas.Add(notaMapeada);
            }

            return listaNotas;
        }


    }
}
