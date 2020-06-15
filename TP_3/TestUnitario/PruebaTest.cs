using ClasesAbstractas;
using ClasesInstanciables;
using Excepciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TestUnitario
{
    [TestClass]
    public class PruebaTest
    {
		
		[TestMethod]
		[ExpectedException(typeof(NacionalidadInvalidaException))]
		public void AlumnoArgentinoDniExtranjero()
		{
		string unDni = "90000000";
	
		Alumno unAlumno = new Alumno(1, "AlumnoNombre", "AlumnoApellido", unDni,
		Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);
		
		}

		[TestMethod]
		public void AlumnoDuplicado()
		{
			Profesor unProfesor = new Profesor();
			Jornada unaJornada = new Jornada(Universidad.EClases.Laboratorio, unProfesor);
			Alumno unAlumno = new Alumno(1, "Nombre", "Apellido", "123456",Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);

			try
			{
				unaJornada += unAlumno;
				unaJornada += unAlumno;
			}
			catch (Exception ex)
			{
				Assert.IsInstanceOfType(ex, typeof(AlumnoRepetidoException));
				return;
			}

			Assert.Fail("Se esperaba excepción del tipo AlumnoRepetidoException");
		}


		[TestMethod]
		public void ProfesorConDniIncorrecto()
		{
			string unDni = "ASDF123";
			try
			{
				Profesor unProfesor = new Profesor(0, "Professor", "Professosor", unDni, Persona.ENacionalidad.Argentino);
			}
			catch (Exception ex)
			{
				Assert.IsInstanceOfType(ex, typeof(DniInvalidoException));
				return;
			}

			Assert.Fail("Se esperaba excepción del tipo DniInvalidoException");
		}

		[TestMethod]
		public void ListaDeAlumnosNoEsNullEnJornada()
		{
			Profesor unProfesor = new Profesor();
			Jornada jornada = new Jornada(Universidad.EClases.Laboratorio, unProfesor);
			List<Alumno> alumnos;

			alumnos = jornada.Alumnos;

			Assert.IsNotNull(alumnos);
		}

		public void ListaDeProfesoresNoEsNullEnUniversidad()
		{
			Universidad unaUniversidad = new Universidad();
			Profesor unProfesor = new Profesor(0, "Nombre", "Apellido", "123456", Persona.ENacionalidad.Argentino);
			List<Profesor> profesores;

			unaUniversidad += unProfesor;
			profesores = unaUniversidad.Instructores;

			Assert.IsNotNull(unProfesor);
		}

	}
}
