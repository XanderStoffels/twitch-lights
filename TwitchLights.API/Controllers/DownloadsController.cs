using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TwitchLights.API.Controllers
{
    [Route("[controller]")]
    public class DownloadsController : Controller
    {
        [HttpGet]
        public IActionResult RedirectionBasedOnOs()
        {
            if (Request.Headers.ContainsKey("User-Agent"))
            {
                var browser = Request.Headers["User-Agent"].ToString().ToLower();
                if (browser.Contains("mac"))
                {
                    return RedirectToAction("Mac");
                } else if (browser.Contains("linux")) 
                {
                    return RedirectToAction("Linux");
                }
            }
            return RedirectToAction("Windows");

        }

        [HttpGet("Windows")]
        public IActionResult Windows()
        {
            return View();
        }

        [HttpGet("Linux")]
        public IActionResult Linux()
        {
            return View();
        }

        [HttpGet("Mac")]
        public IActionResult Mac()
        {
            return View();
        }
    }
}