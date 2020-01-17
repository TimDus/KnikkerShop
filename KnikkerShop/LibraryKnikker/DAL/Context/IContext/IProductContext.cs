using LibraryKnikker.Core.DAL.Data;
using LibraryKnikker.Core.DAL.Interfaces;
using System.Collections.Generic;

namespace LibraryKnikker.Core.DAL.Context.IContext
{
    public interface IProductContext : IGenericQueries<Product>
    {
        bool VeranderVoorraad(int Aantal);
        List<Product> Zoeken(string Zoekterm);
    }
}
