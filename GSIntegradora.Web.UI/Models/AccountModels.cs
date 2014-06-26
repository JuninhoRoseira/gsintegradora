using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GSIntegradora.Web.UI.Models
{
	public class LogOnModel
	{
		[Required]
		[Display(Name = "Usuário")]
		public string Nome { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "Senha")]
		public string Senha { get; set; }

		[Display(Name = "Lembrar-me?")]
		public bool LembrarMe { get; set; }
	}

}