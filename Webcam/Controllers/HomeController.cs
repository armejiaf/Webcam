using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Webcam.Controllers
{
    public class HomeController : Controller
    {
            public ActionResult Index()
            {
                return View();
            }

            public ActionResult Webcam()
            {
                return View();
            }
    

          public void Capture()
         {
             var stream = Request.InputStream;
             string dump;
  
             using (var reader = new StreamReader(stream))
                 dump = reader.ReadToEnd();
  
             var path = Server.MapPath("~/test.jpg");
             System.IO.File.WriteAllBytes(path, String_To_Bytes2(dump));
         }
  
         private static byte[] String_To_Bytes2(string strInput)
         {
             var numBytes = (strInput.Length) / 2;
             var bytes = new byte[numBytes];
  
             for (var x = 0; x < numBytes; ++x)
             {
                 bytes[x] = Convert.ToByte(strInput.Substring(x * 2, 2), 16);
             }
  
             return bytes;
        }
    }
}