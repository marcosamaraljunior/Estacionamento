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

            var retorno = await _gerenciadorEstadia.EntrarCarro(carro.Placa);

            if (retorno.TemErro())
            {
                return StatusCode(retorno.Erro.StatusCode, new { Mensagem = retorno.Erro.Mensagem });
            }
            else
            {
                return Ok(retorno.Resultado);
            }
        }

        [HttpGet("{placa}")]
        public IActionResult GetByPlaca(string placa)
        {

            var retorno = _gerenciadorEstadia.RetirarCarro(placa);

            if (retorno.TemErro())
            {
                return StatusCode(retorno.Erro.StatusCode, new { Mensagem = retorno.Erro.Mensagem });
            }
            else
            {
                return Ok(retorno.Resultado);
            }

        }
    }
}