using Microsoft.AspNetCore.Mvc;

namespace TakeAway.WebUI.ViewComponents
{
    public class _UITopBarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
