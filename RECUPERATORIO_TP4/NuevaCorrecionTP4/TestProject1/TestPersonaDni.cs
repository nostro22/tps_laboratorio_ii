using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP3ClassLibrary;

namespace TestTP3
{
    [TestClass]
    public class TestPersonaDni
    {
        [TestMethod]       
        public void ValidarDni_CuandoDniEsMenorCero_RetornoFalse()
        {
            //Arrange
            string dni = "-12345";
            
            //Act
            bool retorno = Persona.DniValido(dni);

            //Assert
            Assert.IsFalse(retorno);
        }
             


        [TestMethod]

        public void ValidarDni_CuandoContinerLetras_RetornoFalse()
        {
            //Arrange
            string dni = "12345C78A";

            //Act
            bool retorno = Persona.DniValido(dni);

            //Assert

            Assert.IsFalse(retorno);
        }

        [TestMethod]

        public void ValidarDni_CuandoSonLetras_RetornoFalse()
        {
            //Arrange
            string dni = "BfdA";

            //Act
            bool retorno = Persona.DniValido(dni);

            //Assert

            Assert.IsFalse(retorno);
        }

        [TestMethod]

        public void ValidarDni_CuandoEsSoloCeros_RetornoFalse()
        {
            //Arrange
            string dni = "000000";

            //Act
            bool retorno = Persona.DniValido(dni);

            //Assert

            Assert.IsFalse(retorno);
        }

        [TestMethod]

        public void ValidarDni_CuandoEsCeroYNumero_RetornoTrue()
        {
            //Arrange
            string dni = "012345678";

            //Act
            bool retorno = Persona.DniValido(dni);

            //Assert

            Assert.IsTrue(retorno);
        }
    }

  
    
}
