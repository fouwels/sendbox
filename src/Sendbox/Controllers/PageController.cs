using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using proj.Repositories;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace proj.Controllers
{
	public class PageController : Controller
    {
		[HttpGet]
        public IActionResult Index()
        {
            return View();
        }

		[HttpPost]
		public Models.Mailmodel Index(string key, RedisRepository redisRepository)
		{
			return redisRepository.GetMail(key);
		}
    }
}
