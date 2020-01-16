namespace KnikkerShop.Models
{
    public class KlantDetailViewmodel : BaseAccountDetailViewmodel
    {
        public long KlantId { get; set; }
        public string Postcode { get; set; }
        public string Huisnummer { get; set; }
    }
}
