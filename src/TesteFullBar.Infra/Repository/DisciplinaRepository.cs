using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteFullBar.Domain.Interfaces.Repository;
using TesteFullBar.Domain.Models;
using TesteFullBar.Infra.Context;

namespace TesteFullBar.Infra.Repository
{
    public class DisciplinaRepository : EntityBaseRepository<Disciplina>, IDisciplinaRepository
    {
        private readonly DapperContext _dapperContext;

        public DisciplinaRepository(EntityContext context, DapperContext dapperContext)
            : base(context)
        {
            _dapperContext = dapperContext;
        }                

        public IEnumerable<Disciplina> GetByIdsAsync(List<int> ids)
        {
            string query = "select * from disciplina where id in @ids";
            return _dapperContext.DapperConnection.Query<Disciplina>(query, new { ids });
        }

        public async Task<IEnumerable<Disciplina>> GetAll()
        {
            string query = "select * from disciplina";
            return await _dapperContext.DapperConnection.QueryAsync<Disciplina>(query);
        }

        public async Task<Disciplina> GetByDescricaoAsync(string descricao)
        {
            string query = "select * from disciplina where descricao=@descricao";
            return await _dapperContext.DapperConnection.QueryFirstOrDefaultAsync<Disciplina>(query, new { descricao });
        }

        public async Task<Disciplina> GetByIdAsync(int id)
        {
            string query = "select * from disciplina where id=@id";
            return await _dapperContext.DapperConnection.QueryFirstOrDefaultAsync<Disciplina>(query, new { id });
        }
    }
}
