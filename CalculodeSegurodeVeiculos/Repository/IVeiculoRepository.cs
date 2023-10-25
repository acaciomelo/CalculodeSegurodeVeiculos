using CalculodeSegurodeVeiculos.Models;

namespace CalculodeSegurodeVeiculos.Repository
{
    public interface IVeiculoRepository
    {
        IEnumerable<Veiculo> GetAll();
        Veiculo GetById(int id);
        void Add(Veiculo veiculo);
        void Update(Veiculo veiculo);
        void Delete(int id);
    }

    public class VeiculoRepository : IVeiculoRepository
    {
        private readonly AppDbContext _context;

        public VeiculoRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Veiculo> GetAll()
        {
            return _context.Veiculos.ToList();
        }

        public Veiculo GetById(int id)
        {
            return _context.Veiculos.FirstOrDefault(v => v.Id == id);
        }

        public void Add(Veiculo veiculo)
        {
            _context.Veiculos.Add(veiculo);
            _context.SaveChanges();
        }

        public void Update(Veiculo veiculo)
        {
            _context.Veiculos.Update(veiculo);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var veiculo = GetById(id);
            _context.Veiculos.Remove(veiculo);
            _context.SaveChanges();
        }
    }

}
