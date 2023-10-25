using CalculodeSegurodeVeiculos.Models;

namespace CalculodeSegurodeVeiculos.Repository
{
    public interface ISeguradoRepository
    {
        IEnumerable<Segurado> GetAll();
        Segurado GetById(int id);
        void Add(Segurado segurado);
        void Update(Segurado segurado);
        void Delete(int id);
    }

    public class SeguradoRepository : ISeguradoRepository
    {
        private readonly AppDbContext _context;

        public SeguradoRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Segurado> GetAll()
        {
            return _context.Segurados.ToList();
        }

        public Segurado GetById(int id)
        {
            return _context.Segurados.FirstOrDefault(v => v.Id == id);
        }

        public void Add(Segurado segurado)
        {
            _context.Segurados.Add(segurado);
            _context.SaveChanges();
        }

        public void Update(Segurado segurado)
        {
            _context.Segurados.Update(segurado);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var segurado = GetById(id);
            _context.Segurados.Remove(segurado);
            _context.SaveChanges();
        }
    }

}
