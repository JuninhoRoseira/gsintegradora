using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace GSIntegradora.Web.UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

	    [AcceptVerbs("POST")]

		public ActionResult Index(string name, string email, string subject, string message, string empresa, string telefone)
	    {
		    var mailMessage = new MailMessage
		    {
			    Subject = subject,
			    Body = string.Format(
				    "{0}<hr/><b>Nome:</b>{1}<br/><b>E-Mail:</b>{2}<br/><b>Empresa:</b>{3}<br/><b>Telefone:</b>{4}",
				    message,
				    name,
				    email,
				    empresa,
				    telefone),
			    IsBodyHtml = true
		    };

			mailMessage.ReplyToList.Add(email);

			var client = new SmtpClient();
			var cred = (NetworkCredential) client.Credentials;

			mailMessage.To.Add(cred.UserName);

			try
			{
				client.Send(mailMessage);
			}
			catch
			{
			}

			if (Request.IsAjaxRequest())
			{
				return Content("ok!");
			}

		    return View();

	    }

		[Authorize]
		public ActionResult Protected()
		{
			return View();
		}

    }

}