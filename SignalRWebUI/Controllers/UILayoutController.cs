using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
    public class UILayoutController : Controller
    {
        //Websitesi arayüz layout kısmı
        public IActionResult Index()
        {
            return View();
        }
    }
}
