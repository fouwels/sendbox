using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Http;
using proj.Models;
using proj.Repositories;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace proj.Controllers
{
	[Route("[controller]/[action]")]
	public class InboundController : Controller
	{
		// GET: api/values
		[HttpPost]
		public IActionResult Sendgrid(string text,string html,string to, string subject, string from, RedisRepository redisRepository)
		{
			var x = new Models.Mailmodel
			{
				Text = text,
				Html = html,
				To = to,
				From = from,
				Subject = subject
			};
			redisRepository.PutMail(x.Subject, x); //transactions lol
			return new HttpStatusCodeResult(200);
		}

	}
}
