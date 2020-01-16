using LibraryKnikker.Core.DAL.Data;
using LibraryKnikker.Core.DAL.Interfaces;
using System.Collections.Generic;

namespace LibraryKnikker.Core.DAL.Context.IContext
{
    public interface IBestellingContext : IGenericQueries<Bestelling>
    {
        List<Bestelling> GetAllFromUser(long Id);
    }
}
