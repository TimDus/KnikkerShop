using LibraryKnikker.Core.DAL.Data;
using LibraryKnikker.Core.DAL.Interfaces;

namespace LibraryKnikker.Core.DAL.Context.IContext
{
    public interface IProductContext : IGenericQueries<Product>
    {
        bool VeranderVoorraad(int Aantal);
    }
}
