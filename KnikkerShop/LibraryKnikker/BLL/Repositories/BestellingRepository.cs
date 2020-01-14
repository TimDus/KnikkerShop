using LibraryKnikker.Core.DAL.Context.IContext;
using LibraryKnikker.Core.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryKnikker.Core.BLL.Repositories
{
    public class BestellingRepository
    {
        private readonly IBestellingContext context;

        public BestellingRepository(IBestellingContext context)
        {
            this.context = context;
        }

        public long Insert(Bestelling bestelling)
        {
            if (bestelling == null)
            {
                throw new NullReferenceException("Geen product.");
            }
            return context.Insert(bestelling);
        }

        public List<Bestelling> GetAll()
        {
            return context.GetAll();
        }

        public List<Bestelling> GetAllFromUser(long id)
        {
            return context.GetAllFromUser(id);
        }

        public bool Update(Bestelling obj)
        {
            return context.Update(obj);
        }

        public Bestelling GetById(long id)
        {
            return context.GetById(id);
        }

        public bool Activation(long id, bool active)
        {
            return context.Activation(id, active);
        }
    }
}
