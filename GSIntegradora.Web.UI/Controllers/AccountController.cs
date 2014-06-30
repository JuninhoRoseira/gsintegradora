using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using GSIntegradora.Aplicacao.Servicos;
using GSIntegradora.Dominio.Interfaces;
using GSIntegradora.Web.UI.Filters;
using GSIntegradora.Web.UI.Models;

namespace GSIntegradora.Web.UI.Controllers
{
	[Authorize]
	[InitializeSimpleMembership]
	public class AccountController : Controller
	{

		private readonly IFormsAuthenticationService _formsService;
		private readonly IMembershipService _membershipService;

		public AccountController(IFormsAuthenticationService formsService, IMembershipService membershipService)
		{
			_formsService = formsService;
			_membershipService = membershipService;
		}

		//
		// GET: /Account/Login

		[AllowAnonymous]
		public ActionResult Login(string returnUrl)
		{
			ViewBag.ReturnUrl = returnUrl;
			return View();
		}

		//
		// POST: /Account/Login

		[AllowAnonymous]
		[HttpPost]
		public ActionResult Login(LogOnModel model, string returnUrl)
		{
			if (ModelState.IsValid)
			{
				if (_membershipService.ValidateUser(model.Nome, model.Senha))
				{
					_formsService.SignIn(model.Nome, model.LembrarMe);

					if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
						&& !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
					{
						return Redirect(returnUrl);
					}

					return RedirectToAction("Index", "Home");

				}

				ModelState.AddModelError("", "The user name or password provided is incorrect.");

			}

			// If we got this far, something failed, redisplay form
			return View(model);

		}

		public ActionResult LogOff()
		{
			_formsService.SignOut();

			return RedirectToAction("Index", "Home");

		}

	}

}