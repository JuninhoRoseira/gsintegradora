using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSIntegradora.Dominio.Entidades
{
	public class Usuario
	{
		public virtual int Codigo { get; set; }
		public virtual String Nome { get; set; }
		public virtual string Login { get; set; }
		public virtual string Email { get; set; }
		public virtual bool Ativo { get; set; }
		public virtual string Senha { get; set; }
	}
}
