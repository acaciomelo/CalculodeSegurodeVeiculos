using CalculodeSegurodeVeiculos.Models;
using CalculodeSegurodeVeiculos.Repository;
using CalculodeSegurodeVeiculos.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CalculodeSegurodeVeiculos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeguroController : ControllerBase
    {
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly ISeguradoRepository _seguradoRepository;
        private readonly ISeguroRepository _seguroRepository;
        private readonly ISeguroService _seguroService;

        public SeguroController(
            IVeiculoRepository veiculoRepository,
            ISeguradoRepository seguradoRepository,
            ISeguroRepository seguroRepository,
            ISeguroService seguroService)
        {
            _veiculoRepository = veiculoRepository;
            _seguradoRepository = seguradoRepository;
            _seguroRepository = seguroRepository;
            _seguroService = seguroService;
        }

        // Método para gravar o seguro
        [HttpPost]
        [AllowAnonymous]
        public IActionResult CreateSeguro(SeguroInputModel inputModel)
        {
            var veiculo = new Veiculo
            {
                Valor = inputModel.ValorVeiculo,
                Marca = inputModel.Marca,
                Modelo = inputModel.Modelo
            };
            _veiculoRepository.Add(veiculo);

            var segurado = new Segurado
            {
                Nome = inputModel.Nome,
                CPF = inputModel.CPF,
                Idade = inputModel.Idade
            };
            _seguradoRepository.Add(segurado);

            var valorSeguro = _seguroService.CalcularSeguro(veiculo);
            var seguro = new Seguro
            {
                ValorSeguro = valorSeguro,
                Veiculo = veiculo,
                Segurado = segurado
            };
            _seguroRepository.Add(seguro);

            return CreatedAtAction(nameof(GetSeguroById), new { id = seguro.Id }, seguro);
        }

        // Método para pesquisar o seguro pelo ID
        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult GetSeguroById(int id)
        {
            var seguro = _seguroRepository.GetById(id);
            if (seguro == null) return NotFound();
            return Ok(seguro);
        }

        // Método para gerar o relatório
        [HttpGet("relatorio/media")]
        [AllowAnonymous]
        public IActionResult GetMediaSeguros()
        {
            var seguros = _seguroRepository.GetAll();
            var media = seguros.Average(s => s.ValorSeguro);
            return Ok(new { Media = media });
        }

        // Método para calcular o valor do seguro
        [HttpGet("calcular/{id}")]
        [AllowAnonymous]
        public IActionResult CalcularSeguro(int id)
        {
            var veiculo = _veiculoRepository.GetById(id);
            var valorSeguro = _seguroService.CalcularSeguro(veiculo);

            return Ok(valorSeguro);
        }
    }

    // Classe auxiliar para entrada de dados
    public class SeguroInputModel
    {
        public decimal ValorVeiculo { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public int Idade { get; set; }
    }


}
