﻿using LibraryKnikker.Core.DAL.Data;
using LibraryKnikker.Core.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryKnikker.Core.DAL.Context.IContext
{
    public interface IBestellingContext : IGenericQueries<Bestelling>
    {
        List<Bestelling> GetAllFromUser(long Id);
    }
}
