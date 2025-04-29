using Microsoft.AspNetCore.Mvc;

namespace TakeAway.WebUI.ViewComponents
{
    public class _UIBannerComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
