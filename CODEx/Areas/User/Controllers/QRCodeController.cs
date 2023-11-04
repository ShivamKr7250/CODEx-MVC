using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration;
using System.Drawing.Imaging;
using System.Drawing;
using QRCoder;

namespace CODEx.Areas.User.Controllers
{
    [Area("User")]
    public class QRCodeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GenerateQRCode(string qrCodeText)
        {
            if (!string.IsNullOrEmpty(qrCodeText))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    QRCodeGenerator qrCodeGenerator = new QRCodeGenerator();
                    QRCodeData qrCodeData = qrCodeGenerator.CreateQrCode(qrCodeText, QRCodeGenerator.ECCLevel.Q);
                    QRCode qrCode = new QRCode(qrCodeData);
                    using (Bitmap qrBitmap = qrCode.GetGraphic(20))
                    {
                        qrBitmap.Save(ms, ImageFormat.Png);
                        byte[] pngBytes = ms.ToArray();

                        // Return the QR code image as a downloadable file
                        return File(pngBytes, "image/png", "QRCode.png");
                    }
                }
            }

            return View("Index");
        }
    }
}
