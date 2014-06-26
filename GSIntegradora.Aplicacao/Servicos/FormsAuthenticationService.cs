using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using GSIntegradora.Dominio.Interfaces;

namespace GSIntegradora.Aplicacao.Servicos
{
	public class FormsAuthenticationService : IFormsAuthenticationService
	{
		public void SignIn(string userName, bool createPersistentCookie)
		{
			if (String.IsNullOrEmpty(userName))
				throw new ArgumentException("Value cannot be null or empty.", "userName");

			FormsAuthentication.SetAuthCookie(userName, createPersistentCookie);

		}

		public void SignOut()
		{
			FormsAuthentication.SignOut();
		}

	}

}