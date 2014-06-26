using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSIntegradora.Dominio.Entidades;

namespace GSIntegradora.Dominio.Interfaces
{
	public interface IUsuarioContexto
	{
		void AdicionaUsuario(Usuario usuario);
		Usuario ObtemUsuario(string nome);
		Usuario ObtemUsuario(string nome, string senha);
	}
}
