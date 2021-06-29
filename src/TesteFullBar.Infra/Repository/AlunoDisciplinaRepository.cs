using System.Collections.Generic;
using System.Threading.Tasks;
using TesteFullBar.Domain.Interfaces.Repository;
using TesteFullBar.Domain.Models;
using TesteFullBar.Infra.Context;
using Dapper;

namespace TesteFullBar.Infra.Repository
{
    public class AlunoDisciplinaRepository : EntityBaseRepository<AlunoDisciplina>, IAlunoDisciplinaRepository
    {
        private readonly DapperContext _dapperContext;

        public AlunoDisciplinaRepository(EntityContext context, DapperContext dapperContext)
            : base(context)
        {
            _dapperContext = dapperContext;
        }
        public IEnumerable<AlunoDisciplina> GetByAlunoIdAsync(int alunoId)
        {
            string query = "select * from AlunoDisciplina where alunoId = @alunoId";
            return _dapperContext.DapperConnection.Query<AlunoDisciplina>(query, new { alunoId });
        }

        public async Task<AlunoDisciplina> GetByIdAsync(int id)
        {
            string query = "select * from AlunoDisciplina where id = @id";
            return await _dapperContext.DapperConnection.QueryFirstOrDefaultAsync<AlunoDisciplina>(query, new { id });
        }
    }
}
