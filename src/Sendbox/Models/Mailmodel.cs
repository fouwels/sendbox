using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proj.Models
{
    public class Mailmodel
    {
		public string Text { get; set; }
		public string Html { get; set; }
		public string From { get; set; }
		public string To { get; set; }
		public string Subject { get; set; }
	}
}
