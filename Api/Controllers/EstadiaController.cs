using Dominio.DTOs;
using Dominio.Interfaces.Servicos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controlles
{
    [ApiController]
    [Route("estadias")]
    public class EstadiaController : ControllerBase
    {
        private readonly IGerenciadorDeEstadia _gerenciadorEstadia;

        public EstadiaController(IGerenciadorDeEstadia gerenciador)
        {
            _gerenciadorEstadia = gerenciador;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CarroDTO carro)
        {

            var resultado = await _gerenciadorEstadia.EntrarCarro(carro.Placa);

            if (resultado.TemErro())
            {
                return StatusCode(resultado.Erro.StatusCode, new { Mensagem = resultado.Erro.Mensagem });
            }
            else
            {
                return Ok(resultado);
            }
        }

        [HttpGet("{placa}")]
        public IActionResult GetByPlaca(string placa)
        {

            var resultado = _gerenciadorEstadia.RetirarCarro(placa);

            if (resultado.TemErro())
            {
                return StatusCode(resultado.Erro.StatusCode, new { Mensagem = resultado.Erro.Mensagem });
            }
            else
            {
                return Ok(resultado);
            }

        }
    }
}