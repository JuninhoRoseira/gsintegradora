using System;
using System.Web.Security;
using GSIntegradora.Dominio.Interfaces;
using GSIntegradora.Infraestrutura;
using GSIntegradora.Infraestrutura.Contextos;
using GSIntegradora.Infraestrutura.NHibernate.Configuracao;
using Ninject;

namespace GSIntegradora.Aplicacao.Servicos
{
	public class AccountMembershipService : IMembershipService
	{
		private readonly MembershipProvider _provider;

		public AccountMembershipService()
			: this(null)
		{
		}

		public AccountMembershipService(MembershipProvider provider)
		{

			//// TODO: Injetar dependencia
			//if (provider != null)
			//	_provider = provider;
			//else
			//{
			//	var session = NHibernateHelper.SessionFactory.OpenSession();
			//	var usuarioContexto = new UsuarioContexto(session);

			//	_provider = new GSIMembershipProvider(usuarioContexto);

			//}

			// TODO: Injetar dependencia
			_provider = provider ?? Membership.Provider;

			//CreateUser("wilson", "kk01jold", "juninhoroseira@gmail.com");

		}

		public int MinPasswordLength
		{
			get
			{
				return _provider.MinRequiredPasswordLength;
			}
		}

		public bool ValidateUser(string userName, string password)
		{
			if (String.IsNullOrEmpty(userName)) throw new ArgumentException("Value cannot be null or empty.", "userName");
			if (String.IsNullOrEmpty(password)) throw new ArgumentException("Value cannot be null or empty.", "password");

			return _provider.ValidateUser(userName, password);

		}

		public MembershipCreateStatus CreateUser(string userName, string password, string email)
		{
			if (String.IsNullOrEmpty(userName)) throw new ArgumentException("Value cannot be null or empty.", "userName");
			if (String.IsNullOrEmpty(password)) throw new ArgumentException("Value cannot be null or empty.", "password");
			if (String.IsNullOrEmpty(email)) throw new ArgumentException("Value cannot be null or empty.", "email");

			MembershipCreateStatus status;

			_provider.CreateUser(userName, password, email, null, null, true, null, out status);

			return status;

		}

		public bool ChangePassword(string userName, string oldPassword, string newPassword)
		{
			if (String.IsNullOrEmpty(userName)) throw new ArgumentException("Value cannot be null or empty.", "userName");
			if (String.IsNullOrEmpty(oldPassword)) throw new ArgumentException("Value cannot be null or empty.", "oldPassword");
			if (String.IsNullOrEmpty(newPassword)) throw new ArgumentException("Value cannot be null or empty.", "newPassword");

			// The underlying ChangePassword() will throw an exception rather
			// than return false in certain failure scenarios.
			try
			{
				var currentUser = _provider.GetUser(userName, true /* userIsOnline */);

				return currentUser != null && currentUser.ChangePassword(oldPassword, newPassword);

			}
			catch (ArgumentException)
			{
				return false;
			}
			catch (MembershipPasswordException)
			{
				return false;
			}

		}

	}

}