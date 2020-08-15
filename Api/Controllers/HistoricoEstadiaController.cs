using System.Threading.Tasks;
using Dominio.Interfaces.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("estadias/hist")]
    public class HistoricoEstadiaController : ControllerBase
    {

        private readonly IGerenciadorHistoricoEstadias _gerenciadorHistorico;

        public HistoricoEstadiaController(IGerenciadorHistoricoEstadias gerenciador)
        {
            _gerenciadorHistorico = gerenciador;
        }

        [HttpGet]

        public async Task<IActionResult> Get()
        {
            var estadias = await _gerenciadorHistorico.BuscarEstadias();

            return Ok(estadias);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            _gerenciadorHistorico.DeletarEstadias();
            return Ok();
        }
    }
}