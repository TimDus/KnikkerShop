using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace KnikkerShop.Controllers
{
    public abstract class BaseController : Controller
    {
        protected virtual long GetUserId()
        {
            string rawValue = HttpContext.User.Identities.First().Claims.First().Value;
            if (string.IsNullOrEmpty(rawValue))
                return -1;

            if (long.TryParse(rawValue, out long id))
                return id;
            return -1;
        }
    }
}
