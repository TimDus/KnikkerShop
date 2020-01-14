using LibraryKnikker.Core.DAL.Context.IContext;
using LibraryKnikker.Core.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryKnikker.Core.BLL.Repositories
{
    public class KlantRepository
    {
        private readonly IKlantContext context;

        public KlantRepository(IKlantContext context)
        {
            this.context = context;
        }

        public long Insert(Klant klant)
        {
            if (klant == null)
            {
                throw new NullReferenceException("Geen product.");
            }
            return context.Insert(klant);
        }

        public List<Klant> GetAll()
        {
            return context.GetAll();
        }

        public bool Update(Klant obj)
        {
            return context.Update(obj);
        }

        public Klant GetById(long id)
        {
            return context.GetById(id);
        }

        public bool Activation(long id, bool active)
        {
            return context.Activation(id, active);
        }
    }
}
