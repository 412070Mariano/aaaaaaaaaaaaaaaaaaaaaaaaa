using ParcialWebApi.Models;

namespace ParcialWebApi.Repositories
{
    public interface ICriptoRepository
    {
        List<Criptomoneda> GetByCategory(int categoria);
        bool Update(int id, double valor, string simbolo, DateTime fecha);

        bool inhabilitacion(int id);
    }
}
