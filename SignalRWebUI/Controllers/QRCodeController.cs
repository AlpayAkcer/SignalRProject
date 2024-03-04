using Microsoft.AspNetCore.Mvc;
using QRCoder;
using SignalR.EntityLayer.Entities;
using SignalRWebUI.DtoViewModels.SliderDto;
using System.Drawing;

namespace SignalRWebUI.Controllers
{
    public class QRCodeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string value)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                QRCodeGenerator codeGenerator = new QRCodeGenerator();
                QRCodeGenerator.QRCode sqrCode = codeGenerator.CreateQrCode(value, QRCodeGenerator.ECCLevel.H);
                using (Bitmap image = sqrCode.GetGraphic(10))
                {
                    image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                    ViewBag.QRCodeImage = "data:image/png;base64," + Convert.ToBase64String(memoryStream.ToArray());
                }
            }
            return View();
        }
    }
}
