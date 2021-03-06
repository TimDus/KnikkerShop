﻿using LibraryKnikker.Core.DAL.Context.IContext;
using LibraryKnikker.Core.DAL.Data;
using System;
using System.Collections.Generic;

namespace LibraryKnikker.Core.BLL.Repositories
{
    public class CategorieRepository
    {
        private readonly ICategorieContext context;

        public CategorieRepository(ICategorieContext context)
        {
            this.context = context;
        }

        public List<Categorie> GetAll()
        {
            return context.GetAll();
        }

        public Categorie GetById(long id)
        {
            return context.GetById(id);
        }

        public long Insert(Categorie obj)
        {
            if (obj == null)
            {
                throw new NullReferenceException("Geen categorie.");
            }
            return context.Insert(obj);
        }

        public bool Update(Categorie obj)
        {
            return context.Update(obj);
        }

        public bool Activation(long id, bool active)
        {
            return context.Activation(id, active);
        }
    }
}
