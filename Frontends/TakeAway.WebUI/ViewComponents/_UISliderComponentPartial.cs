using Microsoft.AspNetCore.Mvc;

namespace TakeAway.WebUI.ViewComponents
{
    public class _UISliderComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
