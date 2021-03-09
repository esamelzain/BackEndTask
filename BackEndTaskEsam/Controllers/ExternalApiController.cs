using BackEndTaskEsam.Models.External;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace BackEndTaskEsam.Controllers
{
    public class ExternalApiController : Controller
    {
        // GET: ExternalApi
        public ActionResult Index()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.AutomaticDecompression = System.Net.DecompressionMethods.GZip;
            using(var client=new HttpClient(clientHandler))
            {
                //ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                client.BaseAddress = new Uri("https://api.stackexchange.com");
                var response = client.GetAsync("2.2/questions?page=1&pagesize=50&order=desc&sort=activity&site=stackoverflow");
                var result = response.Result.Content.ReadAsStringAsync();
                var json = result.Result;
                var questions = JsonConvert.DeserializeObject<Questions>(json);
                return View(questions);
            }
        }
    }
}
