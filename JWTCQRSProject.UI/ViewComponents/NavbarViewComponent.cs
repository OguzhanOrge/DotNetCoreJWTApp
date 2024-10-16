using Microsoft.AspNetCore.Mvc;

namespace JWTCQRSProject.UI.ViewComponents
{
    public class NavbarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
            return View();
        }
    }
}
