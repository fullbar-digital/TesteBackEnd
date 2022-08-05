using AutoMapper;
using Cadastro.AlunosAPI.Data.ValueObject;
using Cadastro.AlunosAPI.Model;
using Cadastro.AlunosAPI.Model.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro.AlunosAPI.Repository
{
     public class AlunosRepository : IAlunosRepository
    {
        private readonly MySQLContext _context;
        private IMapper _mapper;

        public AlunosRepository(MySQLContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<AlunoVO>> FindAll()
        {
            List<Alunos> alunos = await _context.Alunos.ToListAsync();
            return _mapper.Map<List<AlunoVO>>(alunos);
        }

        public async Task<AlunoVO> FindById(long id)
        {
            Alunos aluno = 
                await _context.Alunos.Where(p=> p.Id == id)
                    .FirstOrDefaultAsync();
            return _mapper.Map<AlunoVO>(aluno);
        }

        
        public async Task<AlunoVO> Create(AlunoVO vo)
        {
            Alunos aluno = _mapper.Map<Alunos>(vo);
            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();
            return _mapper.Map<AlunoVO>(aluno);
        }

        public async Task<AlunoVO> Update(AlunoVO vo)
        {
            Alunos aluno = _mapper.Map<Alunos>(vo);
            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();
            return _mapper.Map<AlunoVO>(aluno);
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                Alunos aluno =
                await _context.Alunos.Where(p => p.Id == id)
                    .FirstOrDefaultAsync();
                if (aluno == null) return false;
                _context.Alunos.Remove(aluno);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

       
    }
}
