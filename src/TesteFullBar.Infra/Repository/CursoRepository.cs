using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteFullBar.Domain.Interfaces.Repository;
using TesteFullBar.Domain.Models;
using TesteFullBar.Infra.Context;

namespace TesteFullBar.Infra.Repository
{
    public class CursoRepository : EntityBaseRepository<Curso>, ICursoRepository
    {
        private readonly DapperContext _dapperContext;

        public CursoRepository(EntityContext context, DapperContext dapperContext)
            : base(context)
        {
            _dapperContext = dapperContext;
        }

        public async Task<IEnumerable<Curso>> GetAll()
        {
            string query = "select * from curso";
            return await _dapperContext.DapperConnection.QueryAsync<Curso>(query);
        }

        public async Task<Curso> GetByDescricaoAsync(string descricao)
        {
            string query = "select * from curso where descricao=@descricao";
            return await _dapperContext.DapperConnection.QueryFirstOrDefaultAsync<Curso>(query, new { descricao });
        }

        public async Task<Curso> GetByIdAsync(int id)
        {
            string query = "select * from curso where id=@id";
            return await _dapperContext.DapperConnection.QueryFirstOrDefaultAsync<Curso>(query, new { id });
        }
    }
}