using Cadastro.web.Models;
using Cadastro.web.Services.IServices;
using Cadastro.web.Utils;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Cadastro.web.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/v1/Alunos";

        public AlunoService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<AlunoModel> CreateAluno(AlunoModel model)
        {
            var response = await _client.PostAsJson( BasePath, model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<AlunoModel>();
            else throw new Exception("Something went wrong when calling API");
        }

        public async Task<bool> DeleteAlunoById(long id)
        {
            var response = await _client.DeleteAsync($"{ BasePath}/{id}");
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<bool>();
            else
                throw new Exception("Something went wrong when calling API");
        }

        public async Task<IEnumerable<AlunoModel>> FindAll()
        {
            var response = await _client.GetAsync(BasePath);
           return await response.ReadContentAs<List<AlunoModel>>();
        }

        public async Task<AlunoModel> FindAlunoById(long id)
        {
            var response = await _client.GetAsync($"{ BasePath}/{id}");
            return await response.ReadContentAs<AlunoModel>();
        }

        public async Task<AlunoModel> UpdateAluno(AlunoModel model)
        {
            var response = await _client.PutAsJson(BasePath, model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<AlunoModel>();
            else throw new Exception("Something went wrong when calling API");
        }
    }
}
