using Microsoft.AspNetCore.Mvc;

namespace TakeAway.WebUI.ViewComponents
{
    public class _UIFreshOrganicVegetablesComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
