using LibraryKnikker.Core.DAL.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KnikkerShop.Models
{
    public class WinkelwagenViewModel
    {
        public int TotalPrijs { get; set; }
        public List<Product> Producten = new List<Product>();
        public BaseAccount BaseAccount = new BaseAccount();

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Leverdatum")]
        public DateTime Leverdatum { get; set; }
    }
}
