using Domain.Entities;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Teste_Prático_Backend.Controllers 
{
    [Route("[controller]")]
    public class DiciplinaController : ControllerBase
    {
        IDiciplinaService diciplinas = new DiciplinaService();

        private readonly ILogger<DiciplinaController> _logger;

        public DiciplinaController(ILogger<DiciplinaController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "DiciplinaDetalhes")]
        public IEnumerable<Diciplinas> GetDiciplinas()
        {
            IEnumerable<Diciplinas> diciplina = new List<Diciplinas>();
            try
            {
                diciplina = diciplinas.GetAll();
            }
            catch (ApplicationException ex)
            {
                new HttpRequestException(ex.Message);
            }

            return diciplina;
        }

        [HttpPost(Name = "InserirDiciplina")]
        public string IserirDiciplina(Diciplinas diciplina)
        {
            try
            {
                this.diciplinas.Create(diciplina);
            }
            catch (ApplicationException ex)
            {
                new HttpRequestException(ex.Message);
            }

            return Ok(diciplina.Id).ToString();
        }

        [HttpPut(Name = "UpdateDiciplina")]
        public string UpdatreDiciplina(Diciplinas diciplina)
        {
            try
            {
                this.diciplinas.Update(diciplina);
            }
            catch (Exception ex)
            {
                new HttpRequestException(ex.Message);
            }

            return Ok(diciplina.Id).ToString();
        }

        [HttpDelete(Name = "ExcluirDiciplina")]
        public string DeleteDiciplina(int id)
        {
            try
            {
                this.diciplinas.Delete(id);
            }
            catch (Exception ex)
            {
                new HttpRequestException(ex.Message);
            }

            return Ok(diciplinas).ToString();

        }
    }
}
