using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc.Razor;
using Microsoft.Framework.OptionsModel;

namespace proj.ViewEngines
{
	public class DefaultViewEngine : RazorViewEngine
	{
		public DefaultViewEngine(IRazorPageFactory pageFactory, IRazorViewFactory viewFactory, IOptions<RazorViewEngineOptions> optionsAccessor, IViewLocationCache viewLocationCache) : base(pageFactory, viewFactory, optionsAccessor, viewLocationCache)
		{
		}
		public override IEnumerable<string> ViewLocationFormats
		{
			get
			{
				List<string> existing = base.ViewLocationFormats.ToList();
				existing.Add("/Front/Views/{1}/{0}.cshtml");
				existing.Add("/Front/Views/Shared/{0}.cshtml");
				return existing;
			}
		}
	}
}
