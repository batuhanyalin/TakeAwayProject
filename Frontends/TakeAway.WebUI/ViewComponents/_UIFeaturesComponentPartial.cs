using Microsoft.AspNetCore.Mvc;

namespace TakeAway.WebUI.ViewComponents
{
    public class _UIFeaturesComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
