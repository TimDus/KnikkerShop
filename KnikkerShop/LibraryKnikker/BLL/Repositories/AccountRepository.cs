﻿using LibraryKnikker.Core.DAL.Context.IContext;
using LibraryKnikker.Core.DAL.Data;
using System;
using System.Collections.Generic;

namespace LibraryKnikker.Core.BLL.Repositories
{
    public class AccountRepository
    {
        private readonly IAccountContext context;

        public AccountRepository(IAccountContext context)
        {
            this.context = context;
        }

        public long Insert(BaseAccount klant)
        {
            if (klant == null)
            {
                throw new NullReferenceException("Geen product.");
            }
            return context.Insert(klant);
        }

        public List<BaseAccount> GetAll()
        {
            return context.GetAll();
        }

        public bool Update(BaseAccount obj)
        {
            return context.Update(obj);
        }

        public BaseAccount GetById(long id)
        {
            return context.GetById(id);
        }

        public bool Activation(long id, bool active)
        {
            return context.Activation(id, active);
        }
    }
}
