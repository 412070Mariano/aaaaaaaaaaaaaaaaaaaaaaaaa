using ParcialWebApi.Models;

namespace ParcialWebApi.Repositories
{
    public class CriptoRepository : ICriptoRepository
    {
        private readonly CriptoContext _context;

        public CriptoRepository(CriptoContext criptoContext)
        {
            _context = criptoContext;   
        }

        public List<Criptomoneda> GetByCategory(int categoria)
        {
            return _context.Criptomonedas.Where(x => x.CategoriaNavigation.Id == categoria).Where(xe => xe.UltimaActualizacion >= DateTime.Today.AddDays(-1)).Where(xes => xes.Estado!="NH").ToList();
        }

        public bool inhabilitacion(int id)
        {
            var desabilitar = _context.Criptomonedas.Find(id);
            if (desabilitar != null)
            {
                desabilitar.Estado = "NH";
                _context.Criptomonedas.Update(desabilitar);
            }
            return _context.SaveChanges()>0;
        }

        public bool Update(int id, double valor, string simbolo, DateTime fecha)
        {
            var criptoActual = _context.Criptomonedas.Find(id);
            var criptoActualizar = _context.Criptomonedas.Where(x => x.Simbolo == simbolo).ToList();

            if (valor != null && simbolo != null && criptoActual != null && fecha != null)
            {
                criptoActual.ValorActual = valor;
                criptoActual.UltimaActualizacion = fecha;
                if (criptoActualizar != null)
                {
                    _context.Criptomonedas.Update(criptoActual);
                }
            }
            return _context.SaveChanges() > 0;
        }
    }
}
