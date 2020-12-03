using System.Threading.Tasks;

namespace infra.Repositories
{
    public interface IRepositoryTaxaJuros
    {
        Task<decimal> RetornarTaxaJurosAsync();
    }
}
