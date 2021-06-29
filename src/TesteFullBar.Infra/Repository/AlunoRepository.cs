using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteFullBar.Domain.Interfaces.Repository;
using TesteFullBar.Domain.Models;
using TesteFullBar.Domain.Models.Dapper;
using TesteFullBar.Infra.Context;

namespace TesteFullBar.Infra.Repository
{
    public class AlunoRepository : EntityBaseRepository<Aluno>, IAlunoRepository
    {
        private readonly DapperContext _dapperContext;

        public AlunoRepository(EntityContext context, DapperContext dapperContext)
            : base(context)
        {
            _dapperContext = dapperContext;
        }

        public async Task<IEnumerable<AlunoQuery>> GetByFilterAsync(string ra, string nome, int? curso, string status)
        {
            var query = @"SELECT  aluno.Id,aluno.Nome,aluno.Ra,aluno.Status,Aluno.CursoId, c.Descricao as CursoDescricao from aluno
                        join curso c on aluno.CursoId = c.id 
                       ";

            List<string> filters = new List<string>();

            if (!string.IsNullOrWhiteSpace(ra))
            {
                filters.Add(" aluno.Ra = @ra ");
            }

            if (!string.IsNullOrWhiteSpace(nome))
            {
                filters.Add(" aluno.Nome = @nome ");
            }

            if (!string.IsNullOrWhiteSpace(status))
            {
                filters.Add(" aluno.status = @status ");
            }

            if (curso.GetValueOrDefault() > 0)
            {
                filters.Add(" aluno.CursoId = @curso ");
            }

            query += "where " + string.Join(" and ", filters);

            return await _dapperContext.DapperConnection.QueryAsync<AlunoQuery>(query, new { ra, nome, curso, status });

        }

        public async Task<Aluno> GetByIdAsync(int id)
        {
            var query = @"SELECT aluno.* from aluno
                          WHERE id = @id";

            return await _dapperContext.DapperConnection.QueryFirstOrDefaultAsync<Aluno>(query, new { id });
        }

        public async Task<Aluno> GetByRaAsync(string ra)
        {
            var query = @"SELECT aluno.* from aluno
                          WHERE ra = @ra";

            return await _dapperContext.DapperConnection.QueryFirstOrDefaultAsync<Aluno>(query, new { ra });
        }
    }
}
