using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using EntidadesAbstractas;
using Clases_Instanciables;
using Archivos;

namespace Tests_Unitarios
{
    [TestClass]
    public class TestUnitarios
    {
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void TestExcepcionDni()
        {
            //DNI con letras
            Alumno a1 = new Alumno(1, "Juan", "Lopez", "asdasd",
            EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Programacion,
            Alumno.EEstadoCuenta.Becado);
        }

        [TestMethod]
        [ExpectedException(typeof(ArchivosException))]
        public void TestExcepcionArchivos()
        {
            //Leer un archivo inexistente
            Texto texto = new Texto();
            texto.Leer(@"C:\CarpetaInexistente\Archivo", out string datos);
        }

        [TestMethod]
        public void TestAtributosNoNulos()
        {
            //Leer un Alumno y ver que no tenga ningun atributo nulo
            Alumno a1 = new Alumno(1, "Ignacio", "Rolon", "42997128",
            EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
            Alumno.EEstadoCuenta.AlDia);
            Assert.IsNotNull(a1);
            Assert.IsNotNull(a1.Apellido);
            Assert.IsNotNull(a1.Dni);
            Assert.IsNotNull(a1.Nacionalidad);
            Assert.IsNotNull(a1.Nombre);
        }

        [TestMethod]
        public void TestValoresNumericos()
        {
            //Validar que sean valores numericos
            string dni = "30203021";
            Alumno a1 = new Alumno(2, "Juan", "Perez", dni,
            EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
            Alumno.EEstadoCuenta.AlDia);
            Assert.IsInstanceOfType(a1.Dni, typeof(int));
        }
    }
}
