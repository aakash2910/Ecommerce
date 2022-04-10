using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Data
{
    public class SmallCartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");

            SmallCartViewModel smallCartViewModel;

            if (cart == null || cart.Count == 0)
            {
                smallCartViewModel = null;
            }
            else
            {
                smallCartViewModel = new SmallCartViewModel()
                {
                    NumberOfItems = cart.Sum(x => x.Quantity),
                    ToralAmount = cart.Sum(x => x.Quantity * x.Price)
                };
            }

            return View(smallCartViewModel);
        }
    }
}
