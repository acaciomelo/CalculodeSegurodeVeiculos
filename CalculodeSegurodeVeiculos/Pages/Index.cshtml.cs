using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CalculodeSegurodeVeiculos.Services;
using CalculodeSegurodeVeiculos.Repository;
using CalculodeSegurodeVeiculos.Models;

namespace CalculodeSegurodeVeiculos.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly ISeguradoRepository _seguradoRepository;
        private readonly ISeguroRepository _seguroRepository;
        private readonly ISeguroService _seguroService;

        public IndexModel(
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

        public IEnumerable<Seguro> Seguros { get; set; }
        public decimal Media { get; set; }
        public void OnGet()
        {
            Seguros = _seguroRepository.GetAll();

            if (Seguros.Any())
            {
                Media = Seguros.Average(s => s.ValorSeguro);
            }
        }
    }
}