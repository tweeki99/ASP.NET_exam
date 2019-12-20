using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Exam.DTOs;
using Exam.DTOs.EarthquakeDTO;
using Exam.Options;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace Exam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        //[System.Web.Mvc.OutputCache(Duration = 60)]
        [ResponseCache(Duration = 60)]
        public IActionResult GetInfo()
        {
            string json;
            using (WebClient client = new WebClient())
            {
                var count = HttpContext.Request.Headers["Count"];

                if (string.IsNullOrEmpty(count))
                {
                    json = client.DownloadString("https://earthquake.usgs.gov/fdsnws/event/1/query?format=geojson");
                }
                else json = client.DownloadString("https://earthquake.usgs.gov/fdsnws/event/1/query?format=geojson&limit=" + count);
            }
            var data = JsonConvert.DeserializeObject<FeatureCollection>(json);

            return Ok(data.Features);
        }
    }
}