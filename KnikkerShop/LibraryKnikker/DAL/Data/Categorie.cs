using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryKnikker.Core.DAL.Data
{
    public class Categorie : Entity
    { 
        public string Naam { get; set; }
        public bool Actief { get; set; }
    }
}
