using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
		private string mensajeBase;
		public DniInvalidoException() : this("DNI inválido")
        {

        }

		public DniInvalidoException(Exception e) : this("DNI inválido", e)
		{

		}

		public DniInvalidoException(string message) : base(message)
		{
			this.mensajeBase = message;
		}

		public DniInvalidoException(string message, Exception e) : base(message, e)
		{

		}

	}
}
