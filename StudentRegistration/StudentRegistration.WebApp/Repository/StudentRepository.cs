using System.Net.Http;
using System.Threading.Tasks;

namespace StudentRegistration.WebApp.Repository
{
    public class StudentRepository
    {
        private readonly HttpClient _client;

        public StudentRepository(HttpClient client)
        {
            _client = client;
        }

        public async Task<string> GetStudent(int id)
        {
            return ResponseResult(await _client.GetAsync("api/student" + "/" + id));
        }

        public async Task<string> GetStudents()
        {
            return ResponseResult(await _client.GetAsync("api/student"));
        }

        public async Task<string> PostStudent(StringContent studentContent)
        {
            return ResponseResult(await _client.PostAsync("api/student", studentContent));
        }

        public async Task<bool> PutStudent(int id, StringContent studentContent)
        {
            var response = await _client.PutAsync("api/student" + "/" + id, studentContent);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteStudent(int id)
        {
            var response = await _client.DeleteAsync("api/student" + "/" + id);

            return response.IsSuccessStatusCode;
        }

        public async Task<string> GetCourses()
        {
            return ResponseResult(await _client.GetAsync("api/student" + "/GetCourses"));
        }

        public string ResponseResult(HttpResponseMessage response)
        {
            return response.EnsureSuccessStatusCode().Content.ReadAsStringAsync().Result;
        }
    }
}
