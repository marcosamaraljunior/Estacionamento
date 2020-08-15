using Dominio.DTOs;
using Dominio.Enums;
using Dominio.Interfaces.Servicos;
using Dominio.Modelos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controlles
{
    [ApiController]
    [Route("carro")]
    public class CarroController : ControllerBase
    {
        private readonly IGerenciadorDeCarros _gerenciador;

        public CarroController(IGerenciadorDeCarros gerenciador)
        {
            _gerenciador = gerenciador;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CarroDTO dadosCarro)
        {

            var resposta = await _gerenciador.CadastrarCarro(dadosCarro);
            if (resposta.TemErro())
            {
                return StatusCode(resposta.Erro.StatusCode, new { Mensagem = resposta.Erro.Mensagem });
            }
            else
            {
                return Created($"carro/{resposta.Resultado.Id}", resposta.Resultado.Id);
            }
        }

        [HttpGet("{placa}")]
        public async Task<IActionResult> Get(string placa)
        {
            var carro = await _gerenciador.BuscarCarroPorPlaca(placa);
            var dto = new CarroDTO
            {
                Placa = carro.Placa,
                Cor = carro.Cor.ToString(),
                Tamanho = carro.Tamanho.ToString(),
                Modelo = carro.Modelo
            };
            return Ok(dto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var carros = await _gerenciador.BuscarCarros();
            var dadosCarros = carros.Select(c => new CarroDTO
            {
                Placa = c.Placa,
                Cor = c.Cor.ToString(),
                Tamanho = c.Tamanho.ToString(),
                Modelo = c.Modelo
            });

            return Ok(dadosCarros);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CarroDTO dadosCarro)
        {
            var id = await _gerenciador.AtualizarCadastro(dadosCarro);
            return Created($"carro/{id}", id);
        }

        [HttpDelete("{placa}")]
        public IActionResult Delete(string placa)
        {
            _gerenciador.removerCadastroPorPlaca(placa);
            return Ok();
        }
    }
}