using KnikkerShop.Interfaces;
using KnikkerShop.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnikkerShop.Context.IContext
{
    public interface IBestellingContext : IGenericQueries<Bestelling>
    {
        List<Bestelling> GetAllFromUser(long Id);
    }
}
