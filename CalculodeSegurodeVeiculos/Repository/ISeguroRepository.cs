using CalculodeSegurodeVeiculos.Models;

namespace CalculodeSegurodeVeiculos.Repository
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;

    public interface ISeguroRepository
    {
        /// <summary>
        /// Adiciona um novo seguro ao repositório.
        /// </summary>
        /// <param name="seguro">O seguro a ser adicionado.</param>
        void Add(Seguro seguro);

        /// <summary>
        /// Obtém um seguro pelo ID.
        /// </summary>
        /// <param name="id">O ID do seguro.</param>
        /// <returns>O seguro encontrado ou null se não existir.</returns>
        Seguro GetById(int id);

        /// <summary>
        /// Obtém todos os seguros do repositório.
        /// </summary>
        /// <returns>Uma lista de seguros.</returns>
        IEnumerable<Seguro> GetAll();

        /// <summary>
        /// Atualiza um seguro existente.
        /// </summary>
        /// <param name="seguro">O seguro atualizado.</param>
        void Update(Seguro seguro);

        /// <summary>
        /// Remove um seguro pelo ID.
        /// </summary>
        /// <param name="id">O ID do seguro.</param>
        void Remove(int id);
    }

    public class SeguroRepository : ISeguroRepository
    {
        private readonly AppDbContext _context;

        public SeguroRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Seguro seguro)
        {
            _context.Seguros.Add(seguro);
            _context.SaveChanges();
        }

        public Seguro GetById(int id)
        {
            return _context.Seguros
                .Include(s => s.Veiculo)   // Carrega o veículo associado ao seguro
                .Include(s => s.Segurado)  // Carrega o segurado associado ao seguro
                .FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<Seguro> GetAll()
        {
            return _context.Seguros
                .Include(s => s.Veiculo)   // Carrega o veículo associado ao seguro
                .Include(s => s.Segurado)  // Carrega o segurado associado ao seguro
                .ToList();
        }

        public void Update(Seguro seguro)
        {
            // Neste caso, você já está passando uma entidade que está sendo rastreada pelo Entity Framework.
            // Se não estiver sendo rastreada, você terá que anexar e definir seu estado para modificado.
            _context.Entry(seguro).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            var seguro = _context.Seguros.Find(id);
            if (seguro != null)
            {
                _context.Seguros.Remove(seguro);
                _context.SaveChanges();
            }
        }
    }
}
