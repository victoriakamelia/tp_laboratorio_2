using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class UnitTestCorreo
    {
		[TestMethod]
		public void ListaDePaquetesInstanciada()
		{
			List<Paquete> listaPaquetes;
			Correo unCorreo = new Correo();

			listaPaquetes = unCorreo.Paquetes;

			Assert.IsNotNull(listaPaquetes);
		}

		[TestMethod]
		public void TrackingIdRepetidoExcepcion()
		{
		
			Correo unCorreo = new Correo();
			Paquete paqueteUno = new Paquete("Av. Siempreviva 123", "55");
			Paquete paqueteDos = new Paquete("Av. Siempreviva 123", "55");

			try
			{
				unCorreo += paqueteUno;
				unCorreo += paqueteDos;
				Assert.Fail();
			}
			catch (Exception e)
			{
				Assert.AreEqual(typeof(TrackingIdRepetidoException), e.GetType());
			}
		}
	}
}
